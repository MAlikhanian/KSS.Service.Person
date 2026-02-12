-- ============================================================
-- Database: KSS_Person_Prod (microservice: person)
-- Person, EmailLabel, PhoneLabel, AddressLabel, Email, Phone, Address, PersonTranslation, Employment, Relationship.
-- LanguageId/PreferredLanguageId ref KSS_Common_Prod.dbo.[Language]; CountryId/RegionId/CityId ref KSS_Common_Prod (no FK cross-database).
-- ============================================================
IF DB_ID(N'KSS_Person_Prod') IS NULL
    CREATE DATABASE [KSS_Person_Prod];
GO

USE [KSS_Person_Prod];
GO

-- Sex (lookup first), then SexTranslation.
CREATE TABLE dbo.[Sex] (
    Id     TINYINT      IDENTITY(1, 1) NOT NULL,
    Code   VARCHAR(10)  NOT NULL,
    CONSTRAINT PK_Sex PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT UQ_Sex_Code UNIQUE (Code)
);
CREATE TABLE dbo.[SexTranslation] (
    SexId      TINYINT      NOT NULL,
    LanguageId SMALLINT     NOT NULL,
    Name       NVARCHAR(20) NOT NULL,
    CONSTRAINT PK_SexTranslation PRIMARY KEY CLUSTERED (SexId, LanguageId),
    CONSTRAINT FK_SexTranslation_Sex FOREIGN KEY (SexId) REFERENCES dbo.[Sex] (Id) ON DELETE CASCADE
);
CREATE NONCLUSTERED INDEX IX_SexTranslation_LanguageId ON dbo.[SexTranslation] (LanguageId);
GO

-- Person (GUID key; PreferredLanguageId = reference to KSS_Common_Prod.dbo.[Language].Id)
-- NationalId, DateOfBirth: no translation. Translated fields in PersonTranslation.
CREATE TABLE dbo.[Person] (
    Id                   UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Person_Id DEFAULT NEWSEQUENTIALID(),
    SexId                TINYINT          NOT NULL,
    PreferredLanguageId  SMALLINT         NOT NULL,
    NationalId           VARCHAR(20)      NOT NULL,
    DateOfBirth          DATE             NOT NULL,
    BirthCountryId       SMALLINT         NOT NULL,
    BirthRegionId        SMALLINT         NOT NULL,
    BirthCityId          INT              NOT NULL,
    NationalityCountryId SMALLINT         NOT NULL,
    IsActive             BIT              NOT NULL CONSTRAINT DF_Person_IsActive DEFAULT 1,
    CreatedAt            DATETIME2(7)     NOT NULL CONSTRAINT DF_Person_CreatedAt DEFAULT SYSUTCDATETIME(),
    UpdatedAt            DATETIME2(7)     NOT NULL CONSTRAINT DF_Person_UpdatedAt DEFAULT SYSUTCDATETIME(),
    CONSTRAINT PK_Person PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_Person_Sex FOREIGN KEY (SexId) REFERENCES dbo.[Sex] (Id)
);
CREATE NONCLUSTERED INDEX IX_Person_SexId ON dbo.[Person] (SexId);
CREATE NONCLUSTERED INDEX IX_Person_PreferredLanguageId ON dbo.[Person] (PreferredLanguageId);
CREATE NONCLUSTERED INDEX IX_Person_NationalId ON dbo.[Person] (NationalId);
CREATE NONCLUSTERED INDEX IX_Person_BirthCountryId ON dbo.[Person] (BirthCountryId);
CREATE NONCLUSTERED INDEX IX_Person_BirthRegionId ON dbo.[Person] (BirthRegionId);
CREATE NONCLUSTERED INDEX IX_Person_BirthCityId ON dbo.[Person] (BirthCityId);
CREATE NONCLUSTERED INDEX IX_Person_NationalityCountryId ON dbo.[Person] (NationalityCountryId);
CREATE NONCLUSTERED INDEX IX_Person_IsActive ON dbo.[Person] (IsActive) WHERE IsActive = 1;
GO

