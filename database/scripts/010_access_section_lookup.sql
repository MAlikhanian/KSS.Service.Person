-- 010_access_section_lookup.sql
--
-- Normalize Access.Section into a lookup table:
--   * New AccessSection (parent lookup) + AccessSectionTranslation (child)
--   * Replace Access.Section varchar(20) with Access.SectionId tinyint FK
--   * Drop existing Access data (per user authorization — Prod is empty,
--     Dev has 3 test rows that will be re-created via UI as needed).
--
-- Run on KSS_Person_Prod and KSS_Person_Dev.

SET QUOTED_IDENTIFIER ON;
SET NOCOUNT ON;
SET XACT_ABORT ON;

DECLARE @system_user UNIQUEIDENTIFIER = '00000000-0000-0000-0000-000000000001';

BEGIN TRANSACTION;

-- ── Step 1: Drop existing Access data + table (Section column will be replaced)
DELETE FROM dbo.Access;
DROP TABLE dbo.Access;

-- ── Step 2: Create AccessSection (parent lookup)
CREATE TABLE dbo.AccessSection (
    Id          TINYINT          NOT NULL,
    Code        VARCHAR(20)      NOT NULL,
    CreatedBy   UNIQUEIDENTIFIER NOT NULL,
    CreatedAt   DATETIME2        NOT NULL,
    UpdatedBy   UNIQUEIDENTIFIER NULL,
    UpdatedAt   DATETIME2        NULL,
    DeletedBy   UNIQUEIDENTIFIER NULL,
    DeletedAt   DATETIME2        NULL,
    IsActive    BIT              NOT NULL CONSTRAINT DF_AccessSection_IsActive DEFAULT (1),
    CONSTRAINT PK_AccessSection PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT UQ_AccessSection_Code UNIQUE (Code)
);

INSERT INTO dbo.AccessSection (Id, Code, CreatedBy, CreatedAt, IsActive) VALUES
    (1, 'information', @system_user, SYSUTCDATETIME(), 1),
    (2, 'assets',      @system_user, SYSUTCDATETIME(), 1),
    (3, 'access',      @system_user, SYSUTCDATETIME(), 1);

-- ── Step 3: Create AccessSectionTranslation (child)
CREATE TABLE dbo.AccessSectionTranslation (
    AccessSectionId TINYINT          NOT NULL,
    LanguageId      SMALLINT         NOT NULL,
    Name            NVARCHAR(50)     NOT NULL,
    CreatedBy       UNIQUEIDENTIFIER NOT NULL,
    CreatedAt       DATETIME2        NOT NULL,
    UpdatedBy       UNIQUEIDENTIFIER NULL,
    UpdatedAt       DATETIME2        NULL,
    DeletedBy       UNIQUEIDENTIFIER NULL,
    DeletedAt       DATETIME2        NULL,
    CONSTRAINT PK_AccessSectionTranslation PRIMARY KEY CLUSTERED (AccessSectionId, LanguageId),
    CONSTRAINT FK_AccessSectionTranslation_AccessSection FOREIGN KEY (AccessSectionId)
        REFERENCES dbo.AccessSection(Id) ON DELETE CASCADE
);

INSERT INTO dbo.AccessSectionTranslation (AccessSectionId, LanguageId, Name, CreatedBy, CreatedAt) VALUES
    (1, 12, N'اطلاعات شخص', @system_user, SYSUTCDATETIME()),
    (1, 10, N'Information', @system_user, SYSUTCDATETIME()),
    (2, 12, N'دارایی‌ها',    @system_user, SYSUTCDATETIME()),
    (2, 10, N'Assets',       @system_user, SYSUTCDATETIME()),
    (3, 12, N'دسترسی‌ها',     @system_user, SYSUTCDATETIME()),
    (3, 10, N'Access',       @system_user, SYSUTCDATETIME());

-- ── Step 4: Recreate Access with SectionId tinyint FK
CREATE TABLE dbo.Access (
    Id                UNIQUEIDENTIFIER NOT NULL,
    PersonId          UNIQUEIDENTIFIER NOT NULL,
    GrantedToPersonId UNIQUEIDENTIFIER NOT NULL,
    SectionId         TINYINT          NOT NULL,
    Level             INT              NOT NULL,
    CreatedBy         UNIQUEIDENTIFIER NOT NULL,
    CreatedAt         DATETIME2        NOT NULL,
    UpdatedBy         UNIQUEIDENTIFIER NULL,
    UpdatedAt         DATETIME2        NULL,
    DeletedBy         UNIQUEIDENTIFIER NULL,
    DeletedAt         DATETIME2        NULL,
    IsActive          BIT              NOT NULL CONSTRAINT DF_Access_IsActive DEFAULT (1),
    CONSTRAINT PK_Access PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_Access_AccessSection FOREIGN KEY (SectionId) REFERENCES dbo.AccessSection(Id),
    CONSTRAINT UQ_Access UNIQUE (PersonId, GrantedToPersonId, SectionId)
);

COMMIT TRANSACTION;

PRINT '010_access_section_lookup.sql applied successfully.';
