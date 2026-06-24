-- 012_role_access.sql
--
-- Adds role-based row-level access. Mirrors the Access table but the grantee
-- is a Role instead of a Person. PersonId is NULLable — NULL means the grant
-- applies to ALL persons (current and future).
--
-- Effective level for a (caller, person, section) is:
--   max(Access row for caller, max RoleAccess row for any of caller's roles)
--   where RoleAccess.PersonId IS NULL (global) or PersonId = target.
--
-- Seeds: SuperAdmin + PersonAdmin roles get global Edit (Level=2) on all 4
-- sections — i.e., they automatically see and can edit every Person.
--
-- Role Ids are cross-DB (KSS_Auth.dbo.Role); resolved by Code at migration
-- time so Dev/Prod environments stay correct even when their Role Ids differ.
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

-- ── Step 1: Create RoleAccess table
CREATE TABLE dbo.RoleAccess (
    Id                UNIQUEIDENTIFIER NOT NULL,
    PersonId          UNIQUEIDENTIFIER NULL,
    GrantedToRoleId   UNIQUEIDENTIFIER NOT NULL,
    SectionId         TINYINT          NOT NULL,
    Level             INT              NOT NULL,
    CreatedBy         UNIQUEIDENTIFIER NOT NULL,
    CreatedAt         DATETIME2        NOT NULL,
    UpdatedBy         UNIQUEIDENTIFIER NULL,
    UpdatedAt         DATETIME2        NULL,
    DeletedBy         UNIQUEIDENTIFIER NULL,
    DeletedAt         DATETIME2        NULL,
    IsActive          BIT              NOT NULL CONSTRAINT DF_RoleAccess_IsActive DEFAULT (1),
    CONSTRAINT PK_RoleAccess PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_RoleAccess_AccessSection FOREIGN KEY (SectionId)
        REFERENCES dbo.AccessSection(Id),
    CONSTRAINT CK_RoleAccess_Level CHECK (Level BETWEEN 0 AND 2)
);

-- Filtered unique indexes — handle the NULL PersonId case (global grants)
-- separately from per-person grants.
CREATE UNIQUE NONCLUSTERED INDEX UQ_RoleAccess_PerPerson
    ON dbo.RoleAccess (PersonId, GrantedToRoleId, SectionId)
    WHERE PersonId IS NOT NULL;

CREATE UNIQUE NONCLUSTERED INDEX UQ_RoleAccess_Global
    ON dbo.RoleAccess (GrantedToRoleId, SectionId)
    WHERE PersonId IS NULL;

CREATE NONCLUSTERED INDEX IX_RoleAccess_PersonId  ON dbo.RoleAccess (PersonId);
CREATE NONCLUSTERED INDEX IX_RoleAccess_RoleId    ON dbo.RoleAccess (GrantedToRoleId);

-- ── Step 2: Resolve SuperAdmin + PersonAdmin role Ids from Auth DB
DECLARE @superAdminId UNIQUEIDENTIFIER;
DECLARE @personAdminId UNIQUEIDENTIFIER;

SET @sql = N'SELECT @sa = (SELECT Id FROM ' + QUOTENAME(@authDb) + N'.dbo.[Role] WHERE Code = ''SuperAdmin''),
                  @pa = (SELECT Id FROM ' + QUOTENAME(@authDb) + N'.dbo.[Role] WHERE Code = ''PersonAdmin'')';
EXEC sp_executesql @sql,
    N'@sa UNIQUEIDENTIFIER OUTPUT, @pa UNIQUEIDENTIFIER OUTPUT',
    @sa = @superAdminId OUTPUT, @pa = @personAdminId OUTPUT;

IF @superAdminId IS NULL OR @personAdminId IS NULL
BEGIN
    THROW 51020, 'SuperAdmin or PersonAdmin role not found in Auth DB', 1;
END

-- ── Step 3: Seed global Edit grants for SuperAdmin + PersonAdmin
-- 2 roles × 4 sections (Information=1, Assets=2, Access=3, Security=4) × Level=2 (Edit)
-- All with PersonId = NULL (applies to every person, current and future).
INSERT INTO dbo.RoleAccess (Id, PersonId, GrantedToRoleId, SectionId, Level, CreatedBy, CreatedAt) VALUES
    (NEWID(), NULL, @superAdminId,  1, 2, @system, @now),
    (NEWID(), NULL, @superAdminId,  2, 2, @system, @now),
    (NEWID(), NULL, @superAdminId,  3, 2, @system, @now),
    (NEWID(), NULL, @superAdminId,  4, 2, @system, @now),
    (NEWID(), NULL, @personAdminId, 1, 2, @system, @now),
    (NEWID(), NULL, @personAdminId, 2, 2, @system, @now),
    (NEWID(), NULL, @personAdminId, 3, 2, @system, @now),
    (NEWID(), NULL, @personAdminId, 4, 2, @system, @now);

COMMIT TRANSACTION;

SELECT 'role_access', COUNT(*) FROM dbo.RoleAccess;
SELECT GrantedToRoleId, SectionId, Level, PersonId FROM dbo.RoleAccess ORDER BY GrantedToRoleId, SectionId;

PRINT '012_role_access.sql applied successfully.';