-- PersonTranslation: name and translatable profile per language (LanguageId = KSS_Common_Prod.dbo.[Language].Id)
CREATE TABLE dbo.[PersonTranslation] (
    PersonId     UNIQUEIDENTIFIER NOT NULL,
    LanguageId   SMALLINT        NOT NULL,
    FirstName    NVARCHAR(50)    NOT NULL,
    LastName     NVARCHAR(50)    NOT NULL,
    FatherName   NVARCHAR(50)    NULL,
    DisplayName  NVARCHAR(100)   NULL,
    CONSTRAINT PK_PersonTranslation PRIMARY KEY CLUSTERED (PersonId, LanguageId),
    CONSTRAINT FK_PersonTranslation_Person FOREIGN KEY (PersonId) REFERENCES dbo.[Person] (Id) ON DELETE CASCADE
);
CREATE NONCLUSTERED INDEX IX_PersonTranslation_LanguageId ON dbo.[PersonTranslation] (LanguageId);
GO

CREATE TRIGGER dbo.TR_PersonTranslation_DisplayName ON dbo.[PersonTranslation]
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t SET DisplayName = RTRIM(t.FirstName + N' ' + t.LastName)
    FROM dbo.[PersonTranslation] t
    INNER JOIN inserted i ON i.PersonId = t.PersonId AND i.LanguageId = t.LanguageId
    WHERE t.DisplayName IS NULL OR t.DisplayName = N'';
END;
GO

-- EmailLabel (label first), then Email.
CREATE TABLE dbo.[EmailLabel] (
    Id     TINYINT       IDENTITY(1, 1) NOT NULL,
    Code   VARCHAR(10)   NOT NULL,
    CONSTRAINT PK_EmailLabel PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT UQ_EmailLabel_Code UNIQUE (Code)
);
CREATE TABLE dbo.[EmailLabelTranslation] (
    EmailLabelId TINYINT       NOT NULL,
    LanguageId   SMALLINT     NOT NULL,
    Name         NVARCHAR(50)  NOT NULL,
    CONSTRAINT PK_EmailLabelTranslation PRIMARY KEY CLUSTERED (EmailLabelId, LanguageId),
    CONSTRAINT FK_EmailLabelTranslation_EmailLabel FOREIGN KEY (EmailLabelId) REFERENCES dbo.[EmailLabel] (Id) ON DELETE CASCADE
);
CREATE NONCLUSTERED INDEX IX_EmailLabelTranslation_LanguageId ON dbo.[EmailLabelTranslation] (LanguageId);
GO
CREATE TABLE dbo.[Email] (
    Id          UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Email_Id DEFAULT NEWSEQUENTIALID(),
    PersonId    UNIQUEIDENTIFIER NOT NULL,
    LabelId     TINYINT          NOT NULL,
    Email       VARCHAR(128)     NOT NULL,
    IsPrimary   BIT              NOT NULL CONSTRAINT DF_Email_IsPrimary DEFAULT 0,
    IsVerified  BIT              NOT NULL CONSTRAINT DF_Email_IsVerified DEFAULT 0,
    VerifiedAt  DATETIME2(7)     NULL,
    CreatedAt   DATETIME2(7)     NOT NULL CONSTRAINT DF_Email_CreatedAt DEFAULT SYSUTCDATETIME(),
    UpdatedAt   DATETIME2(7)     NOT NULL CONSTRAINT DF_Email_UpdatedAt DEFAULT SYSUTCDATETIME(),
    CONSTRAINT PK_Email PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_Email_Person FOREIGN KEY (PersonId) REFERENCES dbo.[Person] (Id) ON DELETE CASCADE,
    CONSTRAINT FK_Email_Label FOREIGN KEY (LabelId) REFERENCES dbo.[EmailLabel] (Id),
    CONSTRAINT UQ_Email_Email UNIQUE (PersonId, Email)
);
CREATE NONCLUSTERED INDEX IX_Email_PersonId ON dbo.[Email] (PersonId);
CREATE NONCLUSTERED INDEX IX_Email_LabelId ON dbo.[Email] (LabelId);
CREATE NONCLUSTERED INDEX IX_Email_Email ON dbo.[Email] (Email);
GO

