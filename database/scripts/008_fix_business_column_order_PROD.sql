-- =====================================================================
-- 008_fix_business_column_order_PROD.sql
-- KSS_Person_Prod ONLY
--
-- Goal: Drop+recreate 9 empty business tables to consolidate split audit
-- clumps into a single trailing audit block. All target tables are
-- confirmed empty (0 rows). Drop+recreate is safe.
--
-- Final column order for each table:
--   ...business cols...
--   CreatedBy   UNIQUEIDENTIFIER  NOT NULL
--   CreatedAt   DATETIME2         NOT NULL
--   UpdatedBy   UNIQUEIDENTIFIER  NULL
--   UpdatedAt   DATETIME2         NULL
--   DeletedBy   UNIQUEIDENTIFIER  NULL
--   DeletedAt   DATETIME2         NULL
--   IsActive    BIT               NOT NULL  DEFAULT 1
--
-- Tables: Address, Document, EducationDocument, Email,
--         EmploymentDocument, Nationality, Phone, Relationship, Status
-- =====================================================================

USE KSS_Person_Prod;
GO
SET XACT_ABORT ON;
SET NOCOUNT ON;
GO

BEGIN TRANSACTION;

PRINT '=== Pre-flight: confirm 0 rows in all 9 targets ===';
DECLARE @badTbl NVARCHAR(128) = NULL;
DECLARE @cnt BIGINT;

SELECT @cnt = SUM(p.rows) FROM sys.partitions p WHERE p.object_id = OBJECT_ID('Address') AND p.index_id IN (0,1);
IF @cnt > 0 SET @badTbl = 'Address';
SELECT @cnt = SUM(p.rows) FROM sys.partitions p WHERE p.object_id = OBJECT_ID('Document') AND p.index_id IN (0,1);
IF @cnt > 0 SET @badTbl = 'Document';
SELECT @cnt = SUM(p.rows) FROM sys.partitions p WHERE p.object_id = OBJECT_ID('EducationDocument') AND p.index_id IN (0,1);
IF @cnt > 0 SET @badTbl = 'EducationDocument';
SELECT @cnt = SUM(p.rows) FROM sys.partitions p WHERE p.object_id = OBJECT_ID('Email') AND p.index_id IN (0,1);
IF @cnt > 0 SET @badTbl = 'Email';
SELECT @cnt = SUM(p.rows) FROM sys.partitions p WHERE p.object_id = OBJECT_ID('EmploymentDocument') AND p.index_id IN (0,1);
IF @cnt > 0 SET @badTbl = 'EmploymentDocument';
SELECT @cnt = SUM(p.rows) FROM sys.partitions p WHERE p.object_id = OBJECT_ID('Nationality') AND p.index_id IN (0,1);
IF @cnt > 0 SET @badTbl = 'Nationality';
SELECT @cnt = SUM(p.rows) FROM sys.partitions p WHERE p.object_id = OBJECT_ID('Phone') AND p.index_id IN (0,1);
IF @cnt > 0 SET @badTbl = 'Phone';
SELECT @cnt = SUM(p.rows) FROM sys.partitions p WHERE p.object_id = OBJECT_ID('Relationship') AND p.index_id IN (0,1);
IF @cnt > 0 SET @badTbl = 'Relationship';
SELECT @cnt = SUM(p.rows) FROM sys.partitions p WHERE p.object_id = OBJECT_ID('Status') AND p.index_id IN (0,1);
IF @cnt > 0 SET @badTbl = 'Status';

IF @badTbl IS NOT NULL
BEGIN
    DECLARE @msg NVARCHAR(400) = 'Aborting: table ' + @badTbl + ' has rows. This migration only safe on empty tables.';
    RAISERROR(@msg, 16, 1);
    ROLLBACK TRANSACTION;
    RETURN;
END;
PRINT 'Pre-flight OK: all 9 targets are empty.';

