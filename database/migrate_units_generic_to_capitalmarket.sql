SET NOCOUNT ON;
SET XACT_ABORT ON;
IF OBJECT_ID('dbo.Employment_UnitId_Backup') IS NOT NULL DROP TABLE dbo.Employment_UnitId_Backup;
SELECT Id, EmploymentActivityUnitId AS OldUnitId, SYSUTCDATETIME() AS BackedUpAt
INTO dbo.Employment_UnitId_Backup FROM dbo.Employment;
IF OBJECT_ID('tempdb..#map') IS NOT NULL DROP TABLE #map;
CREATE TABLE #map (OldId smallint, NewId smallint);
INSERT INTO #map (OldId,NewId) VALUES (12,16),(1,16),(5,25),(10,13),(3,16),(4,17),(8,21),(9,20),(6,16),(2,15),(7,21),(11,15);
DECLARE @moved int;
BEGIN TRY
  BEGIN TRAN;
  UPDATE e SET e.EmploymentActivityUnitId = m.NewId
  FROM dbo.Employment e JOIN #map m ON m.OldId = e.EmploymentActivityUnitId;
  SET @moved = @@ROWCOUNT;
  DELETE t FROM dbo.EmploymentActivityUnitTranslation t
  JOIN dbo.EmploymentActivityUnit u ON u.Id = t.EmploymentActivityUnitId
  WHERE u.EmploymentActivityFieldId IS NULL
    AND NOT EXISTS (SELECT 1 FROM dbo.Employment e WHERE e.EmploymentActivityUnitId = u.Id);
  DELETE u FROM dbo.EmploymentActivityUnit u
  WHERE u.EmploymentActivityFieldId IS NULL
    AND NOT EXISTS (SELECT 1 FROM dbo.Employment e WHERE e.EmploymentActivityUnitId = u.Id);
  COMMIT;
END TRY
BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH;
DROP TABLE #map;
PRINT 'Employment rows remapped: ' + CAST(@moved AS varchar);
SELECT 'emp_on_generic_units' AS chk, COUNT(*) AS n FROM dbo.Employment e JOIN dbo.EmploymentActivityUnit u ON u.Id=e.EmploymentActivityUnitId WHERE u.EmploymentActivityFieldId IS NULL
UNION ALL SELECT 'remaining_generic_units', COUNT(*) FROM dbo.EmploymentActivityUnit WHERE EmploymentActivityFieldId IS NULL;
SELECT u.Id, t.Name AS UnitName, COUNT(e.Id) AS used
FROM dbo.EmploymentActivityUnit u
LEFT JOIN dbo.EmploymentActivityUnitTranslation t ON t.EmploymentActivityUnitId=u.Id AND t.LanguageId=12
LEFT JOIN dbo.Employment e ON e.EmploymentActivityUnitId=u.Id
GROUP BY u.Id,t.Name HAVING COUNT(e.Id)>0 ORDER BY used DESC;