-- PhoneLabel (label first), then Phone.
CREATE TABLE dbo.[PhoneLabel] (
    Id     TINYINT       IDENTITY(1, 1) NOT NULL,
    Code   VARCHAR(10)   NOT NULL,
    CONSTRAINT PK_PhoneLabel PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT UQ_PhoneLabel_Code UNIQUE (Code)
);
CREATE TABLE dbo.[PhoneLabelTranslation] (
    PhoneLabelId TINYINT       NOT NULL,
    LanguageId   SMALLINT     NOT NULL,
    Name         NVARCHAR(50)  NOT NULL,
    CONSTRAINT PK_PhoneLabelTranslation PRIMARY KEY CLUSTERED (PhoneLabelId, LanguageId),
    CONSTRAINT FK_PhoneLabelTranslation_PhoneLabel FOREIGN KEY (PhoneLabelId) REFERENCES dbo.[PhoneLabel] (Id) ON DELETE CASCADE
);
CREATE NONCLUSTERED INDEX IX_PhoneLabelTranslation_LanguageId ON dbo.[PhoneLabelTranslation] (LanguageId);
GO
CREATE TABLE dbo.[Phone] (
    Id           UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Phone_Id DEFAULT NEWSEQUENTIALID(),
    PersonId     UNIQUEIDENTIFIER NOT NULL,
    LabelId      TINYINT          NOT NULL,
    CountryId    SMALLINT         NOT NULL,
    PhoneNumber  VARCHAR(15)      NOT NULL,
    IsPrimary    BIT              NOT NULL CONSTRAINT DF_Phone_IsPrimary DEFAULT 0,
    IsVerified   BIT              NOT NULL CONSTRAINT DF_Phone_IsVerified DEFAULT 0,
    VerifiedAt   DATETIME2(7)     NULL,
    CreatedAt    DATETIME2(7)     NOT NULL CONSTRAINT DF_Phone_CreatedAt DEFAULT SYSUTCDATETIME(),
    UpdatedAt    DATETIME2(7)     NOT NULL CONSTRAINT DF_Phone_UpdatedAt DEFAULT SYSUTCDATETIME(),
    CONSTRAINT PK_Phone PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_Phone_Person FOREIGN KEY (PersonId) REFERENCES dbo.[Person] (Id) ON DELETE CASCADE,
    CONSTRAINT FK_Phone_Label FOREIGN KEY (LabelId) REFERENCES dbo.[PhoneLabel] (Id),
    CONSTRAINT UQ_Phone_PersonNumber UNIQUE (PersonId, CountryId, PhoneNumber)
);
CREATE NONCLUSTERED INDEX IX_Phone_PersonId ON dbo.[Phone] (PersonId);
CREATE NONCLUSTERED INDEX IX_Phone_LabelId ON dbo.[Phone] (LabelId);
CREATE NONCLUSTERED INDEX IX_Phone_CountryId ON dbo.[Phone] (CountryId);
CREATE NONCLUSTERED INDEX IX_Phone_Number ON dbo.[Phone] (PhoneNumber);
GO

-- AddressLabel (label first), then Address, then AddressTranslation.
CREATE TABLE dbo.[AddressLabel] (
    Id     TINYINT       IDENTITY(1, 1) NOT NULL,
    Code   VARCHAR(10)   NOT NULL,
    CONSTRAINT PK_AddressLabel PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT UQ_AddressLabel_Code UNIQUE (Code)
);
CREATE TABLE dbo.[AddressLabelTranslation] (
    AddressLabelId TINYINT     NOT NULL,
    LanguageId     SMALLINT   NOT NULL,
    Name           NVARCHAR(50)  NOT NULL,
    CONSTRAINT PK_AddressLabelTranslation PRIMARY KEY CLUSTERED (AddressLabelId, LanguageId),
    CONSTRAINT FK_AddressLabelTranslation_AddressLabel FOREIGN KEY (AddressLabelId) REFERENCES dbo.[AddressLabel] (Id) ON DELETE CASCADE
);
CREATE NONCLUSTERED INDEX IX_AddressLabelTranslation_LanguageId ON dbo.[AddressLabelTranslation] (LanguageId);
GO
CREATE TABLE dbo.[Address] (
    Id           UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Address_Id DEFAULT NEWSEQUENTIALID(),
    PersonId     UNIQUEIDENTIFIER NOT NULL,
    LabelId      TINYINT          NOT NULL,
    CountryId    SMALLINT         NOT NULL,
    RegionId     SMALLINT         NOT NULL,
    CityId       INT              NOT NULL,
    PostalCode   VARCHAR(10)      NOT NULL,
    Latitude     DECIMAL(9, 6)    NULL,
    Longitude    DECIMAL(9, 6)    NULL,
    IsPrimary    BIT              NOT NULL CONSTRAINT DF_Address_IsPrimary DEFAULT 0,
    IsVerified   BIT              NOT NULL CONSTRAINT DF_Address_IsVerified DEFAULT 0,
    VerifiedAt   DATETIME2(7)     NULL,
    CreatedAt    DATETIME2(7)     NOT NULL CONSTRAINT DF_Address_CreatedAt DEFAULT SYSUTCDATETIME(),
    UpdatedAt    DATETIME2(7)     NOT NULL CONSTRAINT DF_Address_UpdatedAt DEFAULT SYSUTCDATETIME(),
    CONSTRAINT PK_Address PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_Address_Person FOREIGN KEY (PersonId) REFERENCES dbo.[Person] (Id) ON DELETE CASCADE,
    CONSTRAINT FK_Address_Label FOREIGN KEY (LabelId) REFERENCES dbo.[AddressLabel] (Id)
);
CREATE NONCLUSTERED INDEX IX_Address_PersonId ON dbo.[Address] (PersonId);
CREATE NONCLUSTERED INDEX IX_Address_LabelId ON dbo.[Address] (LabelId);
CREATE NONCLUSTERED INDEX IX_Address_CountryId ON dbo.[Address] (CountryId);
CREATE NONCLUSTERED INDEX IX_Address_RegionId ON dbo.[Address] (RegionId);
CREATE NONCLUSTERED INDEX IX_Address_CityId ON dbo.[Address] (CityId);
GO