-- =====================================================================
-- Drop incoming FKs (only one: AddressTranslation -> Address)
-- =====================================================================
PRINT '=== Drop incoming FK: FK_AddressTranslation_Address ===';
IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_AddressTranslation_Address')
    ALTER TABLE [dbo].[AddressTranslation] DROP CONSTRAINT [FK_AddressTranslation_Address];

-- =====================================================================
-- 1. Address
-- =====================================================================
PRINT '=== Recreating Address ===';
DROP TABLE [dbo].[Address];

CREATE TABLE [dbo].[Address] (
    [Id]          UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_Address_Id] DEFAULT (newsequentialid()),
    [PersonId]    UNIQUEIDENTIFIER NOT NULL,
    [LabelId]     TINYINT          NOT NULL,
    [CountryId]   SMALLINT         NOT NULL,
    [RegionId]    SMALLINT         NOT NULL,
    [CityId]      INT              NOT NULL,
    [PostalCode]  VARCHAR(10)      NOT NULL,
    [Latitude]    DECIMAL(9,6)     NULL,
    [Longitude]   DECIMAL(9,6)     NULL,
    [IsPrimary]   BIT              NOT NULL CONSTRAINT [DF_Address_IsPrimary]  DEFAULT ((0)),
    [IsVerified]  BIT              NOT NULL CONSTRAINT [DF_Address_IsVerified] DEFAULT ((0)),
    [VerifiedAt]  DATETIME2        NULL,
    [CreatedBy]   UNIQUEIDENTIFIER NOT NULL,
    [CreatedAt]   DATETIME2        NOT NULL,
    [UpdatedBy]   UNIQUEIDENTIFIER NULL,
    [UpdatedAt]   DATETIME2        NULL,
    [DeletedBy]   UNIQUEIDENTIFIER NULL,
    [DeletedAt]   DATETIME2        NULL,
    [IsActive]    BIT              NOT NULL CONSTRAINT [DF_Address_IsActive] DEFAULT ((1)),
    CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([Id])
);

CREATE NONCLUSTERED INDEX [IX_Address_PersonId]  ON [dbo].[Address]([PersonId]);
CREATE NONCLUSTERED INDEX [IX_Address_LabelId]   ON [dbo].[Address]([LabelId]);
CREATE NONCLUSTERED INDEX [IX_Address_CountryId] ON [dbo].[Address]([CountryId]);
CREATE NONCLUSTERED INDEX [IX_Address_RegionId]  ON [dbo].[Address]([RegionId]);
CREATE NONCLUSTERED INDEX [IX_Address_CityId]    ON [dbo].[Address]([CityId]);

ALTER TABLE [dbo].[Address] ADD CONSTRAINT [FK_Address_Person]
    FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person]([Id]) ON DELETE CASCADE;
ALTER TABLE [dbo].[Address] ADD CONSTRAINT [FK_Address_Label]
    FOREIGN KEY ([LabelId]) REFERENCES [dbo].[AddressLabel]([Id]);

-- Recreate incoming FK from AddressTranslation
ALTER TABLE [dbo].[AddressTranslation] ADD CONSTRAINT [FK_AddressTranslation_Address]
    FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address]([Id]) ON DELETE CASCADE;

-- =====================================================================
-- 2. Document
-- =====================================================================
PRINT '=== Recreating Document ===';
DROP TABLE [dbo].[Document];

CREATE TABLE [dbo].[Document] (
    [Id]                 UNIQUEIDENTIFIER NOT NULL,
    [PersonId]           UNIQUEIDENTIFIER NOT NULL,
    [DocumentTypeId]     INT              NOT NULL,
    [StorageInstanceId]  INT              NOT NULL,
    [FileName]           NVARCHAR(255)    NOT NULL,
    [FileSize]           BIGINT           NOT NULL,
    [ContentType]        VARCHAR(100)     NOT NULL,
    [CreatedBy]          UNIQUEIDENTIFIER NOT NULL,
    [CreatedAt]          DATETIME2        NOT NULL,
    [UpdatedBy]          UNIQUEIDENTIFIER NULL,
    [UpdatedAt]          DATETIME2        NULL,
    [DeletedBy]          UNIQUEIDENTIFIER NULL,
    [DeletedAt]          DATETIME2        NULL,
    [IsActive]           BIT              NOT NULL CONSTRAINT [DF_Document_IsActive] DEFAULT ((1)),
    CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED ([Id])
);

