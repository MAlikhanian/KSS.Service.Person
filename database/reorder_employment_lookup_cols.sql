SET NOCOUNT ON;
SET XACT_ABORT ON;
-------------------- EmploymentActivityUnit --------------------
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
    SELECT Id,EmploymentActivityFieldId,Code,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,DeletedBy,DeletedAt,IsActive FROM dbo.EmploymentActivityUnit;
  SET IDENTITY_INSERT dbo.EmploymentActivityUnit_new OFF;
  DROP TABLE dbo.EmploymentActivityUnit;
  EXEC sp_rename 'dbo.EmploymentActivityUnit_new','EmploymentActivityUnit';
  EXEC sp_rename 'dbo.PK_EmploymentActivityUnit_tmp','PK_EmploymentActivityUnit','OBJECT';
  EXEC sp_rename 'dbo.DF_EmploymentActivityUnit_IsActive_tmp','DF_EmploymentActivityUnit_IsActive','OBJECT';
  ALTER TABLE dbo.EmploymentActivityUnitTranslation ADD CONSTRAINT FK_EmploymentActivityUnitTranslation_EmploymentActivityUnit
    FOREIGN KEY (EmploymentActivityUnitId) REFERENCES dbo.EmploymentActivityUnit(Id);
  COMMIT;
END TRY
BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH;
DECLARE @m1 int=(SELECT ISNULL(MAX(Id),0) FROM dbo.EmploymentActivityUnit); DBCC CHECKIDENT('dbo.EmploymentActivityUnit',RESEED,@m1);
-------------------- EmploymentPosition --------------------
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
    SELECT Id,EmploymentActivityUnitId,Code,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,DeletedBy,DeletedAt,IsActive FROM dbo.EmploymentPosition;
  SET IDENTITY_INSERT dbo.EmploymentPosition_new OFF;
  DROP TABLE dbo.EmploymentPosition;
  EXEC sp_rename 'dbo.EmploymentPosition_new','EmploymentPosition';
  EXEC sp_rename 'dbo.PK_EmploymentPosition_tmp','PK_EmploymentPosition','OBJECT';
  EXEC sp_rename 'dbo.DF_EmploymentPosition_IsActive_tmp','DF_EmploymentPosition_IsActive','OBJECT';
  ALTER TABLE dbo.EmploymentPositionTranslation ADD CONSTRAINT FK_EmploymentPositionTranslation_EmploymentPosition
    FOREIGN KEY (EmploymentPositionId) REFERENCES dbo.EmploymentPosition(Id);
  COMMIT;
END TRY
BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH;
DECLARE @m2 int=(SELECT ISNULL(MAX(Id),0) FROM dbo.EmploymentPosition); DBCC CHECKIDENT('dbo.EmploymentPosition',RESEED,@m2);
PRINT 'REORDER DONE';