-- AddressTranslation: street lines per language (LanguageId = KSS_Common_Prod.dbo.[Language].Id)
CREATE TABLE dbo.[AddressTranslation] (
    AddressId UNIQUEIDENTIFIER NOT NULL,
    LanguageId      SMALLINT        NOT NULL,
    Street1         NVARCHAR(100) NOT NULL,
    Street2         NVARCHAR(100) NULL,
    CONSTRAINT PK_AddressTranslation PRIMARY KEY CLUSTERED (AddressId, LanguageId),
    CONSTRAINT FK_AddressTranslation_Address FOREIGN KEY (AddressId) REFERENCES dbo.[Address] (Id) ON DELETE CASCADE
);
CREATE NONCLUSTERED INDEX IX_AddressTranslation_LanguageId ON dbo.[AddressTranslation] (LanguageId);
GO

-- 3-level job filter: JobCategory (1) → JobDepartment (2) → JobTitle (3). Each with *Translation for name per language.
CREATE TABLE dbo.[JobCategory] (
    Id     SMALLINT     IDENTITY(1, 1) NOT NULL,
    Code   VARCHAR(10)  NOT NULL,
    CONSTRAINT PK_JobCategory PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT UQ_JobCategory_Code UNIQUE (Code)
);
CREATE TABLE dbo.[JobCategoryTranslation] (
    JobCategoryId SMALLINT      NOT NULL,
    LanguageId    SMALLINT      NOT NULL,
    Name          NVARCHAR(50)  NOT NULL,
    CONSTRAINT PK_JobCategoryTranslation PRIMARY KEY CLUSTERED (JobCategoryId, LanguageId),
    CONSTRAINT FK_JobCategoryTranslation_JobCategory FOREIGN KEY (JobCategoryId) REFERENCES dbo.[JobCategory] (Id) ON DELETE CASCADE
);
CREATE NONCLUSTERED INDEX IX_JobCategoryTranslation_LanguageId ON dbo.[JobCategoryTranslation] (LanguageId);
GO

CREATE TABLE dbo.[JobDepartment] (
    Id             SMALLINT     IDENTITY(1, 1) NOT NULL,
    JobCategoryId  SMALLINT     NOT NULL,
    Code           VARCHAR(10)  NOT NULL,
    CONSTRAINT PK_JobDepartment PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_JobDepartment_JobCategory FOREIGN KEY (JobCategoryId) REFERENCES dbo.[JobCategory] (Id) ON DELETE CASCADE,
    CONSTRAINT UQ_JobDepartment_Code UNIQUE (Code)
);
CREATE TABLE dbo.[JobDepartmentTranslation] (
    JobDepartmentId SMALLINT      NOT NULL,
    LanguageId      SMALLINT      NOT NULL,
    Name            NVARCHAR(50)  NOT NULL,
    CONSTRAINT PK_JobDepartmentTranslation PRIMARY KEY CLUSTERED (JobDepartmentId, LanguageId),
    CONSTRAINT FK_JobDepartmentTranslation_JobDepartment FOREIGN KEY (JobDepartmentId) REFERENCES dbo.[JobDepartment] (Id) ON DELETE CASCADE
);
CREATE NONCLUSTERED INDEX IX_JobDepartment_JobCategoryId ON dbo.[JobDepartment] (JobCategoryId);
CREATE NONCLUSTERED INDEX IX_JobDepartmentTranslation_LanguageId ON dbo.[JobDepartmentTranslation] (LanguageId);
GO