CREATE NONCLUSTERED INDEX [IX_Document_PersonId] ON [dbo].[Document]([PersonId]);

ALTER TABLE [dbo].[Document] ADD CONSTRAINT [FK_Document_Person]
    FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person]([Id]);
ALTER TABLE [dbo].[Document] ADD CONSTRAINT [FK_Document_DocumentType]
    FOREIGN KEY ([DocumentTypeId]) REFERENCES [dbo].[DocumentType]([Id]);

-- =====================================================================
-- 3. EducationDocument
-- =====================================================================
PRINT '=== Recreating EducationDocument ===';
DROP TABLE [dbo].[EducationDocument];

CREATE TABLE [dbo].[EducationDocument] (
    [Id]                 UNIQUEIDENTIFIER NOT NULL,
    [EducationId]        UNIQUEIDENTIFIER NOT NULL,
    [StorageInstanceId]  INT              NOT NULL,
    [FileName]           NVARCHAR(255)    NOT NULL,
    [FileSize]           BIGINT           NOT NULL,
    [ContentType]        VARCHAR(100)     NOT NULL,
    [CreatedBy]          UNIQUEIDENTIFIER NOT NULL,
    [CreatedAt]          DATETIME2        NOT NULL,
    [UpdatedBy]          UNIQUEIDENTIFIER NULL,
    [UpdatedAt]          DATETIME2        NULL,
    [DeletedBy]          UNIQUEIDENTIFIER NULL,
    [DeletedAt]          DATETIME2        NULL,
    [IsActive]           BIT              NOT NULL CONSTRAINT [DF_EducationDocument_IsActive] DEFAULT ((1)),
    CONSTRAINT [PK_EducationDocument] PRIMARY KEY CLUSTERED ([Id])
);

CREATE NONCLUSTERED INDEX [IX_EducationDocument_EducationId] ON [dbo].[EducationDocument]([EducationId]);

ALTER TABLE [dbo].[EducationDocument] ADD CONSTRAINT [FK_EducationDocument_Education]
    FOREIGN KEY ([EducationId]) REFERENCES [dbo].[Education]([Id]);

-- =====================================================================
-- 4. Email
-- =====================================================================
PRINT '=== Recreating Email ===';
DROP TABLE [dbo].[Email];

CREATE TABLE [dbo].[Email] (
    [Id]          UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_Email_Id] DEFAULT (newsequentialid()),
    [PersonId]    UNIQUEIDENTIFIER NOT NULL,
    [LabelId]     TINYINT          NOT NULL,
    [Email]       VARCHAR(128)     NOT NULL,
    [IsPrimary]   BIT              NOT NULL CONSTRAINT [DF_Email_IsPrimary]  DEFAULT ((0)),
    [IsVerified]  BIT              NOT NULL CONSTRAINT [DF_Email_IsVerified] DEFAULT ((0)),
    [VerifiedAt]  DATETIME2        NULL,
    [CreatedBy]   UNIQUEIDENTIFIER NOT NULL,
    [CreatedAt]   DATETIME2        NOT NULL,
    [UpdatedBy]   UNIQUEIDENTIFIER NULL,
    [UpdatedAt]   DATETIME2        NULL,
    [DeletedBy]   UNIQUEIDENTIFIER NULL,
    [DeletedAt]   DATETIME2        NULL,
    [IsActive]    BIT              NOT NULL CONSTRAINT [DF_Email_IsActive] DEFAULT ((1)),
    CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [UQ_Email_Email] UNIQUE NONCLUSTERED ([PersonId],[Email])
);

