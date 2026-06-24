-- 005_lookup_audit_and_isactive_PROD.sql
--
-- Adds 6 audit columns (CreatedBy, CreatedAt, UpdatedBy, UpdatedAt, DeletedBy, DeletedAt)
-- to all 48 lookup tables in KSS_Person_Prod (24 parents + 24 translations),
-- plus IsActive at the END of each PARENT lookup (translations follow the parent
-- and don't get their own IsActive).
--
-- 7 parent tables already had IsActive in the middle (AccessPermissionLevel,
-- AccessStatus, MaritalStatus, EducationLevel, FieldOfStudy, DocumentTypes,
-- Institution). For those, the existing column is dropped (after saving its
-- value to a temporary 'IsActive_legacy' staging column), the audit cols are
-- added in Step B, then IsActive is re-added at the end in Step C and the
-- value restored from the legacy column.
--
-- DocumentTypes (legacy datetime CreatedAt) and Institution (datetime2 CreatedAt)
-- have their legacy CreatedAt dropped — Step B adds the standard datetime2 one.
--
-- Existing seed rows are backfilled with CreatedBy='00000000-0000-0000-0000-000000000001'
-- (synthetic system Guid) and CreatedAt=SYSUTCDATETIME().
--
-- Apply ONLY to KSS_Person_Prod (per user instruction).

SET QUOTED_IDENTIFIER ON;
SET NOCOUNT ON;

DECLARE @system_user UNIQUEIDENTIFIER = '00000000-0000-0000-0000-000000000001';
DECLARE @now DATETIME2 = SYSUTCDATETIME();
DECLARE @sql NVARCHAR(MAX);
DECLARE @tbl SYSNAME;
DECLARE @hasLegacyCA BIT;

BEGIN TRANSACTION;

-- ── Step A: Stage and drop legacy IsActive (and legacy CreatedAt for 2 tables)
DECLARE @legacy TABLE (TableName SYSNAME, DropLegacyCreatedAt BIT);
INSERT INTO @legacy VALUES
    ('AccessPermissionLevel', 0),
    ('AccessStatus',          0),
    ('MaritalStatus',         0),
    ('EducationLevel',        0),
    ('FieldOfStudy',          0),
    ('DocumentTypes',         1),
    ('Institution',           1);

DECLARE curA CURSOR LOCAL FAST_FORWARD FOR SELECT TableName, DropLegacyCreatedAt FROM @legacy;
OPEN curA;
FETCH NEXT FROM curA INTO @tbl, @hasLegacyCA;
WHILE @@FETCH_STATUS = 0
BEGIN
    SET @sql = N'ALTER TABLE dbo.' + QUOTENAME(@tbl) + N' ADD IsActive_legacy BIT NULL;';
    EXEC sp_executesql @sql;

    SET @sql = N'UPDATE dbo.' + QUOTENAME(@tbl) + N' SET IsActive_legacy = IsActive;';
    EXEC sp_executesql @sql;

    -- Drop any default constraint on IsActive before dropping the column
    DECLARE @constraintName SYSNAME;
    SELECT @constraintName = dc.name
    FROM sys.default_constraints dc
    JOIN sys.columns c ON c.default_object_id = dc.object_id
    WHERE dc.parent_object_id = OBJECT_ID('dbo.' + @tbl)
      AND c.name = 'IsActive';
    IF @constraintName IS NOT NULL
    BEGIN
        SET @sql = N'ALTER TABLE dbo.' + QUOTENAME(@tbl) + N' DROP CONSTRAINT ' + QUOTENAME(@constraintName) + N';';
        EXEC sp_executesql @sql;
    END
    SET @constraintName = NULL;

    SET @sql = N'ALTER TABLE dbo.' + QUOTENAME(@tbl) + N' DROP COLUMN IsActive;';
    EXEC sp_executesql @sql;

    IF @hasLegacyCA = 1
    BEGIN
        -- Also drop any default on CreatedAt before dropping that column
        SELECT @constraintName = dc.name
        FROM sys.default_constraints dc
        JOIN sys.columns c ON c.default_object_id = dc.object_id
        WHERE dc.parent_object_id = OBJECT_ID('dbo.' + @tbl)
          AND c.name = 'CreatedAt';
        IF @constraintName IS NOT NULL
        BEGIN
            SET @sql = N'ALTER TABLE dbo.' + QUOTENAME(@tbl) + N' DROP CONSTRAINT ' + QUOTENAME(@constraintName) + N';';
            EXEC sp_executesql @sql;
        END
        SET @constraintName = NULL;

        SET @sql = N'ALTER TABLE dbo.' + QUOTENAME(@tbl) + N' DROP COLUMN CreatedAt;';
        EXEC sp_executesql @sql;
    END

    FETCH NEXT FROM curA INTO @tbl, @hasLegacyCA;
END
CLOSE curA;
DEALLOCATE curA;

-- ── Step B: Add 6 audit columns to all 48 tables
DECLARE @all_lookups TABLE (TableName SYSNAME);
INSERT INTO @all_lookups VALUES
    -- Parents (24)
    ('AccessPermissionLevel'),('AccessStatus'),('AddressLabel'),
    ('BirthCertificateSeriesLetter'),('BusinessSector'),('BusinessUnit'),
    ('ContractType'),('DocumentTypes'),('EducationLevel'),
    ('EmailLabel'),('FieldOfStudy'),('Institution'),
    ('InsuranceType'),('JobCategory'),('JobDepartment'),
    ('JobPosition'),('JobTitle'),('MaritalStatus'),
    ('MilitaryServiceLocation'),('MilitaryServiceStatus'),('PhoneLabel'),
    ('RelationshipType'),('Religion'),('Sex'),
    -- Translations (24)
    ('AccessPermissionLevelTranslation'),('AccessStatusTranslation'),('AddressLabelTranslation'),
    ('BirthCertificateSeriesLetterTranslation'),('BusinessSectorTranslation'),('BusinessUnitTranslation'),
    ('ContractTypeTranslation'),('DocumentTypeTranslations'),('EducationLevelTranslation'),
    ('EmailLabelTranslation'),('FieldOfStudyTranslation'),('InstitutionTranslation'),
    ('InsuranceTypeTranslation'),('JobCategoryTranslation'),('JobDepartmentTranslation'),
    ('JobPositionTranslation'),('JobTitleTranslation'),('MaritalStatusTranslation'),
    ('MilitaryServiceLocationTranslation'),('MilitaryServiceStatusTranslation'),('PhoneLabelTranslation'),
    ('RelationshipTypeTranslation'),('ReligionTranslation'),('SexTranslation');

DECLARE curB CURSOR LOCAL FAST_FORWARD FOR SELECT TableName FROM @all_lookups;
OPEN curB;
FETCH NEXT FROM curB INTO @tbl;
WHILE @@FETCH_STATUS = 0
BEGIN
    SET @sql = N'ALTER TABLE dbo.' + QUOTENAME(@tbl) + N' ADD '
        + N'CreatedBy UNIQUEIDENTIFIER NULL, '
        + N'CreatedAt DATETIME2 NULL, '
        + N'UpdatedBy UNIQUEIDENTIFIER NULL, '
        + N'UpdatedAt DATETIME2 NULL, '
        + N'DeletedBy UNIQUEIDENTIFIER NULL, '
        + N'DeletedAt DATETIME2 NULL;';
    EXEC sp_executesql @sql;

    SET @sql = N'UPDATE dbo.' + QUOTENAME(@tbl) + N' SET CreatedBy = @sysu, CreatedAt = @nowt;';
    EXEC sp_executesql @sql, N'@sysu UNIQUEIDENTIFIER, @nowt DATETIME2', @sysu = @system_user, @nowt = @now;

    SET @sql = N'ALTER TABLE dbo.' + QUOTENAME(@tbl) + N' ALTER COLUMN CreatedBy UNIQUEIDENTIFIER NOT NULL;';
    EXEC sp_executesql @sql;

    SET @sql = N'ALTER TABLE dbo.' + QUOTENAME(@tbl) + N' ALTER COLUMN CreatedAt DATETIME2 NOT NULL;';
    EXEC sp_executesql @sql;

    FETCH NEXT FROM curB INTO @tbl;
END
CLOSE curB;
DEALLOCATE curB;

-- ── Step C: Add IsActive at end for parent tables, restore legacy values
DECLARE @parents TABLE (TableName SYSNAME);
INSERT INTO @parents VALUES
    ('AccessPermissionLevel'),('AccessStatus'),('AddressLabel'),
    ('BirthCertificateSeriesLetter'),('BusinessSector'),('BusinessUnit'),
    ('ContractType'),('DocumentTypes'),('EducationLevel'),
    ('EmailLabel'),('FieldOfStudy'),('Institution'),
    ('InsuranceType'),('JobCategory'),('JobDepartment'),
    ('JobPosition'),('JobTitle'),('MaritalStatus'),
    ('MilitaryServiceLocation'),('MilitaryServiceStatus'),('PhoneLabel'),
    ('RelationshipType'),('Religion'),('Sex');

DECLARE curC CURSOR LOCAL FAST_FORWARD FOR SELECT TableName FROM @parents;
OPEN curC;
FETCH NEXT FROM curC INTO @tbl;
WHILE @@FETCH_STATUS = 0
BEGIN
    SET @sql = N'ALTER TABLE dbo.' + QUOTENAME(@tbl) + N' ADD IsActive BIT NOT NULL CONSTRAINT '
        + QUOTENAME(N'DF_' + @tbl + N'_IsActive') + N' DEFAULT 1;';
    EXEC sp_executesql @sql;

    -- If legacy IsActive existed for this table, copy value and drop staging col
    IF COL_LENGTH('dbo.' + @tbl, 'IsActive_legacy') IS NOT NULL
    BEGIN
        SET @sql = N'UPDATE dbo.' + QUOTENAME(@tbl) + N' SET IsActive = ISNULL(IsActive_legacy, 1);';
        EXEC sp_executesql @sql;

        SET @sql = N'ALTER TABLE dbo.' + QUOTENAME(@tbl) + N' DROP COLUMN IsActive_legacy;';
        EXEC sp_executesql @sql;
    END

    FETCH NEXT FROM curC INTO @tbl;
END
CLOSE curC;
DEALLOCATE curC;

COMMIT TRANSACTION;

PRINT '005_lookup_audit_and_isactive_PROD.sql applied successfully.';