CREATE TABLE dbo.[JobTitle] (
    Id              SMALLINT     IDENTITY(1, 1) NOT NULL,
    JobDepartmentId SMALLINT     NOT NULL,
    Code            VARCHAR(10)  NOT NULL,
    CONSTRAINT PK_JobTitle PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_JobTitle_JobDepartment FOREIGN KEY (JobDepartmentId) REFERENCES dbo.[JobDepartment] (Id) ON DELETE CASCADE,
    CONSTRAINT UQ_JobTitle_Code UNIQUE (Code)
);
CREATE TABLE dbo.[JobTitleTranslation] (
    JobTitleId  SMALLINT      NOT NULL,
    LanguageId  SMALLINT      NOT NULL,
    Name        NVARCHAR(50)  NOT NULL,
    CONSTRAINT PK_JobTitleTranslation PRIMARY KEY CLUSTERED (JobTitleId, LanguageId),
    CONSTRAINT FK_JobTitleTranslation_JobTitle FOREIGN KEY (JobTitleId) REFERENCES dbo.[JobTitle] (Id) ON DELETE CASCADE
);
CREATE NONCLUSTERED INDEX IX_JobTitle_JobDepartmentId ON dbo.[JobTitle] (JobDepartmentId);
CREATE NONCLUSTERED INDEX IX_JobTitleTranslation_LanguageId ON dbo.[JobTitleTranslation] (LanguageId);
GO

-- Employment (سوابق کاری): many jobs per person. CompanyId = KSS_Company_Prod.dbo.[Company].Id, JobTitleId = lookup (no FK cross-database).
CREATE TABLE dbo.[Employment] (
    Id          UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Employment_Id DEFAULT NEWSEQUENTIALID(),
    PersonId    UNIQUEIDENTIFIER NOT NULL,
    CompanyId   UNIQUEIDENTIFIER NOT NULL,
    JobTitleId  SMALLINT         NOT NULL,
    FromDate    DATE             NOT NULL,
    ToDate      DATE             NULL,
    IsPrimary   BIT              NOT NULL CONSTRAINT DF_Employment_IsPrimary DEFAULT 0,
    SortOrder   TINYINT          NOT NULL CONSTRAINT DF_Employment_SortOrder DEFAULT 0,
    CreatedAt   DATETIME2(7)     NOT NULL CONSTRAINT DF_Employment_CreatedAt DEFAULT SYSUTCDATETIME(),
    UpdatedAt   DATETIME2(7)     NOT NULL CONSTRAINT DF_Employment_UpdatedAt DEFAULT SYSUTCDATETIME(),
    CONSTRAINT PK_Employment PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_Employment_Person FOREIGN KEY (PersonId) REFERENCES dbo.[Person] (Id) ON DELETE CASCADE,
    CONSTRAINT FK_Employment_JobTitle FOREIGN KEY (JobTitleId) REFERENCES dbo.[JobTitle] (Id)
);
CREATE NONCLUSTERED INDEX IX_Employment_PersonId ON dbo.[Employment] (PersonId);
CREATE NONCLUSTERED INDEX IX_Employment_CompanyId ON dbo.[Employment] (CompanyId);
CREATE NONCLUSTERED INDEX IX_Employment_JobTitleId ON dbo.[Employment] (JobTitleId);
GO

-- RelationshipType: lookup (Code; name per language in RelationshipTypeTranslation)
CREATE TABLE dbo.[RelationshipType] (
    Id     TINYINT       IDENTITY(1, 1) NOT NULL,
    Code   VARCHAR(20)   NOT NULL,
    CONSTRAINT PK_RelationshipType PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT UQ_RelationshipType_Code UNIQUE (Code)
);
CREATE TABLE dbo.[RelationshipTypeTranslation] (
    RelationshipTypeId TINYINT        NOT NULL,
    LanguageId         SMALLINT       NOT NULL,
    Name               NVARCHAR(50)   NOT NULL,
    CONSTRAINT PK_RelationshipTypeTranslation PRIMARY KEY CLUSTERED (RelationshipTypeId, LanguageId),
    CONSTRAINT FK_RelationshipTypeTranslation_Type FOREIGN KEY (RelationshipTypeId) REFERENCES dbo.[RelationshipType] (Id) ON DELETE CASCADE
);
CREATE NONCLUSTERED INDEX IX_RelationshipTypeTranslation_LanguageId ON dbo.[RelationshipTypeTranslation] (LanguageId);
GO