CREATE NONCLUSTERED INDEX [IX_Email_PersonId] ON [dbo].[Email]([PersonId]);
CREATE NONCLUSTERED INDEX [IX_Email_LabelId]  ON [dbo].[Email]([LabelId]);
CREATE NONCLUSTERED INDEX [IX_Email_Email]    ON [dbo].[Email]([Email]);

ALTER TABLE [dbo].[Email] ADD CONSTRAINT [FK_Email_Person]
    FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person]([Id]) ON DELETE CASCADE;
ALTER TABLE [dbo].[Email] ADD CONSTRAINT [FK_Email_Label]
    FOREIGN KEY ([LabelId]) REFERENCES [dbo].[EmailLabel]([Id]);

-- =====================================================================
-- 5. EmploymentDocument
-- =====================================================================
PRINT '=== Recreating EmploymentDocument ===';
DROP TABLE [dbo].[EmploymentDocument];

CREATE TABLE [dbo].[EmploymentDocument] (
    [Id]                 UNIQUEIDENTIFIER NOT NULL,
    [EmploymentId]       UNIQUEIDENTIFIER NOT NULL,
    [StorageInstanceId]  INT              NOT NULL,
    [FileName]           NVARCHAR(255)    NOT NULL,
    [FileSize]           BIGINT           NOT NULL,
    [ContentType]        VARCHAR(100)     NOT NULL,
    [CreatedBy]          UNIQUEIDENTIFIER NOT NULL,
    [CreatedAt]          DATETIME2        NOT NULL,
    [UpdatedBy]          UNIQUEIDENTIFIER NULL,
    [UpdatedAt]          DATETIME2        NULL,
    [DeletedBy]          UNIQUEIDENTIFIER NULL,
    [DeletedAt]          DATETIME2        NULL,
    [IsActive]           BIT              NOT NULL CONSTRAINT [DF_EmploymentDocument_IsActive] DEFAULT ((1)),
    CONSTRAINT [PK_EmploymentDocument] PRIMARY KEY CLUSTERED ([Id])
);

CREATE NONCLUSTERED INDEX [IX_EmploymentDocument_EmploymentId] ON [dbo].[EmploymentDocument]([EmploymentId]);

ALTER TABLE [dbo].[EmploymentDocument] ADD CONSTRAINT [FK_EmploymentDocument_Employment]
    FOREIGN KEY ([EmploymentId]) REFERENCES [dbo].[Employment]([Id]);

-- =====================================================================
-- 6. Nationality
-- =====================================================================
PRINT '=== Recreating Nationality ===';
DROP TABLE [dbo].[Nationality];

CREATE TABLE [dbo].[Nationality] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [PersonId]   UNIQUEIDENTIFIER NOT NULL,
    [CountryId]  SMALLINT         NOT NULL,
    [CreatedBy]  UNIQUEIDENTIFIER NOT NULL,
    [CreatedAt]  DATETIME2        NOT NULL,
    [UpdatedBy]  UNIQUEIDENTIFIER NULL,
    [UpdatedAt]  DATETIME2        NULL,
    [DeletedBy]  UNIQUEIDENTIFIER NULL,
    [DeletedAt]  DATETIME2        NULL,
    [IsActive]   BIT              NOT NULL CONSTRAINT [DF_Nationality_IsActive] DEFAULT ((1)),
    CONSTRAINT [PK_Nationality] PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [UQ_Nationality_PersonId_CountryId] UNIQUE NONCLUSTERED ([PersonId],[CountryId])
);

ALTER TABLE [dbo].[Nationality] ADD CONSTRAINT [FK_Nationality_Person]
    FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person]([Id]) ON DELETE CASCADE;

-- =====================================================================
-- 7. Phone
-- =====================================================================
PRINT '=== Recreating Phone ===';
DROP TABLE [dbo].[Phone];

