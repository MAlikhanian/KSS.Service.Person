-- Education tables creation script
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'EducationLevel')
BEGIN
    CREATE TABLE EducationLevel (Id INT IDENTITY(1,1) PRIMARY KEY, Code VARCHAR(50) NOT NULL, IsActive BIT NOT NULL DEFAULT 1);
    CREATE UNIQUE INDEX IX_EducationLevel_Code ON EducationLevel(Code);
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'EducationLevelTranslation')
BEGIN
    CREATE TABLE EducationLevelTranslation (EducationLevelId INT NOT NULL, LanguageId INT NOT NULL, Name NVARCHAR(100) NOT NULL, PRIMARY KEY (EducationLevelId, LanguageId), FOREIGN KEY (EducationLevelId) REFERENCES EducationLevel(Id));
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'FieldOfStudy')
BEGIN
    CREATE TABLE FieldOfStudy (Id INT IDENTITY(1,1) PRIMARY KEY, Code VARCHAR(50) NOT NULL, IsActive BIT NOT NULL DEFAULT 1);
    CREATE UNIQUE INDEX IX_FieldOfStudy_Code ON FieldOfStudy(Code);
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'FieldOfStudyTranslation')
BEGIN
    CREATE TABLE FieldOfStudyTranslation (FieldOfStudyId INT NOT NULL, LanguageId INT NOT NULL, Name NVARCHAR(100) NOT NULL, PRIMARY KEY (FieldOfStudyId, LanguageId), FOREIGN KEY (FieldOfStudyId) REFERENCES FieldOfStudy(Id));
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Education')
BEGIN
    CREATE TABLE Education (Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, PersonId UNIQUEIDENTIFIER NOT NULL, EducationLevelId INT NOT NULL, FieldOfStudyId INT NOT NULL, InstitutionName NVARCHAR(200) NULL, StartDate DATETIME2 NULL, EndDate DATETIME2 NULL, GPA DECIMAL(4,2) NULL, IsCompleted BIT NOT NULL DEFAULT 0, CreatedAt DATETIME2 NOT NULL, UpdatedAt DATETIME2 NULL, FOREIGN KEY (PersonId) REFERENCES Person(Id), FOREIGN KEY (EducationLevelId) REFERENCES EducationLevel(Id), FOREIGN KEY (FieldOfStudyId) REFERENCES FieldOfStudy(Id));
    CREATE INDEX IX_Education_PersonId ON Education(PersonId);
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'EducationDocuments')
BEGIN
    CREATE TABLE EducationDocuments (Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, EducationId UNIQUEIDENTIFIER NOT NULL, StorageInstanceId INT NOT NULL, FileName NVARCHAR(255) NOT NULL, FileSize BIGINT NOT NULL, ContentType VARCHAR(100) NOT NULL, CreatedAt DATETIME2 NOT NULL, UpdatedAt DATETIME2 NULL, FOREIGN KEY (EducationId) REFERENCES Education(Id));
    CREATE INDEX IX_EducationDocuments_EducationId ON EducationDocuments(EducationId);
END
GO