-- Relationship: PersonId has RelationshipType with RelatedPersonId (e.g. A is Parent of B). Store one row per direction.
CREATE TABLE dbo.[Relationship] (
    Id                 UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Relationship_Id DEFAULT NEWSEQUENTIALID(),
    PersonId           UNIQUEIDENTIFIER NOT NULL,
    RelatedPersonId    UNIQUEIDENTIFIER NOT NULL,
    RelationshipTypeId TINYINT          NOT NULL,
    CreatedAt          DATETIME2(7)     NOT NULL CONSTRAINT DF_Relationship_CreatedAt DEFAULT SYSUTCDATETIME(),
    UpdatedAt          DATETIME2(7)     NOT NULL CONSTRAINT DF_Relationship_UpdatedAt DEFAULT SYSUTCDATETIME(),
    CONSTRAINT PK_Relationship PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_Relationship_Person FOREIGN KEY (PersonId) REFERENCES dbo.[Person] (Id) ON DELETE NO ACTION,
    CONSTRAINT FK_Relationship_RelatedPerson FOREIGN KEY (RelatedPersonId) REFERENCES dbo.[Person] (Id) ON DELETE NO ACTION,
    CONSTRAINT FK_Relationship_Type FOREIGN KEY (RelationshipTypeId) REFERENCES dbo.[RelationshipType] (Id),
    CONSTRAINT CK_Relationship_NoSelf CHECK (PersonId <> RelatedPersonId),
    CONSTRAINT UQ_Relationship UNIQUE (PersonId, RelatedPersonId, RelationshipTypeId)
);
CREATE NONCLUSTERED INDEX IX_Relationship_PersonId ON dbo.[Relationship] (PersonId);
CREATE NONCLUSTERED INDEX IX_Relationship_RelatedPersonId ON dbo.[Relationship] (RelatedPersonId);
CREATE NONCLUSTERED INDEX IX_Relationship_Type ON dbo.[Relationship] (RelationshipTypeId);
GO

-- Seed relationship types (Code). Idempotent.
;WITH codes AS (
    SELECT Code FROM (VALUES
        (N'Father'), (N'Mother'), (N'Child'), (N'Spouse'), (N'Brother'), (N'Sister'),
        (N'MaternalAunt'), (N'MaternalUncle'), (N'PaternalUncle'), (N'PaternalAunt'),
        (N'Grandfather'), (N'Grandmother'), (N'Grandchild'),
        (N'SonInLaw'), (N'DaughterInLaw'), (N'Cousin'), (N'Nephew'), (N'Niece'),
        (N'Friend'), (N'Colleague'), (N'Guardian'), (N'Other')
    ) AS x(Code)
)
MERGE dbo.[RelationshipType] AS t
USING codes AS s ON t.Code = s.Code
WHEN NOT MATCHED BY TARGET THEN INSERT (Code) VALUES (s.Code);
GO