CREATE TABLE [dbo].[Phone] (
    [Id]           UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_Phone_Id] DEFAULT (newsequentialid()),
    [PersonId]     UNIQUEIDENTIFIER NOT NULL,
    [LabelId]      TINYINT          NOT NULL,
    [CountryId]    SMALLINT         NOT NULL,
    [PhoneNumber]  VARCHAR(15)      NOT NULL,
    [IsPrimary]    BIT              NOT NULL CONSTRAINT [DF_Phone_IsPrimary]  DEFAULT ((0)),
    [IsVerified]   BIT              NOT NULL CONSTRAINT [DF_Phone_IsVerified] DEFAULT ((0)),
    [VerifiedAt]   DATETIME2        NULL,
    [CreatedBy]    UNIQUEIDENTIFIER NOT NULL,
    [CreatedAt]    DATETIME2        NOT NULL,
    [UpdatedBy]    UNIQUEIDENTIFIER NULL,
    [UpdatedAt]    DATETIME2        NULL,
    [DeletedBy]    UNIQUEIDENTIFIER NULL,
    [DeletedAt]    DATETIME2        NULL,
    [IsActive]     BIT              NOT NULL CONSTRAINT [DF_Phone_IsActive] DEFAULT ((1)),
    CONSTRAINT [PK_Phone] PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [UQ_Phone_PersonNumber] UNIQUE NONCLUSTERED ([PersonId],[CountryId],[PhoneNumber])
);

CREATE NONCLUSTERED INDEX [IX_Phone_PersonId]  ON [dbo].[Phone]([PersonId]);
CREATE NONCLUSTERED INDEX [IX_Phone_LabelId]   ON [dbo].[Phone]([LabelId]);
CREATE NONCLUSTERED INDEX [IX_Phone_CountryId] ON [dbo].[Phone]([CountryId]);
CREATE NONCLUSTERED INDEX [IX_Phone_Number]    ON [dbo].[Phone]([PhoneNumber]);

ALTER TABLE [dbo].[Phone] ADD CONSTRAINT [FK_Phone_Person]
    FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person]([Id]) ON DELETE CASCADE;
ALTER TABLE [dbo].[Phone] ADD CONSTRAINT [FK_Phone_Label]
    FOREIGN KEY ([LabelId]) REFERENCES [dbo].[PhoneLabel]([Id]);

-- =====================================================================
-- 8. Relationship
-- =====================================================================
PRINT '=== Recreating Relationship ===';
DROP TABLE [dbo].[Relationship];

CREATE TABLE [dbo].[Relationship] (
    [Id]                  UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_Relationship_Id] DEFAULT (newsequentialid()),
    [PersonId]            UNIQUEIDENTIFIER NOT NULL,
    [RelatedPersonId]     UNIQUEIDENTIFIER NOT NULL,
    [RelationshipTypeId]  TINYINT          NOT NULL,
    [CreatedBy]           UNIQUEIDENTIFIER NOT NULL,
    [CreatedAt]           DATETIME2        NOT NULL,
    [UpdatedBy]           UNIQUEIDENTIFIER NULL,
    [UpdatedAt]           DATETIME2        NULL,
    [DeletedBy]           UNIQUEIDENTIFIER NULL,
    [DeletedAt]           DATETIME2        NULL,
    [IsActive]            BIT              NOT NULL CONSTRAINT [DF_Relationship_IsActive] DEFAULT ((1)),
    CONSTRAINT [PK_Relationship] PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [UQ_Relationship] UNIQUE NONCLUSTERED ([PersonId],[RelatedPersonId],[RelationshipTypeId]),
    CONSTRAINT [CK_Relationship_NoSelf] CHECK ([PersonId] <> [RelatedPersonId])
);

CREATE NONCLUSTERED INDEX [IX_Relationship_PersonId]        ON [dbo].[Relationship]([PersonId]);
CREATE NONCLUSTERED INDEX [IX_Relationship_RelatedPersonId] ON [dbo].[Relationship]([RelatedPersonId]);
CREATE NONCLUSTERED INDEX [IX_Relationship_Type]            ON [dbo].[Relationship]([RelationshipTypeId]);

ALTER TABLE [dbo].[Relationship] ADD CONSTRAINT [FK_Relationship_Person]
    FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person]([Id]) ON DELETE CASCADE;
