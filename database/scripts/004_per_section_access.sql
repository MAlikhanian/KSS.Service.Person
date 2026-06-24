-- Migration: 004_per_section_access.sql
-- Switches the Access table from a single AccessLevel column to per-section
-- (Section, Level) pairs. Each (PersonId, GrantedToPersonId, Section) triple
-- gets its own Level (0=None, 1=View, 2=Edit). Sections are 'information',
-- 'assets' and 'access'.
--
-- The user has confirmed it's OK to clear the Access table — only 1 test row
-- exists. Existing rows are wiped before the schema change.
--
-- The script is idempotent: each step checks state before applying.

SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

-- 1. Wipe existing rows (only test data).
DELETE FROM dbo.Access;
GO

-- 2. Drop the old single-level column.
IF COL_LENGTH('dbo.Access', 'AccessLevel') IS NOT NULL
    ALTER TABLE dbo.Access DROP COLUMN AccessLevel;
GO

-- 3. Add per-section columns.
IF COL_LENGTH('dbo.Access', 'Section') IS NULL
    ALTER TABLE dbo.Access ADD Section VARCHAR(20) NOT NULL;
GO
IF COL_LENGTH('dbo.Access', 'Level') IS NULL
    ALTER TABLE dbo.Access ADD [Level] INT NOT NULL;
GO

-- 4. Drop the old (PersonId, GrantedToPersonId) unique index/constraint.
--    Wrapped in a single batch so the variable lives until EXEC fires.
DECLARE @uxName SYSNAME;
DECLARE @sql NVARCHAR(MAX);

-- 4a. Drop unique constraint (if it's a constraint).
SELECT @uxName = kc.name
FROM sys.key_constraints kc
WHERE kc.parent_object_id = OBJECT_ID('dbo.Access')
  AND kc.type = 'UQ';

IF @uxName IS NOT NULL
BEGIN
    SET @sql = N'ALTER TABLE dbo.Access DROP CONSTRAINT ' + QUOTENAME(@uxName);
    EXEC sp_executesql @sql;
END;

-- 4b. Drop any leftover non-PK unique INDEX whose key is NOT (PersonId, GrantedToPersonId, Section).
--     We re-create UQ_Access at step 5, so anything else is stale.
DECLARE idx_cur CURSOR LOCAL FAST_FORWARD FOR
    SELECT i.name
    FROM sys.indexes i
    WHERE i.object_id = OBJECT_ID('dbo.Access')
      AND i.is_unique = 1
      AND i.is_primary_key = 0
      AND i.name <> 'UQ_Access';

OPEN idx_cur;
FETCH NEXT FROM idx_cur INTO @uxName;
WHILE @@FETCH_STATUS = 0
BEGIN
    SET @sql = N'DROP INDEX ' + QUOTENAME(@uxName) + N' ON dbo.Access';
    EXEC sp_executesql @sql;
    FETCH NEXT FROM idx_cur INTO @uxName;
END;
CLOSE idx_cur;
DEALLOCATE idx_cur;
GO

-- 5. New unique constraint including Section.
IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = 'UQ_Access' AND object_id = OBJECT_ID('dbo.Access')
)
    ALTER TABLE dbo.Access
        ADD CONSTRAINT UQ_Access UNIQUE (PersonId, GrantedToPersonId, Section);
GO

PRINT 'Migration 004_per_section_access.sql completed.';
GO
