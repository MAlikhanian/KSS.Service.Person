-- ============================================================
-- Migration: Add new fields to Person table + MilitaryServiceStatus + InsuranceType tables
-- Database: KSS_Person_Prod / KSS_Person_Dev
-- ============================================================

USE [KSS_Person_Prod];
GO

-- ============================================================
-- 1. MilitaryServiceStatus lookup table
-- ============================================================
IF OBJECT_ID(N'dbo.MilitaryServiceStatus', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.[MilitaryServiceStatus] (
        Id     TINYINT      IDENTITY(1, 1) NOT NULL,
        Code   VARCHAR(20)  NOT NULL,
        CONSTRAINT PK_MilitaryServiceStatus PRIMARY KEY CLUSTERED (Id),
        CONSTRAINT UQ_MilitaryServiceStatus_Code UNIQUE (Code)
    );

    CREATE TABLE dbo.[MilitaryServiceStatusTranslation] (
        MilitaryServiceStatusId TINYINT      NOT NULL,
        LanguageId              SMALLINT     NOT NULL,
        Name                    NVARCHAR(50) NOT NULL,
        CONSTRAINT PK_MilitaryServiceStatusTranslation PRIMARY KEY CLUSTERED (MilitaryServiceStatusId, LanguageId),
        CONSTRAINT FK_MilitaryServiceStatusTranslation_MilitaryServiceStatus
            FOREIGN KEY (MilitaryServiceStatusId) REFERENCES dbo.[MilitaryServiceStatus] (Id) ON DELETE CASCADE
    );
    CREATE NONCLUSTERED INDEX IX_MilitaryServiceStatusTranslation_LanguageId
        ON dbo.[MilitaryServiceStatusTranslation] (LanguageId);
END
GO

-- ============================================================
-- 2. InsuranceType lookup table
-- ============================================================
IF OBJECT_ID(N'dbo.InsuranceType', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.[InsuranceType] (
        Id     TINYINT      IDENTITY(1, 1) NOT NULL,
        Code   VARCHAR(30)  NOT NULL,
        CONSTRAINT PK_InsuranceType PRIMARY KEY CLUSTERED (Id),
        CONSTRAINT UQ_InsuranceType_Code UNIQUE (Code)
    );

    CREATE TABLE dbo.[InsuranceTypeTranslation] (
        InsuranceTypeId TINYINT      NOT NULL,
        LanguageId      SMALLINT     NOT NULL,
        Name            NVARCHAR(50) NOT NULL,
        CONSTRAINT PK_InsuranceTypeTranslation PRIMARY KEY CLUSTERED (InsuranceTypeId, LanguageId),
        CONSTRAINT FK_InsuranceTypeTranslation_InsuranceType
            FOREIGN KEY (InsuranceTypeId) REFERENCES dbo.[InsuranceType] (Id) ON DELETE CASCADE
    );
    CREATE NONCLUSTERED INDEX IX_InsuranceTypeTranslation_LanguageId
        ON dbo.[InsuranceTypeTranslation] (LanguageId);
END
GO

-- ============================================================
-- 3. Seed MilitaryServiceStatus
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM dbo.[MilitaryServiceStatus])
BEGIN
    SET IDENTITY_INSERT dbo.[MilitaryServiceStatus] ON;
    INSERT INTO dbo.[MilitaryServiceStatus] (Id, Code) VALUES
        (1, 'Exempt'),
        (2, 'Completed'),
        (3, 'InService'),
        (4, 'EducationalExemption'),
        (5, 'NotApplicable');
    SET IDENTITY_INSERT dbo.[MilitaryServiceStatus] OFF;

    INSERT INTO dbo.[MilitaryServiceStatusTranslation] (MilitaryServiceStatusId, LanguageId, Name) VALUES
        -- Persian (LanguageId = 12)
        (1, 12, N'معاف'),
        (2, 12, N'پایان خدمت'),
        (3, 12, N'در حال خدمت'),
        (4, 12, N'معافیت تحصیلی'),
        (5, 12, N'مشمول نمی‌شود'),
        -- English (LanguageId = 10)
        (1, 10, N'Exempt'),
        (2, 10, N'Completed'),
        (3, 10, N'In Service'),
        (4, 10, N'Educational Exemption'),
        (5, 10, N'Not Applicable');
END
GO

-- ============================================================
-- 4. Seed InsuranceType
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM dbo.[InsuranceType])
BEGIN
    SET IDENTITY_INSERT dbo.[InsuranceType] ON;
    INSERT INTO dbo.[InsuranceType] (Id, Code) VALUES
        (1, 'SocialSecurity'),
        (2, 'HealthInsurance'),
        (3, 'SupplementaryInsurance'),
        (4, 'None');
    SET IDENTITY_INSERT dbo.[InsuranceType] OFF;

    INSERT INTO dbo.[InsuranceTypeTranslation] (InsuranceTypeId, LanguageId, Name) VALUES
        -- Persian (LanguageId = 12)
        (1, 12, N'تأمین اجتماعی'),
        (2, 12, N'بیمه درمان'),
        (3, 12, N'بیمه تکمیلی'),
        (4, 12, N'ندارد'),
        -- English (LanguageId = 10)
        (1, 10, N'Social Security'),
        (2, 10, N'Health Insurance'),
        (3, 10, N'Supplementary Insurance'),
        (4, 10, N'None');
