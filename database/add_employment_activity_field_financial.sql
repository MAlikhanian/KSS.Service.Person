SET NOCOUNT ON;
IF NOT EXISTS (SELECT 1 FROM dbo.EmploymentActivityField WHERE Code='CapitalMarket')
BEGIN
  INSERT INTO dbo.EmploymentActivityField (Code, CreatedBy, CreatedAt, IsActive)
  VALUES ('CapitalMarket', '00000000-0000-0000-0000-000000000001', SYSUTCDATETIME(), 1);
  DECLARE @id smallint = CAST(SCOPE_IDENTITY() AS smallint);
  INSERT INTO dbo.EmploymentActivityFieldTranslation (EmploymentActivityFieldId, LanguageId, Name, CreatedBy, CreatedAt)
  VALUES (@id, 12, N'مالی - بازار سرمایه', '00000000-0000-0000-0000-000000000001', SYSUTCDATETIME()),
         (@id, 10, N'Financial - Capital Market', '00000000-0000-0000-0000-000000000001', SYSUTCDATETIME());
END
SELECT f.Id, f.Code, t12.Name AS fa, t10.Name AS en
FROM dbo.EmploymentActivityField f
LEFT JOIN dbo.EmploymentActivityFieldTranslation t12 ON t12.EmploymentActivityFieldId=f.Id AND t12.LanguageId=12
LEFT JOIN dbo.EmploymentActivityFieldTranslation t10 ON t10.EmploymentActivityFieldId=f.Id AND t10.LanguageId=10
WHERE f.Code='CapitalMarket';
