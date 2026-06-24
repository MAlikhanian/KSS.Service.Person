-- 013_seed_viewer_role_access.sql
--
-- Seeds global RoleAccess rows for PersonViewer so that role sees every
-- person in read-only mode. Pattern mirrors migration 012 which seeded
-- SuperAdmin + PersonAdmin at Level=2; this seeds PersonViewer at Level=1.
--
-- 4 rows: PersonId=NULL, GrantedToRoleId=PersonViewer, Level=1, one per section
-- (Information, Assets, Access, Security).
--
-- Companion to Auth migration 011 which creates the PersonViewer role.
--
-- Apply to KSS_Person_Prod and KSS_Person_Dev.

SET QUOTED_IDENTIFIER ON;
SET NOCOUNT ON;
SET XACT_ABORT ON;

DECLARE @system UNIQUEIDENTIFIER = '00000000-0000-0000-0000-000000000001';
DECLARE @now DATETIME2 = SYSUTCDATETIME();

DECLARE @authDb SYSNAME =
    CASE WHEN DB_NAME() = 'KSS_Person_Prod' THEN N'KSS_Auth_Prod'
         ELSE N'KSS_Auth_Dev'
    END;
DECLARE @sql NVARCHAR(MAX);

BEGIN TRANSACTION;

-- Resolve PersonViewer role Id from Auth DB
DECLARE @personViewerId UNIQUEIDENTIFIER;
SET @sql = N'SELECT @id = Id FROM ' + QUOTENAME(@authDb) + N'.dbo.[Role] WHERE Code = ''PersonViewer''';
EXEC sp_executesql @sql, N'@id UNIQUEIDENTIFIER OUTPUT', @id = @personViewerId OUTPUT;

IF @personViewerId IS NULL
    THROW 51050, 'PersonViewer role not found in Auth DB — run Auth migration 011 first', 1;

-- Insert 4 RoleAccess rows (1 per section) at Level=1 (View) — idempotent
INSERT INTO dbo.RoleAccess (Id, PersonId, GrantedToRoleId, SectionId, Level, CreatedBy, CreatedAt)
SELECT NEWID(), NULL, @personViewerId, s.SectionId, 1, @system, @now
FROM (VALUES (1), (2), (3), (4)) AS s(SectionId)
WHERE NOT EXISTS (
    SELECT 1 FROM dbo.RoleAccess ra
    WHERE ra.GrantedToRoleId = @personViewerId
      AND ra.PersonId IS NULL
      AND ra.SectionId = s.SectionId
);

COMMIT TRANSACTION;

SELECT ra.GrantedToRoleId, ra.SectionId, ra.Level, ra.PersonId
FROM dbo.RoleAccess ra
WHERE ra.GrantedToRoleId = @personViewerId
ORDER BY ra.SectionId;

PRINT '013_seed_viewer_role_access.sql applied successfully.';