END
GO

-- ============================================================
-- 5. Add new columns to Person table
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'dbo.Person') AND name = N'BirthCertificateNumber')
BEGIN
    ALTER TABLE dbo.[Person] ADD
        BirthCertificateNumber          VARCHAR(20)      NULL,
        BirthCertificateSerialPartA     VARCHAR(10)      NULL,
        BirthCertificateSerialPartB     VARCHAR(10)      NULL,
        BirthCertificateSerialPartC     VARCHAR(10)      NULL,
        BirthCertificateIssueCountryId  SMALLINT         NOT NULL CONSTRAINT DF_Person_BCIssueCountryId DEFAULT 1,
        BirthCertificateIssueRegionId   SMALLINT         NOT NULL CONSTRAINT DF_Person_BCIssueRegionId DEFAULT 1,
        BirthCertificateIssueCityId     INT              NOT NULL CONSTRAINT DF_Person_BCIssueCityId DEFAULT 1,
        IsMarried                       BIT              NOT NULL CONSTRAINT DF_Person_IsMarried DEFAULT 0,
        ReligionId                      SMALLINT         NOT NULL CONSTRAINT DF_Person_ReligionId DEFAULT 1,
        PassportNumber                  VARCHAR(20)      NULL,
        MilitaryServiceStatusId         TINYINT          NOT NULL CONSTRAINT DF_Person_MilitaryServiceStatusId DEFAULT 1,
        InsuranceTypeId                 TINYINT          NOT NULL CONSTRAINT DF_Person_InsuranceTypeId DEFAULT 1,
        InsuranceNumber                 VARCHAR(30)      NULL;
END
GO

-- ============================================================
-- 6. Add FK constraints for new columns
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = N'FK_Person_MilitaryServiceStatus')
BEGIN
    ALTER TABLE dbo.[Person]
        ADD CONSTRAINT FK_Person_MilitaryServiceStatus
            FOREIGN KEY (MilitaryServiceStatusId) REFERENCES dbo.[MilitaryServiceStatus] (Id);
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = N'FK_Person_InsuranceType')
BEGIN
    ALTER TABLE dbo.[Person]
        ADD CONSTRAINT FK_Person_InsuranceType
            FOREIGN KEY (InsuranceTypeId) REFERENCES dbo.[InsuranceType] (Id);
END
GO

-- ============================================================
-- 7. Add indexes for new FK columns
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Person_MilitaryServiceStatusId')
    CREATE NONCLUSTERED INDEX IX_Person_MilitaryServiceStatusId ON dbo.[Person] (MilitaryServiceStatusId);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Person_InsuranceTypeId')
    CREATE NONCLUSTERED INDEX IX_Person_InsuranceTypeId ON dbo.[Person] (InsuranceTypeId);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Person_ReligionId')
    CREATE NONCLUSTERED INDEX IX_Person_ReligionId ON dbo.[Person] (ReligionId);
GO

PRINT 'Migration completed successfully.';
GO
