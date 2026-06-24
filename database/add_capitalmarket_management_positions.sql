SET NOCOUNT ON;
SET XACT_ABORT ON;
DECLARE @unit smallint = 13;
DECLARE @sys uniqueidentifier = '00000000-0000-0000-0000-000000000001';
DECLARE @now datetime2 = SYSUTCDATETIME();
IF OBJECT_ID('tempdb..#np') IS NOT NULL DROP TABLE #np;
CREATE TABLE #np (Code varchar(20), fa nvarchar(100), en nvarchar(100));
INSERT INTO #np (Code, fa, en) VALUES
('CmBoardChairman',  N'رئیس هیأت مدیره',                  N'Chairman of the Board'),
('CmBoardViceChair', N'نائب رئیس هیأت مدیره',             N'Vice Chairman of the Board'),
('CmCeoBoardMember', N'مدیرعامل و عضو هیأت مدیره',         N'CEO & Board Member'),
('CmCeoViceChair',   N'مدیرعامل و نائب رئیس هیأت مدیره',   N'CEO & Vice Chairman'),
('CmBoardMember',    N'عضو هیأت مدیره',                    N'Board Member'),
('CmCeo',            N'مدیرعامل',                          N'CEO');
BEGIN TRY
  BEGIN TRAN;
  INSERT INTO dbo.EmploymentPosition (Code, EmploymentActivityUnitId, CreatedBy, CreatedAt, IsActive)
  SELECT n.Code, @unit, @sys, @now, 1 FROM #np n
  WHERE NOT EXISTS (SELECT 1 FROM dbo.EmploymentPosition p WHERE p.EmploymentActivityUnitId=@unit AND p.Code=n.Code);
  INSERT INTO dbo.EmploymentPositionTranslation (EmploymentPositionId, LanguageId, Name, CreatedBy, CreatedAt)
  SELECT p.Id, 12, n.fa, @sys, @now FROM dbo.EmploymentPosition p JOIN #np n ON n.Code=p.Code
  WHERE p.EmploymentActivityUnitId=@unit AND NOT EXISTS (SELECT 1 FROM dbo.EmploymentPositionTranslation t WHERE t.EmploymentPositionId=p.Id AND t.LanguageId=12);
  INSERT INTO dbo.EmploymentPositionTranslation (EmploymentPositionId, LanguageId, Name, CreatedBy, CreatedAt)
  SELECT p.Id, 10, n.en, @sys, @now FROM dbo.EmploymentPosition p JOIN #np n ON n.Code=p.Code
  WHERE p.EmploymentActivityUnitId=@unit AND NOT EXISTS (SELECT 1 FROM dbo.EmploymentPositionTranslation t WHERE t.EmploymentPositionId=p.Id AND t.LanguageId=10);
  COMMIT;
END TRY
BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH;
DROP TABLE #np;
SELECT p.Id, p.Code, p.EmploymentActivityUnitId AS UnitId, t12.Name AS fa, t10.Name AS en
FROM dbo.EmploymentPosition p
LEFT JOIN dbo.EmploymentPositionTranslation t12 ON t12.EmploymentPositionId=p.Id AND t12.LanguageId=12
LEFT JOIN dbo.EmploymentPositionTranslation t10 ON t10.EmploymentPositionId=p.Id AND t10.LanguageId=10
WHERE p.EmploymentActivityUnitId=13 ORDER BY p.Id;