ALTER TABLE [dbo].[Relationship] ADD CONSTRAINT [FK_Relationship_RelatedPerson]
    FOREIGN KEY ([RelatedPersonId]) REFERENCES [dbo].[Person]([Id]);
ALTER TABLE [dbo].[Relationship] ADD CONSTRAINT [FK_Relationship_Type]
    FOREIGN KEY ([RelationshipTypeId]) REFERENCES [dbo].[RelationshipType]([Id]);

-- =====================================================================
-- 9. Status
-- =====================================================================
PRINT '=== Recreating Status ===';
DROP TABLE [dbo].[Status];

CREATE TABLE [dbo].[Status] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [PersonId]   UNIQUEIDENTIFIER NOT NULL,
    [StartDate]  DATE             NOT NULL,
    [EndDate]    DATE             NULL,
    [CreatedBy]  UNIQUEIDENTIFIER NOT NULL,
    [CreatedAt]  DATETIME2        NOT NULL,
    [UpdatedBy]  UNIQUEIDENTIFIER NULL,
    [UpdatedAt]  DATETIME2        NULL,
    [DeletedBy]  UNIQUEIDENTIFIER NULL,
    [DeletedAt]  DATETIME2        NULL,
    [IsActive]   BIT              NOT NULL CONSTRAINT [DF_Status_IsActive] DEFAULT ((1)),
    CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED ([Id])
);

CREATE NONCLUSTERED INDEX [IX_Status_PersonId] ON [dbo].[Status]([PersonId]);

ALTER TABLE [dbo].[Status] ADD CONSTRAINT [FK_Status_Person]
    FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person]([Id]) ON DELETE CASCADE;

PRINT '=== All 9 tables successfully recreated ===';

COMMIT TRANSACTION;
GO

-- =====================================================================
-- Verification: confirm column order
-- =====================================================================
PRINT '=== VERIFICATION: column order ===';
SELECT TABLE_NAME, ORDINAL_POSITION, COLUMN_NAME, DATA_TYPE, IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME IN ('Address','Document','EducationDocument','Email',
                     'EmploymentDocument','Nationality','Phone','Relationship','Status')
ORDER BY TABLE_NAME, ORDINAL_POSITION;

PRINT '=== VERIFICATION: row counts (should all be 0) ===';
SELECT 'Address' AS T, COUNT_BIG(*) AS Cnt FROM [dbo].[Address] UNION ALL
SELECT 'Document', COUNT_BIG(*) FROM [dbo].[Document] UNION ALL
SELECT 'EducationDocument', COUNT_BIG(*) FROM [dbo].[EducationDocument] UNION ALL
SELECT 'Email', COUNT_BIG(*) FROM [dbo].[Email] UNION ALL
SELECT 'EmploymentDocument', COUNT_BIG(*) FROM [dbo].[EmploymentDocument] UNION ALL
SELECT 'Nationality', COUNT_BIG(*) FROM [dbo].[Nationality] UNION ALL
SELECT 'Phone', COUNT_BIG(*) FROM [dbo].[Phone] UNION ALL
SELECT 'Relationship', COUNT_BIG(*) FROM [dbo].[Relationship] UNION ALL
SELECT 'Status', COUNT_BIG(*) FROM [dbo].[Status];

PRINT '=== VERIFICATION: FKs ===';
SELECT fk.name AS FKName,
       OBJECT_NAME(fk.parent_object_id) AS ParentTable,
       OBJECT_NAME(fk.referenced_object_id) AS RefTable
FROM sys.foreign_keys fk
WHERE OBJECT_NAME(fk.parent_object_id) IN ('Address','Document','EducationDocument','Email',
                                           'EmploymentDocument','Nationality','Phone','Relationship','Status')
   OR OBJECT_NAME(fk.referenced_object_id) IN ('Address','Document','EducationDocument','Email',
                                               'EmploymentDocument','Nationality','Phone','Relationship','Status')
ORDER BY ParentTable, FKName;
GO
