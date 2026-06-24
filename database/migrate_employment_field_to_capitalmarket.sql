SET NOCOUNT ON;
SET XACT_ABORT ON;
-- 1) backup current field ids
IF OBJECT_ID('dbo.Employment_FieldId_Backup') IS NOT NULL DROP TABLE dbo.Employment_FieldId_Backup;
SELECT Id, EmploymentActivityFieldId AS OldFieldId, SYSUTCDATETIME() AS BackedUpAt
INTO dbo.Employment_FieldId_Backup FROM dbo.Employment;
DECLARE @bk int = (SELECT COUNT(*) FROM dbo.Employment_FieldId_Backup);
-- 2) mass update -> CapitalMarket (17)
BEGIN TRY
  BEGIN TRAN;
  UPDATE dbo.Employment SET EmploymentActivityFieldId = 17 WHERE EmploymentActivityFieldId <> 17;
  COMMIT;
END TRY
BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH;
-- 3) verify
PRINT 'Backup rows: ' + CAST(@bk AS varchar);
SELECT EmploymentActivityFieldId AS FieldId, COUNT(*) AS Rows FROM dbo.Employment GROUP BY EmploymentActivityFieldId;
SELECT 'distinct old fields in backup' AS info, COUNT(DISTINCT OldFieldId) AS n FROM dbo.Employment_FieldId_Backup;
