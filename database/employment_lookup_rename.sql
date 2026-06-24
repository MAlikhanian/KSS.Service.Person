-- =====================================================================
-- employment_lookup_rename.sql  (PROD)
-- =====================================================================
-- Run ONLY in lockstep with the prod deploy of the renamed Person
-- service. Running this before the new code is live WILL BREAK PROD
-- (the old code still references the old table/column names).
--
-- This renames the Business* / JobPosition* lookup tables and their
-- Employment FK columns to the Employment* naming, and drops the
-- unused Job* lookup sets (JobCategory / JobDepartment / JobTitle).
--
-- sp_rename preserves all rows, PKs, FKs, and indexes.
-- The DROP block is GUARDED: it only runs if all six target tables
-- are empty (0 rows). If any holds data, the script RAISERRORs and
-- aborts BEFORE dropping anything.
--
-- Target DB: KSS_Person_Prod
-- =====================================================================

SET XACT_ABORT ON;
SET NOCOUNT ON;

-- ---------------------------------------------------------------------
-- STEP 1 — RENAMES
-- ---------------------------------------------------------------------
EXEC sp_rename 'dbo.BusinessSector','EmploymentActivityField';
EXEC sp_rename 'dbo.BusinessSectorTranslation','EmploymentActivityFieldTranslation';
EXEC sp_rename 'dbo.BusinessUnit','EmploymentActivityUnit';
EXEC sp_rename 'dbo.BusinessUnitTranslation','EmploymentActivityUnitTranslation';
EXEC sp_rename 'dbo.JobPosition','EmploymentPosition';
EXEC sp_rename 'dbo.JobPositionTranslation','EmploymentPositionTranslation';

EXEC sp_rename 'dbo.EmploymentActivityFieldTranslation.BusinessSectorId','EmploymentActivityFieldId','COLUMN';
EXEC sp_rename 'dbo.EmploymentActivityUnitTranslation.BusinessUnitId','EmploymentActivityUnitId','COLUMN';
EXEC sp_rename 'dbo.EmploymentPositionTranslation.JobPositionId','EmploymentPositionId','COLUMN';
EXEC sp_rename 'dbo.Employment.BusinessSectorId','EmploymentActivityFieldId','COLUMN';
EXEC sp_rename 'dbo.Employment.BusinessUnitId','EmploymentActivityUnitId','COLUMN';
EXEC sp_rename 'dbo.Employment.JobPositionId','EmploymentPositionId','COLUMN';
GO

-- ---------------------------------------------------------------------
-- STEP 2 — 0-ROW SAFETY GUARD (abort the drops if any table has data)
-- ---------------------------------------------------------------------
DECLARE @cnt INT =
    (SELECT COUNT(*) FROM dbo.JobCategory)
  + (SELECT COUNT(*) FROM dbo.JobCategoryTranslation)
  + (SELECT COUNT(*) FROM dbo.JobDepartment)
  + (SELECT COUNT(*) FROM dbo.JobDepartmentTranslation)
  + (SELECT COUNT(*) FROM dbo.JobTitle)
  + (SELECT COUNT(*) FROM dbo.JobTitleTranslation);

IF @cnt <> 0
BEGIN
    RAISERROR('ABORT: one or more Job* lookup tables are not empty (%d rows total). No tables were dropped. Investigate before dropping.', 16, 1, @cnt);
    RETURN;
END
GO

-- ---------------------------------------------------------------------
-- STEP 3 — DROP unused Job* lookup sets (only reached if guard passed)
-- Order respects FKs: translations/children first, then parents.
-- NOTE: JobDepartment has a FK to JobCategory (FK_JobDepartment_JobCategory),
-- so JobDepartment MUST be dropped before JobCategory.
-- ---------------------------------------------------------------------
DROP TABLE dbo.JobTitleTranslation;
DROP TABLE dbo.JobTitle;
DROP TABLE dbo.JobDepartmentTranslation;
DROP TABLE dbo.JobCategoryTranslation;
DROP TABLE dbo.JobDepartment;
DROP TABLE dbo.JobCategory;
GO
