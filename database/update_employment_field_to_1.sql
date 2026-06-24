SET NOCOUNT ON;
SET XACT_ABORT ON;
IF OBJECT_ID('dbo.Employment_FieldId_Backup_3') IS NOT NULL DROP TABLE dbo.Employment_FieldId_Backup_3;
SELECT Id, EmploymentActivityFieldId AS OldFieldId, SYSUTCDATETIME() AS BackedUpAt
INTO dbo.Employment_FieldId_Backup_3 FROM dbo.Employment;
DECLARE @before int = (SELECT COUNT(*) FROM dbo.Employment WHERE EmploymentActivityFieldId<>1);
BEGIN TRY
  BEGIN TRAN;
  UPDATE dbo.Employment SET EmploymentActivityFieldId = 1 WHERE EmploymentActivityFieldId <> 1;
  COMMIT;
END TRY
BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH;
PRINT 'Rows repointed: ' + CAST(@before AS varchar);
SELECT EmploymentActivityFieldId AS FieldId, COUNT(*) AS Rows FROM dbo.Employment GROUP BY EmploymentActivityFieldId;
SELECT 'TOTAL' AS x, COUNT(*) AS n FROM dbo.Employment;
