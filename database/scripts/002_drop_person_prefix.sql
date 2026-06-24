-- Migration: 002_drop_person_prefix.sql
-- Drops the "Person" prefix from child entities of the Person aggregate root.
-- The root Person table itself is unchanged.
--
-- Tables renamed:
--   PersonTranslation -> Translation
--   PersonAccess      -> Access
--   PersonStatus      -> Status
--   PersonNationality -> Nationality
--
-- Indexes, primary-key constraints, foreign-key constraints and triggers
-- whose names embed the old table name are also renamed for consistency.
--
-- All renames use sp_rename so data is preserved.

SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

----------------------------------------------------------------------
-- 1. Tables
----------------------------------------------------------------------
IF OBJECT_ID(N'dbo.PersonTranslation', 'U') IS NOT NULL
    EXEC sp_rename N'dbo.PersonTranslation', N'Translation';
GO
IF OBJECT_ID(N'dbo.PersonAccess', 'U') IS NOT NULL
    EXEC sp_rename N'dbo.PersonAccess', N'Access';
GO
IF OBJECT_ID(N'dbo.PersonStatus', 'U') IS NOT NULL
    EXEC sp_rename N'dbo.PersonStatus', N'Status';
GO
IF OBJECT_ID(N'dbo.PersonNationality', 'U') IS NOT NULL
    EXEC sp_rename N'dbo.PersonNationality', N'Nationality';
GO

----------------------------------------------------------------------
-- 2. Primary key constraints
----------------------------------------------------------------------
IF EXISTS (SELECT 1 FROM sys.objects WHERE name = N'PK_PersonTranslation' AND type = 'PK')
    EXEC sp_rename N'dbo.PK_PersonTranslation', N'PK_Translation', N'OBJECT';
GO
IF EXISTS (SELECT 1 FROM sys.objects WHERE name = N'PK_PersonAccess' AND type = 'PK')
    EXEC sp_rename N'dbo.PK_PersonAccess', N'PK_Access', N'OBJECT';
GO
IF EXISTS (SELECT 1 FROM sys.objects WHERE name = N'PK_PersonStatus' AND type = 'PK')
    EXEC sp_rename N'dbo.PK_PersonStatus', N'PK_Status', N'OBJECT';
GO
-- PersonNationality PK is system-generated (PK__PersonNa__...). Leave alone.

----------------------------------------------------------------------
-- 3. Other indexes / unique constraints
----------------------------------------------------------------------
IF EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'UX_PersonAccess_Person_GrantedTo' AND object_id = OBJECT_ID(N'dbo.Access'))
    EXEC sp_rename N'dbo.Access.UX_PersonAccess_Person_GrantedTo', N'UX_Access_Person_GrantedTo', N'INDEX';
GO
IF EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_PersonStatus_PersonId' AND object_id = OBJECT_ID(N'dbo.Status'))
    EXEC sp_rename N'dbo.Status.IX_PersonStatus_PersonId', N'IX_Status_PersonId', N'INDEX';
GO
IF EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_PersonTranslation_LanguageId' AND object_id = OBJECT_ID(N'dbo.Translation'))
    EXEC sp_rename N'dbo.Translation.IX_PersonTranslation_LanguageId', N'IX_Translation_LanguageId', N'INDEX';
GO
IF EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'UQ_PersonNationality_PersonId_CountryId' AND object_id = OBJECT_ID(N'dbo.Nationality'))
    EXEC sp_rename N'dbo.Nationality.UQ_PersonNationality_PersonId_CountryId', N'UQ_Nationality_PersonId_CountryId', N'INDEX';
GO

----------------------------------------------------------------------
-- 4. Foreign-key constraints
----------------------------------------------------------------------
IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = N'FK_PersonTranslation_Person')
    EXEC sp_rename N'dbo.FK_PersonTranslation_Person', N'FK_Translation_Person', N'OBJECT';
GO
IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = N'FK_PersonStatus_Person')
    EXEC sp_rename N'dbo.FK_PersonStatus_Person', N'FK_Status_Person', N'OBJECT';
GO
IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = N'FK_PersonNationality_Person')
    EXEC sp_rename N'dbo.FK_PersonNationality_Person', N'FK_Nationality_Person', N'OBJECT';
GO

----------------------------------------------------------------------
-- 5. Triggers
----------------------------------------------------------------------
IF EXISTS (SELECT 1 FROM sys.triggers WHERE name = N'TR_PersonTranslation_DisplayName')
    EXEC sp_rename N'dbo.TR_PersonTranslation_DisplayName', N'TR_Translation_DisplayName', N'OBJECT';
GO

PRINT 'Migration 002_drop_person_prefix.sql completed.';
GO
