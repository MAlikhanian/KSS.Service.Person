-- Professional Training seed script
-- CreatedBy = existing system GUID copied from dbo.EducationLevel: 00000000-0000-0000-0000-000000000001
-- Languages: 12 = Persian (fa), 10 = English (en)  (confirmed against dbo.EducationLevelTranslation)
-- CreatedAt = SYSUTCDATETIME(), IsActive = 1

-- =========================================================================
-- ProfessionalTrainingType: 1 = TRAINING, 2 = PROFESSIONAL
-- =========================================================================
SET IDENTITY_INSERT dbo.ProfessionalTrainingType ON;
INSERT dbo.ProfessionalTrainingType (Id, Code, CreatedBy, CreatedAt, IsActive) VALUES
 (1, 'TRAINING',     '00000000-0000-0000-0000-000000000001', SYSUTCDATETIME(), 1),
 (2, 'PROFESSIONAL', '00000000-0000-0000-0000-000000000001', SYSUTCDATETIME(), 1);
SET IDENTITY_INSERT dbo.ProfessionalTrainingType OFF;
GO

INSERT dbo.ProfessionalTrainingTypeTranslation (ProfessionalTrainingTypeId, LanguageId, Name, CreatedBy, CreatedAt) VALUES
 (1, 12, N'آموزشی',    '00000000-0000-0000-0000-000000000001', SYSUTCDATETIME()),
 (1, 10, N'Training',     '00000000-0000-0000-0000-000000000001', SYSUTCDATETIME()),
 (2, 12, N'حرفه‌ای',  '00000000-0000-0000-0000-000000000001', SYSUTCDATETIME()),
 (2, 10, N'Professional', '00000000-0000-0000-0000-000000000001', SYSUTCDATETIME());
GO

-- =========================================================================
-- ProfessionalTrainingDocumentType: 1 = CERTIFICATE
-- =========================================================================
SET IDENTITY_INSERT dbo.ProfessionalTrainingDocumentType ON;
INSERT dbo.ProfessionalTrainingDocumentType (Id, Code, CreatedBy, CreatedAt, IsActive) VALUES
 (1, 'CERTIFICATE', '00000000-0000-0000-0000-000000000001', SYSUTCDATETIME(), 1);
SET IDENTITY_INSERT dbo.ProfessionalTrainingDocumentType OFF;
GO

INSERT dbo.ProfessionalTrainingDocumentTypeTranslation (ProfessionalTrainingDocumentTypeId, LanguageId, Name, CreatedBy, CreatedAt) VALUES
 (1, 12, N'گواهی',      '00000000-0000-0000-0000-000000000001', SYSUTCDATETIME()),
 (1, 10, N'Certificate', '00000000-0000-0000-0000-000000000001', SYSUTCDATETIME());
GO

-- =========================================================================
-- ProfessionalTrainingCertificateIssuer: 1 = OTHER, 2 = TVTO (sample rows)
-- =========================================================================
SET IDENTITY_INSERT dbo.ProfessionalTrainingCertificateIssuer ON;
INSERT dbo.ProfessionalTrainingCertificateIssuer (Id, Code, CreatedBy, CreatedAt, IsActive) VALUES
 (1, 'OTHER', '00000000-0000-0000-0000-000000000001', SYSUTCDATETIME(), 1),
 (2, 'TVTO',  '00000000-0000-0000-0000-000000000001', SYSUTCDATETIME(), 1);
SET IDENTITY_INSERT dbo.ProfessionalTrainingCertificateIssuer OFF;
GO

INSERT dbo.ProfessionalTrainingCertificateIssuerTranslation (ProfessionalTrainingCertificateIssuerId, LanguageId, Name, CreatedBy, CreatedAt) VALUES
 (1, 12, N'سایر', '00000000-0000-0000-0000-000000000001', SYSUTCDATETIME()),
 (1, 10, N'Other', '00000000-0000-0000-0000-000000000001', SYSUTCDATETIME()),
 (2, 12, N'سازمان فنی و حرفه‌ای', '00000000-0000-0000-0000-000000000001', SYSUTCDATETIME()),
 (2, 10, N'Technical & Vocational Training Org', '00000000-0000-0000-0000-000000000001', SYSUTCDATETIME());
GO
