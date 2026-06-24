-- 011_add_security_access_section.sql
--
-- Adds 'security' as a 4th per-person AccessSection (alongside information,
-- assets, access). Used by the /person/security page to gate view-only mode
-- the same way the other three section pages do.
--
-- Apply to KSS_Person_Prod and KSS_Person_Dev.

SET QUOTED_IDENTIFIER ON;
SET NOCOUNT ON;
SET XACT_ABORT ON;

DECLARE @system UNIQUEIDENTIFIER = '00000000-0000-0000-0000-000000000001';
DECLARE @now DATETIME2 = SYSUTCDATETIME();

BEGIN TRANSACTION;

IF NOT EXISTS (SELECT 1 FROM dbo.AccessSection WHERE Id = 4)
BEGIN
    INSERT INTO dbo.AccessSection (Id, Code, CreatedBy, CreatedAt, IsActive)
    VALUES (4, 'security', @system, @now, 1);
END

IF NOT EXISTS (SELECT 1 FROM dbo.AccessSectionTranslation WHERE AccessSectionId = 4 AND LanguageId = 12)
    INSERT INTO dbo.AccessSectionTranslation (AccessSectionId, LanguageId, Name, CreatedBy, CreatedAt)
    VALUES (4, 12, N'امنیت', @system, @now);

IF NOT EXISTS (SELECT 1 FROM dbo.AccessSectionTranslation WHERE AccessSectionId = 4 AND LanguageId = 10)
    INSERT INTO dbo.AccessSectionTranslation (AccessSectionId, LanguageId, Name, CreatedBy, CreatedAt)
    VALUES (4, 10, N'Security', @system, @now);

COMMIT TRANSACTION;

SELECT Id, Code FROM dbo.AccessSection ORDER BY Id;

PRINT '011_add_security_access_section.sql applied successfully.';
