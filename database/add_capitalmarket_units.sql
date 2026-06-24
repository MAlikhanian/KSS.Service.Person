SET NOCOUNT ON;
SET XACT_ABORT ON;
DECLARE @field smallint = 17;
DECLARE @sys uniqueidentifier = '00000000-0000-0000-0000-000000000001';
DECLARE @now datetime2 = SYSUTCDATETIME();
IF OBJECT_ID('tempdb..#new') IS NOT NULL DROP TABLE #new;
CREATE TABLE #new (Code varchar(20), fa nvarchar(100), en nvarchar(100));
INSERT INTO #new (Code, fa, en) VALUES
('CmManagement',       N'مدیریت',                          N'Management'),
('CmTrading',          N'معاملات',                          N'Trading'),
('CmOrderAcceptance',  N'پذیرش سفارش مشتریان',              N'Customer Order Acceptance'),
('CmFinanceAdmin',     N'مالی و اداری',                     N'Finance & Administration'),
('CmIT',               N'IT',                               N'Information Technology'),
('CmOfferingAdvisory', N'مشاور عرضه و پذیرش',               N'Offering & Listing Advisory'),
('CmAnalysis',         N'تحلیلگری',                          N'Analysis'),
('CmInternalControl',  N'نظارت و کنترل داخلی',              N'Internal Control & Supervision'),
('CmTrainingRnDMkt',   N'آموزش، تحقیق و توسعه و مارکتینگ',  N'Training, R&D & Marketing'),
('CmInvestment',       N'سرمایه گذاری',                     N'Investment'),
('CmIntlAffairs',      N'امور بین الملل',                   N'International Affairs'),
('CmCRM',              N'CRM',                              N'CRM'),
('CmOperations',       N'واحد عملیات',                       N'Operations'),
('CmCredit',           N'واحد اعتبارات',                     N'Credit'),
('CmPublicRelations',  N'روابط عمومی',                      N'Public Relations');
BEGIN TRY
  BEGIN TRAN;
  INSERT INTO dbo.EmploymentActivityUnit (Code, EmploymentActivityFieldId, CreatedBy, CreatedAt, IsActive)
  SELECT n.Code, @field, @sys, @now, 1 FROM #new n
  WHERE NOT EXISTS (SELECT 1 FROM dbo.EmploymentActivityUnit u WHERE u.EmploymentActivityFieldId=@field AND u.Code=n.Code);
  INSERT INTO dbo.EmploymentActivityUnitTranslation (EmploymentActivityUnitId, LanguageId, Name, CreatedBy, CreatedAt)
  SELECT u.Id, 12, n.fa, @sys, @now FROM dbo.EmploymentActivityUnit u JOIN #new n ON n.Code=u.Code
  WHERE u.EmploymentActivityFieldId=@field AND NOT EXISTS (SELECT 1 FROM dbo.EmploymentActivityUnitTranslation t WHERE t.EmploymentActivityUnitId=u.Id AND t.LanguageId=12);
  INSERT INTO dbo.EmploymentActivityUnitTranslation (EmploymentActivityUnitId, LanguageId, Name, CreatedBy, CreatedAt)
  SELECT u.Id, 10, n.en, @sys, @now FROM dbo.EmploymentActivityUnit u JOIN #new n ON n.Code=u.Code
  WHERE u.EmploymentActivityFieldId=@field AND NOT EXISTS (SELECT 1 FROM dbo.EmploymentActivityUnitTranslation t WHERE t.EmploymentActivityUnitId=u.Id AND t.LanguageId=10);
  COMMIT;
END TRY
BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH;
DROP TABLE #new;
SELECT u.Id, u.Code, t12.Name AS fa, t10.Name AS en
FROM dbo.EmploymentActivityUnit u
LEFT JOIN dbo.EmploymentActivityUnitTranslation t12 ON t12.EmploymentActivityUnitId=u.Id AND t12.LanguageId=12
LEFT JOIN dbo.EmploymentActivityUnitTranslation t10 ON t10.EmploymentActivityUnitId=u.Id AND t10.LanguageId=10
WHERE u.EmploymentActivityFieldId=17 ORDER BY u.Id;
