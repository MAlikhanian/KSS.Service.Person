SET NOCOUNT ON;
SET XACT_ABORT ON;
-- backups
IF OBJECT_ID('dbo.EmploymentActivityUnit_PreRenumber') IS NOT NULL DROP TABLE dbo.EmploymentActivityUnit_PreRenumber;
SELECT * INTO dbo.EmploymentActivityUnit_PreRenumber FROM dbo.EmploymentActivityUnit;
IF OBJECT_ID('dbo.EmploymentActivityUnitTranslation_PreRenumber') IS NOT NULL DROP TABLE dbo.EmploymentActivityUnitTranslation_PreRenumber;
SELECT * INTO dbo.EmploymentActivityUnitTranslation_PreRenumber FROM dbo.EmploymentActivityUnitTranslation;
BEGIN TRY
  BEGIN TRAN;
  ALTER TABLE dbo.EmploymentActivityUnitTranslation DROP CONSTRAINT FK_EmploymentActivityUnitTranslation_EmploymentActivityUnit;
  CREATE TABLE dbo.EmploymentActivityUnit_new (
    Id smallint IDENTITY(1,1) NOT NULL,
    EmploymentActivityFieldId smallint NULL,
    Code varchar(20) NOT NULL,
    CreatedBy uniqueidentifier NOT NULL,
    CreatedAt datetime2 NOT NULL,
    UpdatedBy uniqueidentifier NULL,
    UpdatedAt datetime2 NULL,
    DeletedBy uniqueidentifier NULL,
    DeletedAt datetime2 NULL,
    IsActive bit NOT NULL CONSTRAINT DF_EmploymentActivityUnit_IsActive_tmp DEFAULT((1)),
    CONSTRAINT PK_EmploymentActivityUnit_tmp PRIMARY KEY CLUSTERED (Id)
  );
  SET IDENTITY_INSERT dbo.EmploymentActivityUnit_new ON;
  INSERT INTO dbo.EmploymentActivityUnit_new (Id,EmploymentActivityFieldId,Code,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,DeletedBy,DeletedAt,IsActive)
    SELECT Id-12, EmploymentActivityFieldId, Code, CreatedBy, CreatedAt, UpdatedBy, UpdatedAt, DeletedBy, DeletedAt, IsActive
    FROM dbo.EmploymentActivityUnit;
  SET IDENTITY_INSERT dbo.EmploymentActivityUnit_new OFF;
  -- repoint references (-12)
  UPDATE dbo.EmploymentActivityUnitTranslation SET EmploymentActivityUnitId = EmploymentActivityUnitId-12 WHERE EmploymentActivityUnitId BETWEEN 13 AND 27;
  UPDATE dbo.EmploymentPosition               SET EmploymentActivityUnitId = EmploymentActivityUnitId-12 WHERE EmploymentActivityUnitId BETWEEN 13 AND 27;
  UPDATE dbo.Employment                        SET EmploymentActivityUnitId = EmploymentActivityUnitId-12 WHERE EmploymentActivityUnitId BETWEEN 13 AND 27;
  -- swap
  DROP TABLE dbo.EmploymentActivityUnit;
  EXEC sp_rename 'dbo.EmploymentActivityUnit_new','EmploymentActivityUnit';
  EXEC sp_rename 'dbo.PK_EmploymentActivityUnit_tmp','PK_EmploymentActivityUnit','OBJECT';
  EXEC sp_rename 'dbo.DF_EmploymentActivityUnit_IsActive_tmp','DF_EmploymentActivityUnit_IsActive','OBJECT';
  ALTER TABLE dbo.EmploymentActivityUnitTranslation ADD CONSTRAINT FK_EmploymentActivityUnitTranslation_EmploymentActivityUnit
    FOREIGN KEY (EmploymentActivityUnitId) REFERENCES dbo.EmploymentActivityUnit(Id);
  COMMIT;
END TRY
BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH;
DECLARE @m int=(SELECT ISNULL(MAX(Id),0) FROM dbo.EmploymentActivityUnit); DBCC CHECKIDENT('dbo.EmploymentActivityUnit',RESEED,@m);
-- verify
SELECT MIN(Id) AS MinId, MAX(Id) AS MaxId, COUNT(*) AS Units FROM dbo.EmploymentActivityUnit;
SELECT 'emp_units_out_of_1_15' AS chk, COUNT(*) AS n FROM dbo.Employment WHERE EmploymentActivityUnitId NOT BETWEEN 1 AND 15
UNION ALL SELECT 'trans_orphan', COUNT(*) FROM dbo.EmploymentActivityUnitTranslation t WHERE NOT EXISTS (SELECT 1 FROM dbo.EmploymentActivityUnit u WHERE u.Id=t.EmploymentActivityUnitId);
SELECT u.Id, t.Name FROM dbo.EmploymentActivityUnit u LEFT JOIN dbo.EmploymentActivityUnitTranslation t ON t.EmploymentActivityUnitId=u.Id AND t.LanguageId=12 ORDER BY u.Id;
