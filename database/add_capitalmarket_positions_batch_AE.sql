SET NOCOUNT ON;
SET XACT_ABORT ON;
DECLARE @sys uniqueidentifier = '00000000-0000-0000-0000-000000000001';
DECLARE @now datetime2 = SYSUTCDATETIME();
IF OBJECT_ID('tempdb..#np') IS NOT NULL DROP TABLE #np;
CREATE TABLE #np (Code varchar(20), UnitId smallint, fa nvarchar(120), en nvarchar(120));
INSERT INTO #np (Code,UnitId,fa,en) VALUES
-- Batch A: unit 15 پذیرش سفارش مشتریان
('CmSecAcceptMgr',15,N'مدیر پذیرش اوراق بهادار',N'Securities Acceptance Manager'),
('CmSecAcceptOfc',15,N'مسئول پذیرش اوراق بهادار',N'Securities Acceptance Officer'),
('CmSecDerivAcceptOfc',15,N'مسئول پذیرش مشتقه اوراق بهادار',N'Securities Derivatives Acceptance Officer'),
('CmSecDerivAcceptSpc',15,N'کارشناس پذیرش مشتقه اوراق بهادار',N'Securities Derivatives Acceptance Specialist'),
('CmCommAcceptMgr',15,N'مدیر پذیرش کالا',N'Commodity Acceptance Manager'),
('CmCommAcceptOfc',15,N'مسئول پذیرش کالا',N'Commodity Acceptance Officer'),
('CmCommDerivAccOfc',15,N'مسئول پذیرش مشتقه کالا',N'Commodity Derivatives Acceptance Officer'),
('CmCommDerivAccSpc',15,N'کارشناس پذیرش مشتقه کالا',N'Commodity Derivatives Acceptance Specialist'),
('CmCallCenter',15,N'مسئول مرکز تماس تلفنی',N'Call Center Officer'),
('CmEnergyAccMgr',15,N'مدیر پذیرش بورس انرژی',N'Energy Exchange Acceptance Manager'),
('CmEnergyAccOfc',15,N'مسئول پذیرش بورس انرژی',N'Energy Exchange Acceptance Officer'),
('CmEnergyAccSpc',15,N'کارشناس پذیرش بورس انرژی',N'Energy Exchange Acceptance Specialist'),
('CmCommEnergyAccMgr',15,N'مدیر پذیرش کالا و انرژی',N'Commodity & Energy Acceptance Manager'),
('CmCommEnergyAccOfc',15,N'مسئول پذیرش کالا و انرژی',N'Commodity & Energy Acceptance Officer'),
('CmCommEnergyAccSpc',15,N'کارشناس پذیرش کالا و انرژی',N'Commodity & Energy Acceptance Specialist'),
-- Batch B: unit 16 مالی و اداری
('CmFinAdminMgr',16,N'مدیر مالی و اداری',N'Finance & Admin Manager'),
('CmFinanceMgr',16,N'مدیر مالی',N'Finance Manager'),
('CmAdminMgr',16,N'مدیر اداری',N'Administrative Manager'),
('CmHrMgr',16,N'مدیر منابع انسانی',N'HR Manager'),
('CmHrSpc',16,N'کارشناس منابع انسانی',N'HR Specialist'),
('CmHrClerk',16,N'کارمند منابع انسانی',N'HR Clerk'),
('CmAcctHead',16,N'رئیس حسابداری',N'Head of Accounting'),
('CmAcctSpc',16,N'کارشناس حسابداری',N'Accounting Specialist'),
('CmAcctClerk',16,N'کارمند حسابداری',N'Accounting Clerk'),
('CmOfficeClerk',16,N'کارمند دفتری',N'Office Clerk'),
('CmDeputyCeo',16,N'قائم مقام مدیر عامل',N'Deputy CEO'),
('CmSecurityOfc',16,N'مسئول حراست',N'Security Officer'),
('CmServicesArchive',16,N'تحصیلدار/خدمات/بایگانی/دبیرخانه',N'Collector/Services/Archive/Secretariat'),
('CmOfficeSecretary',16,N'مسئول دفتر/منشی',N'Office Manager/Secretary'),
-- Batch C: unit 17 IT
('CmItManager',17,N'مدیر/مسئول IT',N'IT Manager/Officer'),
('CmItSpecialist',17,N'کارشناس IT',N'IT Specialist'),
-- Batch D: unit 18 مشاور عرضه و پذیرش
('CmSecOfferAdvisor',18,N'مشاور عرضه/پذیرش اوراق بهادار',N'Securities Offering/Listing Advisor'),
('CmCommOfferAdvisor',18,N'مشاور/عرضه پذیرش کالا',N'Commodity Offering/Listing Advisor'),
('CmEnergyOfferAdv',18,N'مشاور/عرضه پذیرش انرژی',N'Energy Offering/Listing Advisor'),
('CmCommEnergyOffAdv',18,N'مشاور/عرضه پذیرش کالا و انرژی',N'Commodity & Energy Offering Advisor'),
-- Batch E: unit 19 تحلیلگری
('CmAnalysisMgr',19,N'مدیر تحلیل',N'Analysis Manager'),
('CmAnalysisSpc',19,N'کارشناس تحلیل',N'Analysis Specialist');
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
FROM dbo.EmploymentPosition p WHERE p.EmploymentActivityUnitId IN (15,16,17,18,19)
GROUP BY p.EmploymentActivityUnitId ORDER BY UnitId;