-- Seed RelationshipTypeTranslation (en/fa). LanguageId from KSS_Common_Prod.dbo.[Language]. Idempotent.
;WITH v AS (
    SELECT Code, LangCode, Name FROM (VALUES
        (N'Father',       N'en', N'Father'),
        (N'Father',       N'fa', N'پدر'),
        (N'Mother',       N'en', N'Mother'),
        (N'Mother',       N'fa', N'مادر'),
        (N'Child',        N'en', N'Child'),
        (N'Child',        N'fa', N'فرزند'),
        (N'Spouse',       N'en', N'Spouse'),
        (N'Spouse',       N'fa', N'همسر'),
        (N'Brother',      N'en', N'Brother'),
        (N'Brother',      N'fa', N'برادر'),
        (N'Sister',       N'en', N'Sister'),
        (N'Sister',       N'fa', N'خواهر'),
        (N'MaternalAunt', N'en', N'Maternal aunt'),
        (N'MaternalAunt', N'fa', N'خاله'),
        (N'MaternalUncle', N'en', N'Maternal uncle'),
        (N'MaternalUncle', N'fa', N'دایی'),
        (N'PaternalUncle', N'en', N'Paternal uncle'),
        (N'PaternalUncle', N'fa', N'عمو'),
        (N'PaternalAunt', N'en', N'Paternal aunt'),
        (N'PaternalAunt', N'fa', N'عمه'),
        (N'Grandfather',  N'en', N'Grandfather'),
        (N'Grandfather',  N'fa', N'پدربزرگ'),
        (N'Grandmother',  N'en', N'Grandmother'),
        (N'Grandmother',  N'fa', N'مادربزرگ'),
        (N'Grandchild',   N'en', N'Grandchild'),
        (N'Grandchild',   N'fa', N'نوه'),
        (N'SonInLaw',     N'en', N'Son-in-law'),
        (N'SonInLaw',     N'fa', N'داماد'),
        (N'DaughterInLaw', N'en', N'Daughter-in-law'),
        (N'DaughterInLaw', N'fa', N'عروس'),
        (N'Cousin',       N'en', N'Cousin'),
        (N'Cousin',       N'fa', N'عموزاده'),
        (N'Nephew',       N'en', N'Nephew'),
        (N'Nephew',       N'fa', N'برادرزاده'),
        (N'Niece',        N'en', N'Niece'),
        (N'Niece',        N'fa', N'خواهرزاده'),
        (N'Friend',       N'en', N'Friend'),
        (N'Friend',       N'fa', N'دوست'),
        (N'Colleague',    N'en', N'Colleague'),
        (N'Colleague',    N'fa', N'همکار'),
        (N'Guardian',     N'en', N'Guardian'),
        (N'Guardian',     N'fa', N'سرپرست'),
        (N'Other',        N'en', N'Other'),
        (N'Other',        N'fa', N'سایر')
    ) AS x(Code, LangCode, Name)
)
MERGE dbo.[RelationshipTypeTranslation] AS t
USING (
    SELECT rt.Id AS RelationshipTypeId, l.Id AS LanguageId, v.Name
    FROM v
    JOIN dbo.[RelationshipType] rt ON rt.Code = v.Code
    JOIN KSS_Common_Prod.dbo.[Language] l ON l.Code = v.LangCode
) AS s ON t.RelationshipTypeId = s.RelationshipTypeId AND t.LanguageId = s.LanguageId
WHEN MATCHED THEN UPDATE SET Name = s.Name
WHEN NOT MATCHED BY TARGET THEN INSERT (RelationshipTypeId, LanguageId, Name) VALUES (s.RelationshipTypeId, s.LanguageId, s.Name);
GO

-- Seed Sex (Code). Idempotent.
;WITH codes AS (SELECT Code FROM (VALUES ('Male'), ('Female')) AS x(Code))
MERGE dbo.[Sex] AS t USING codes AS s ON t.Code = s.Code
WHEN NOT MATCHED BY TARGET THEN INSERT (Code) VALUES (s.Code);
GO
-- Seed SexTranslation (en/fa). LanguageId from KSS_Common_Prod.dbo.[Language].
;WITH v AS (
    SELECT Code, LangCode, Name FROM (VALUES
        ('Male',   'en', N'Male'),   ('Male',   'fa', N'مرد'),
        ('Female', 'en', N'Female'), ('Female', 'fa', N'زن')
    ) AS x(Code, LangCode, Name)
)
MERGE dbo.[SexTranslation] AS t
USING (
    SELECT s.Id AS SexId, l.Id AS LanguageId, v.Name
    FROM v
    JOIN dbo.[Sex] s ON s.Code = v.Code
    JOIN KSS_Common_Prod.dbo.[Language] l ON l.Code = v.LangCode
) AS s ON t.SexId = s.SexId AND t.LanguageId = s.LanguageId
WHEN MATCHED THEN UPDATE SET Name = s.Name
WHEN NOT MATCHED BY TARGET THEN INSERT (SexId, LanguageId, Name) VALUES (s.SexId, s.LanguageId, s.Name);
GO

