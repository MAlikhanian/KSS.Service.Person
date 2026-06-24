SET NOCOUNT ON;
SET XACT_ABORT ON;
IF OBJECT_ID('dbo.EmploymentPosition_Backup') IS NOT NULL DROP TABLE dbo.EmploymentPosition_Backup;
SELECT * INTO dbo.EmploymentPosition_Backup FROM dbo.EmploymentPosition;
IF OBJECT_ID('dbo.EmploymentPositionTranslation_Backup') IS NOT NULL DROP TABLE dbo.EmploymentPositionTranslation_Backup;
SELECT * INTO dbo.EmploymentPositionTranslation_Backup FROM dbo.EmploymentPositionTranslation;
DECLARE @genPos int = (SELECT COUNT(*) FROM dbo.EmploymentPosition WHERE EmploymentActivityUnitId IS NULL);
BEGIN TRY
  BEGIN TRAN;
  DELETE t FROM dbo.EmploymentPositionTranslation t
  JOIN dbo.EmploymentPosition p ON p.Id = t.EmploymentPositionId
  WHERE p.EmploymentActivityUnitId IS NULL;
  DELETE FROM dbo.EmploymentPosition WHERE EmploymentActivityUnitId IS NULL;
  COMMIT;
END TRY
BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH;
PRINT 'Generic positions deleted: ' + CAST(@genPos AS varchar);
SELECT 'remaining_generic_positions' AS chk, COUNT(*) AS n FROM dbo.EmploymentPosition WHERE EmploymentActivityUnitId IS NULL
UNION ALL SELECT 'remaining_total_positions', COUNT(*) FROM dbo.EmploymentPosition
UNION ALL SELECT 'employment_rows(unchanged)', COUNT(*) FROM dbo.Employment;
