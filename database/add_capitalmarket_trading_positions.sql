SET NOCOUNT ON;
SET XACT_ABORT ON;
DECLARE @unit smallint = 14;
DECLARE @sys uniqueidentifier = '00000000-0000-0000-0000-000000000001';
DECLARE @now datetime2 = SYSUTCDATETIME();
IF OBJECT_ID('tempdb..#np') IS NOT NULL DROP TABLE #np;
CREATE TABLE #np (Code varchar(20), fa nvarchar(100), en nvarchar(100));
INSERT INTO #np (Code, fa, en) VALUES
('CmTradingMgr',       N'مدیر معاملات',                      N'Trading Manager'),
('CmSecTradingMgr',    N'مدیر معاملات اوراق بهادار',         N'Securities Trading Manager'),
('CmSecTrader',        N'معامله گر اوراق بهادار',            N'Securities Trader'),
('CmDerivTradingMgr',  N'مدیر معاملات مشتقه',                N'Derivatives Trading Manager'),
('CmSecDerivTrader',   N'معامله گر مشتقه اوراق بهادار',      N'Securities Derivatives Trader'),
('CmCommEnergyMgr',    N'مدیر کالا و انرژی',                 N'Commodity & Energy Manager'),
('CmCommodityMgr',     N'مدیر کالا',                          N'Commodity Manager'),
('CmCommodityTrader',  N'معامله گر کالا',                    N'Commodity Trader'),
('CmCommDerivTrader',  N'معامله گر مشتقه کالا',              N'Commodity Derivatives Trader'),
('CmEnergyExchMgr',    N'مدیر بورس انرژی',                   N'Energy Exchange Manager'),
('CmEnergyExchTrader', N'معامله گر بورس انرژی',              N'Energy Exchange Trader'),
('CmOnlineTrading',    N'مسئول معاملات برخط',                N'Online Trading Officer');
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
WHERE p.EmploymentActivityUnitId=14 ORDER BY p.Id;