-- Seed EmailLabel (Code). Idempotent.
;WITH codes AS (SELECT Code FROM (VALUES ('Personal'), ('Work'), ('Other')) AS x(Code))
MERGE dbo.[EmailLabel] AS t USING codes AS s ON t.Code = s.Code
WHEN NOT MATCHED BY TARGET THEN INSERT (Code) VALUES (s.Code);
GO
-- Seed EmailLabelTranslation (en/fa). LanguageId from KSS_Common_Prod.dbo.[Language].
;WITH v AS (
    SELECT Code, LangCode, Name FROM (VALUES
        ('Personal', 'en', N'Personal'), ('Personal', 'fa', N'شخصی'),
        ('Work',     'en', N'Work'),     ('Work',     'fa', N'کاری'),
        ('Other',    'en', N'Other'),    ('Other',    'fa', N'سایر')
    ) AS x(Code, LangCode, Name)
)
MERGE dbo.[EmailLabelTranslation] AS t
USING (
    SELECT el.Id AS EmailLabelId, l.Id AS LanguageId, v.Name
    FROM v
    JOIN dbo.[EmailLabel] el ON el.Code = v.Code
    JOIN KSS_Common_Prod.dbo.[Language] l ON l.Code = v.LangCode
) AS s ON t.EmailLabelId = s.EmailLabelId AND t.LanguageId = s.LanguageId
WHEN MATCHED THEN UPDATE SET Name = s.Name
WHEN NOT MATCHED BY TARGET THEN INSERT (EmailLabelId, LanguageId, Name) VALUES (s.EmailLabelId, s.LanguageId, s.Name);
GO

-- Seed PhoneLabel (Code). Idempotent.
;WITH codes AS (SELECT Code FROM (VALUES ('Mobile'), ('Home'), ('Work'), ('Fax'), ('Other')) AS x(Code))
MERGE dbo.[PhoneLabel] AS t USING codes AS s ON t.Code = s.Code
WHEN NOT MATCHED BY TARGET THEN INSERT (Code) VALUES (s.Code);
GO
-- Seed PhoneLabelTranslation (en/fa).
;WITH v AS (
    SELECT Code, LangCode, Name FROM (VALUES
        ('Mobile', 'en', N'Mobile'),   ('Mobile', 'fa', N'موبایل'),
        ('Home',   'en', N'Home'),     ('Home',   'fa', N'منزل'),
        ('Work',   'en', N'Work'),     ('Work',   'fa', N'کاری'),
        ('Fax',    'en', N'Fax'),      ('Fax',    'fa', N'فکس'),
        ('Other',  'en', N'Other'),    ('Other',  'fa', N'سایر')
    ) AS x(Code, LangCode, Name)
)
MERGE dbo.[PhoneLabelTranslation] AS t
USING (
    SELECT pl.Id AS PhoneLabelId, l.Id AS LanguageId, v.Name
    FROM v
    JOIN dbo.[PhoneLabel] pl ON pl.Code = v.Code
    JOIN KSS_Common_Prod.dbo.[Language] l ON l.Code = v.LangCode
) AS s ON t.PhoneLabelId = s.PhoneLabelId AND t.LanguageId = s.LanguageId
WHEN MATCHED THEN UPDATE SET Name = s.Name
WHEN NOT MATCHED BY TARGET THEN INSERT (PhoneLabelId, LanguageId, Name) VALUES (s.PhoneLabelId, s.LanguageId, s.Name);
GO

-- Seed AddressLabel (Code). Idempotent.
;WITH codes AS (SELECT Code FROM (VALUES ('Home'), ('Work'), ('Billing'), ('Shipping'), ('Other')) AS x(Code))
MERGE dbo.[AddressLabel] AS t USING codes AS s ON t.Code = s.Code
WHEN NOT MATCHED BY TARGET THEN INSERT (Code) VALUES (s.Code);
GO
-- Seed AddressLabelTranslation (en/fa).
;WITH v AS (
    SELECT Code, LangCode, Name FROM (VALUES
        ('Home',     'en', N'Home'),     ('Home',     'fa', N'منزل'),
        ('Work',     'en', N'Work'),     ('Work',     'fa', N'کاری'),
        ('Billing',  'en', N'Billing'),  ('Billing',  'fa', N'صورتحساب'),
        ('Shipping', 'en', N'Shipping'), ('Shipping', 'fa', N'تحویل'),
        ('Other',    'en', N'Other'),    ('Other',    'fa', N'سایر')
    ) AS x(Code, LangCode, Name)
)
MERGE dbo.[AddressLabelTranslation] AS t
USING (
    SELECT al.Id AS AddressLabelId, l.Id AS LanguageId, v.Name
    FROM v
    JOIN dbo.[AddressLabel] al ON al.Code = v.Code
    JOIN KSS_Common_Prod.dbo.[Language] l ON l.Code = v.LangCode
) AS s ON t.AddressLabelId = s.AddressLabelId AND t.LanguageId = s.LanguageId
WHEN MATCHED THEN UPDATE SET Name = s.Name
WHEN NOT MATCHED BY TARGET THEN INSERT (AddressLabelId, LanguageId, Name) VALUES (s.AddressLabelId, s.LanguageId, s.Name);
GO