SET NOCOUNT ON;
SET XACT_ABORT ON;
-- backup
IF OBJECT_ID('dbo.EmploymentActivityField_Backup') IS NOT NULL DROP TABLE dbo.EmploymentActivityField_Backup;
SELECT * INTO dbo.EmploymentActivityField_Backup FROM dbo.EmploymentActivityField;
IF OBJECT_ID('dbo.EmploymentActivityFieldTranslation_Backup') IS NOT NULL DROP TABLE dbo.EmploymentActivityFieldTranslation_Backup;
SELECT * INTO dbo.EmploymentActivityFieldTranslation_Backup FROM dbo.EmploymentActivityFieldTranslation;
BEGIN TRY
  BEGIN TRAN;
  DELETE FROM dbo.EmploymentActivityFieldTranslation WHERE EmploymentActivityFieldId <> 17;
  DELETE FROM dbo.EmploymentActivityField WHERE Id <> 17;
  SET IDENTITY_INSERT dbo.EmploymentActivityField ON;
  INSERT dbo.EmploymentActivityField (Id,Code,CreatedBy,CreatedAt,IsActive)
    SELECT 1,Code,CreatedBy,CreatedAt,IsActive FROM dbo.EmploymentActivityField WHERE Id=17;
  SET IDENTITY_INSERT dbo.EmploymentActivityField OFF;
  UPDATE dbo.EmploymentActivityFieldTranslation SET EmploymentActivityFieldId=1 WHERE EmploymentActivityFieldId=17;
  UPDATE dbo.EmploymentActivityUnit            SET EmploymentActivityFieldId=1 WHERE EmploymentActivityFieldId=17;
  UPDATE dbo.Employment                         SET EmploymentActivityFieldId=1 WHERE EmploymentActivityFieldId=17;
  DELETE dbo.EmploymentActivityField WHERE Id=17;
  COMMIT;
END TRY
BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH;
DBCC CHECKIDENT('dbo.EmploymentActivityField', RESEED, 1);
-- verify
SELECT f.Id, f.Code, t.Name AS fa FROM dbo.EmploymentActivityField f LEFT JOIN dbo.EmploymentActivityFieldTranslation t ON t.EmploymentActivityFieldId=f.Id AND t.LanguageId=12;
SELECT 'fieldRows' AS chk, COUNT(*) AS n FROM dbo.EmploymentActivityField
UNION ALL SELECT 'unitsParent1', COUNT(*) FROM dbo.EmploymentActivityUnit WHERE EmploymentActivityFieldId=1
UNION ALL SELECT 'unitsParent17', COUNT(*) FROM dbo.EmploymentActivityUnit WHERE EmploymentActivityFieldId=17
UNION ALL SELECT 'empField1', COUNT(*) FROM dbo.Employment WHERE EmploymentActivityFieldId=1
UNION ALL SELECT 'empNot1', COUNT(*) FROM dbo.Employment WHERE EmploymentActivityFieldId<>1;
