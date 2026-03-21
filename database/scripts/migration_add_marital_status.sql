-- Migration: Replace IsMarried (BIT) with MaritalStatusId (TINYINT) lookup table
-- Database: KSS_Person_Prod / KSS_Person_Dev

USE [KSS_Person_Dev];
GO

-- 1) Create MaritalStatus lookup table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'MaritalStatus' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE [dbo].[MaritalStatus] (
        [Id]   TINYINT      IDENTITY(1,1) NOT NULL,
        [Code] VARCHAR(10)  NOT NULL,
        CONSTRAINT [PK_MaritalStatus] PRIMARY KEY CLUSTERED ([Id])
    );
END
GO

-- 2) Create MaritalStatusTranslation table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'MaritalStatusTranslation' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE [dbo].[MaritalStatusTranslation] (
        [MaritalStatusId] TINYINT       NOT NULL,
        [LanguageId]      SMALLINT      NOT NULL,
        [Name]            NVARCHAR(20)  NOT NULL,
        CONSTRAINT [PK_MaritalStatusTranslation] PRIMARY KEY CLUSTERED ([MaritalStatusId], [LanguageId]),
        CONSTRAINT [FK_MaritalStatusTranslation_MaritalStatus] FOREIGN KEY ([MaritalStatusId]) REFERENCES [dbo].[MaritalStatus]([Id]) ON DELETE CASCADE
    );
END
GO

-- 3) Seed data
IF NOT EXISTS (SELECT 1 FROM [dbo].[MaritalStatus])
BEGIN
    SET IDENTITY_INSERT [dbo].[MaritalStatus] ON;
    INSERT INTO [dbo].[MaritalStatus] ([Id], [Code]) VALUES (1, 'Single');
    INSERT INTO [dbo].[MaritalStatus] ([Id], [Code]) VALUES (2, 'Married');
    INSERT INTO [dbo].[MaritalStatus] ([Id], [Code]) VALUES (3, 'Divorced');
    INSERT INTO [dbo].[MaritalStatus] ([Id], [Code]) VALUES (4, 'Widowed');
    SET IDENTITY_INSERT [dbo].[MaritalStatus] OFF;

    INSERT INTO [dbo].[MaritalStatusTranslation] ([MaritalStatusId], [LanguageId], [Name]) VALUES (1, 12, N'مجرد');
    INSERT INTO [dbo].[MaritalStatusTranslation] ([MaritalStatusId], [LanguageId], [Name]) VALUES (2, 12, N'متاهل');
    INSERT INTO [dbo].[MaritalStatusTranslation] ([MaritalStatusId], [LanguageId], [Name]) VALUES (3, 12, N'مطلقه');
    INSERT INTO [dbo].[MaritalStatusTranslation] ([MaritalStatusId], [LanguageId], [Name]) VALUES (4, 12, N'بیوه');
    INSERT INTO [dbo].[MaritalStatusTranslation] ([MaritalStatusId], [LanguageId], [Name]) VALUES (1, 1, N'Single');
    INSERT INTO [dbo].[MaritalStatusTranslation] ([MaritalStatusId], [LanguageId], [Name]) VALUES (2, 1, N'Married');
    INSERT INTO [dbo].[MaritalStatusTranslation] ([MaritalStatusId], [LanguageId], [Name]) VALUES (3, 1, N'Divorced');
    INSERT INTO [dbo].[MaritalStatusTranslation] ([MaritalStatusId], [LanguageId], [Name]) VALUES (4, 1, N'Widowed');
END
GO

-- 4) Add MaritalStatusId column to Person (migrate from IsMarried)
IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.Person') AND name = 'IsMarried')
   AND NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.Person') AND name = 'MaritalStatusId')
BEGIN
    -- Add new column with default 1 (Single)
    ALTER TABLE [dbo].[Person] ADD [MaritalStatusId] TINYINT NOT NULL CONSTRAINT DF_Person_MaritalStatusId DEFAULT 1;

    -- Migrate data: IsMarried=1 -> MaritalStatusId=2 (Married), IsMarried=0 -> MaritalStatusId=1 (Single)
    UPDATE [dbo].[Person] SET [MaritalStatusId] = CASE WHEN [IsMarried] = 1 THEN 2 ELSE 1 END;

    -- Add FK constraint
    ALTER TABLE [dbo].[Person] ADD CONSTRAINT [FK_Person_MaritalStatus] FOREIGN KEY ([MaritalStatusId]) REFERENCES [dbo].[MaritalStatus]([Id]);

    -- Drop old column and its default constraint
    DECLARE @ConstraintName NVARCHAR(256);
    SELECT @ConstraintName = d.name
    FROM sys.default_constraints d
    JOIN sys.columns c ON d.parent_column_id = c.column_id AND d.parent_object_id = c.object_id
    WHERE c.object_id = OBJECT_ID('dbo.Person') AND c.name = 'IsMarried';

    IF @ConstraintName IS NOT NULL
        EXEC('ALTER TABLE [dbo].[Person] DROP CONSTRAINT [' + @ConstraintName + ']');

    ALTER TABLE [dbo].[Person] DROP COLUMN [IsMarried];
END
GO
