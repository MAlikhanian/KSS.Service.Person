SET NOCOUNT ON;
SET XACT_ABORT ON;
IF OBJECT_ID('dbo.EmploymentPosition_PreRenumber') IS NOT NULL DROP TABLE dbo.EmploymentPosition_PreRenumber;
SELECT * INTO dbo.EmploymentPosition_PreRenumber FROM dbo.EmploymentPosition;
IF OBJECT_ID('dbo.EmploymentPositionTranslation_PreRenumber') IS NOT NULL DROP TABLE dbo.EmploymentPositionTranslation_PreRenumber;
SELECT * INTO dbo.EmploymentPositionTranslation_PreRenumber FROM dbo.EmploymentPositionTranslation;
BEGIN TRY
  BEGIN TRAN;
  ALTER TABLE dbo.EmploymentPositionTranslation DROP CONSTRAINT FK_EmploymentPositionTranslation_EmploymentPosition;
  CREATE TABLE dbo.EmploymentPosition_new (
    Id smallint IDENTITY(1,1) NOT NULL,
    EmploymentActivityUnitId smallint NULL,
    Code varchar(20) NOT NULL,
    CreatedBy uniqueidentifier NOT NULL,
    CreatedAt datetime2 NOT NULL,
    UpdatedBy uniqueidentifier NULL,
    UpdatedAt datetime2 NULL,
    DeletedBy uniqueidentifier NULL,
    DeletedAt datetime2 NULL,
    IsActive bit NOT NULL CONSTRAINT DF_EmploymentPosition_IsActive_tmp DEFAULT((1)),
    CONSTRAINT PK_EmploymentPosition_tmp PRIMARY KEY CLUSTERED (Id)
  );
  SET IDENTITY_INSERT dbo.EmploymentPosition_new ON;
  INSERT INTO dbo.EmploymentPosition_new (Id,EmploymentActivityUnitId,Code,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,DeletedBy,DeletedAt,IsActive)
    SELECT Id-18, EmploymentActivityUnitId, Code, CreatedBy, CreatedAt, UpdatedBy, UpdatedAt, DeletedBy, DeletedAt, IsActive
    FROM dbo.EmploymentPosition;
  SET IDENTITY_INSERT dbo.EmploymentPosition_new OFF;
  UPDATE dbo.EmploymentPositionTranslation SET EmploymentPositionId = EmploymentPositionId-18 WHERE EmploymentPositionId BETWEEN 19 AND 92;
  UPDATE dbo.Employment SET EmploymentPositionId = EmploymentPositionId-18 WHERE EmploymentPositionId BETWEEN 19 AND 92;
  DROP TABLE dbo.EmploymentPosition;
  EXEC sp_rename 'dbo.EmploymentPosition_new','EmploymentPosition';
  EXEC sp_rename 'dbo.PK_EmploymentPosition_tmp','PK_EmploymentPosition','OBJECT';
  EXEC sp_rename 'dbo.DF_EmploymentPosition_IsActive_tmp','DF_EmploymentPosition_IsActive','OBJECT';
  ALTER TABLE dbo.EmploymentPositionTranslation ADD CONSTRAINT FK_EmploymentPositionTranslation_EmploymentPosition
    FOREIGN KEY (EmploymentPositionId) REFERENCES dbo.EmploymentPosition(Id);
  COMMIT;
END TRY
BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH;
DECLARE @m int=(SELECT ISNULL(MAX(Id),0) FROM dbo.EmploymentPosition); DBCC CHECKIDENT('dbo.EmploymentPosition',RESEED,@m);
SELECT MIN(Id) AS MinId, MAX(Id) AS MaxId, COUNT(*) AS Positions FROM dbo.EmploymentPosition;
SELECT 'trans_orphan' AS chk, COUNT(*) AS n FROM dbo.EmploymentPositionTranslation t WHERE NOT EXISTS (SELECT 1 FROM dbo.EmploymentPosition p WHERE p.Id=t.EmploymentPositionId)
UNION ALL SELECT 'emp_refs_still_19_92', COUNT(*) FROM dbo.Employment WHERE EmploymentPositionId BETWEEN 19 AND 92;
