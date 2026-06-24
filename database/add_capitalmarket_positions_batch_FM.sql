SET NOCOUNT ON;
SET XACT_ABORT ON;
DECLARE @sys uniqueidentifier = '00000000-0000-0000-0000-000000000001';
DECLARE @now datetime2 = SYSUTCDATETIME();
IF OBJECT_ID('tempdb..#np') IS NOT NULL DROP TABLE #np;
CREATE TABLE #np (Code varchar(20), UnitId smallint, fa nvarchar(120), en nvarchar(120));
INSERT INTO #np (Code,UnitId,fa,en) VALUES
('CmIntCtrlMgr',20,N'مدیر نظارت و کنترل داخلی',N'Internal Control Manager'),
('CmIntCtrlOfc',20,N'مسئول نظارت و کنترل داخلی',N'Internal Control Officer'),
('CmIntCtrlSpc',20,N'کارشناس نظارت و کنترل داخلی',N'Internal Control Specialist'),
('CmTrainingMgrSpc',21,N'مدیر/کارشناس آموزش',N'Training Manager/Specialist'),
('CmRnDMgrSpc',21,N'مدیر/کارشناس تحقیق و توسعه',N'R&D Manager/Specialist'),
('CmMktMgrSpc',21,N'مدیر/کارشناس مارکتینگ',N'Marketing Manager/Specialist'),
('CmMarketDevOfc',21,N'بازاریاب/ مسئول توسعه بازار',N'Marketer/Market Development Officer'),
('CmInvestmentMgr',22,N'مدیر سرمایه گذاری',N'Investment Manager'),
('CmInvestmentAdv',22,N'مشاور سرمایه گذاری',N'Investment Advisor'),
('CmInvestmentSpc',22,N'کارشناس سرمایه گذاری',N'Investment Specialist'),
('CmIntlAffairsOfc',23,N'مسئول امور بین الملل',N'International Affairs Officer'),
('CmCrmMgr',24,N'مدیر CRM',N'CRM Manager'),
('CmCrmSpc',24,N'کارشناس CRM',N'CRM Specialist'),
('CmOpsMgr',25,N'مدیر اجرایی/مدیر عملیاتی',N'Executive/Operations Manager'),
('CmOpsSpc',25,N'کارشناس اجرایی/کارشناس عملیاتی',N'Executive/Operations Specialist'),
('CmCreditMgr',26,N'مدیر اعتبارات',N'Credit Manager'),
('CmCreditSpc',26,N'کارشناس اعتبارات',N'Credit Specialist'),
('CmPrMgr',27,N'مدیر روابط عمومی',N'Public Relations Manager'),
('CmPrSpc',27,N'کارشناس روابط عمومی',N'Public Relations Specialist');
BEGIN TRY
  BEGIN TRAN;
  INSERT INTO dbo.EmploymentPosition (Code, EmploymentActivityUnitId, CreatedBy, CreatedAt, IsActive)
  SELECT n.Code, n.UnitId, @sys, @now, 1 FROM #np n
  WHERE NOT EXISTS (SELECT 1 FROM dbo.EmploymentPosition p WHERE p.EmploymentActivityUnitId=n.UnitId AND p.Code=n.Code);
  INSERT INTO dbo.EmploymentPositionTranslation (EmploymentPositionId, LanguageId, Name, CreatedBy, CreatedAt)
  SELECT p.Id, 12, n.fa, @sys, @now FROM dbo.EmploymentPosition p JOIN #np n ON n.Code=p.Code AND n.UnitId=p.EmploymentActivityUnitId
  WHERE NOT EXISTS (SELECT 1 FROM dbo.EmploymentPositionTranslation t WHERE t.EmploymentPositionId=p.Id AND t.LanguageId=12);
  INSERT INTO dbo.EmploymentPositionTranslation (EmploymentPositionId, LanguageId, Name, CreatedBy, CreatedAt)
  SELECT p.Id, 10, n.en, @sys, @now FROM dbo.EmploymentPosition p JOIN #np n ON n.Code=p.Code AND n.UnitId=p.EmploymentActivityUnitId
  WHERE NOT EXISTS (SELECT 1 FROM dbo.EmploymentPositionTranslation t WHERE t.EmploymentPositionId=p.Id AND t.LanguageId=10);
  COMMIT;
END TRY
BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH;
DROP TABLE #np;
SELECT p.EmploymentActivityUnitId AS UnitId, COUNT(*) AS Positions
FROM dbo.EmploymentPosition p WHERE p.EmploymentActivityUnitId IN (20,21,22,23,24,25,26,27)
GROUP BY p.EmploymentActivityUnitId ORDER BY UnitId;
SELECT COUNT(*) AS TotalCapitalMarketPositions FROM dbo.EmploymentPosition p
JOIN dbo.EmploymentActivityUnit u ON u.Id=p.EmploymentActivityUnitId WHERE u.EmploymentActivityFieldId=17;
