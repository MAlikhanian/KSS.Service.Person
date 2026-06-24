-- Professional Training tables creation script
-- Mirrors the Education vertical slice. Lookups are INT IDENTITY (DB-owned).
-- Main/document PKs are UNIQUEIDENTIFIER with NO default (backend supplies v7 GUID).
-- Audit columns + IsActive DEFAULT(1). Timestamps supplied by backend (no SQL defaults).

-- =========================================================================
-- Lookup 1: ProfessionalTrainingType (+ Translation)
-- =========================================================================
CREATE TABLE dbo.ProfessionalTrainingType (
  Id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ProfessionalTrainingType PRIMARY KEY,
  Code VARCHAR(50) NOT NULL,
  CreatedBy UNIQUEIDENTIFIER NOT NULL, CreatedAt DATETIME2 NOT NULL,
  UpdatedBy UNIQUEIDENTIFIER NULL, UpdatedAt DATETIME2 NULL,
  DeletedBy UNIQUEIDENTIFIER NULL, DeletedAt DATETIME2 NULL,
  IsActive BIT NOT NULL CONSTRAINT DF_PTType_IsActive DEFAULT(1)
);
GO

CREATE TABLE dbo.ProfessionalTrainingTypeTranslation (
  ProfessionalTrainingTypeId INT NOT NULL,
  LanguageId SMALLINT NOT NULL,
  Name NVARCHAR(100) NOT NULL,
  CreatedBy UNIQUEIDENTIFIER NOT NULL, CreatedAt DATETIME2 NOT NULL,
  UpdatedBy UNIQUEIDENTIFIER NULL, UpdatedAt DATETIME2 NULL,
  DeletedBy UNIQUEIDENTIFIER NULL, DeletedAt DATETIME2 NULL,
  CONSTRAINT PK_ProfessionalTrainingTypeTranslation PRIMARY KEY (ProfessionalTrainingTypeId, LanguageId),
  CONSTRAINT FK_PTTypeTrans_PTType FOREIGN KEY (ProfessionalTrainingTypeId) REFERENCES dbo.ProfessionalTrainingType(Id) ON DELETE CASCADE
);
GO

-- =========================================================================
-- Lookup 2: ProfessionalTrainingCertificateIssuer (+ Translation)
-- =========================================================================
CREATE TABLE dbo.ProfessionalTrainingCertificateIssuer (
  Id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ProfessionalTrainingCertificateIssuer PRIMARY KEY,
  Code VARCHAR(50) NOT NULL,
  CreatedBy UNIQUEIDENTIFIER NOT NULL, CreatedAt DATETIME2 NOT NULL,
  UpdatedBy UNIQUEIDENTIFIER NULL, UpdatedAt DATETIME2 NULL,
  DeletedBy UNIQUEIDENTIFIER NULL, DeletedAt DATETIME2 NULL,
  IsActive BIT NOT NULL CONSTRAINT DF_PTIssuer_IsActive DEFAULT(1)
);
GO

CREATE TABLE dbo.ProfessionalTrainingCertificateIssuerTranslation (
  ProfessionalTrainingCertificateIssuerId INT NOT NULL,
  LanguageId SMALLINT NOT NULL,
  Name NVARCHAR(100) NOT NULL,
  CreatedBy UNIQUEIDENTIFIER NOT NULL, CreatedAt DATETIME2 NOT NULL,
  UpdatedBy UNIQUEIDENTIFIER NULL, UpdatedAt DATETIME2 NULL,
  DeletedBy UNIQUEIDENTIFIER NULL, DeletedAt DATETIME2 NULL,
  CONSTRAINT PK_ProfessionalTrainingCertificateIssuerTranslation PRIMARY KEY (ProfessionalTrainingCertificateIssuerId, LanguageId),
  CONSTRAINT FK_PTIssuerTrans_PTIssuer FOREIGN KEY (ProfessionalTrainingCertificateIssuerId) REFERENCES dbo.ProfessionalTrainingCertificateIssuer(Id) ON DELETE CASCADE
);
GO

-- =========================================================================
-- Lookup 3: ProfessionalTrainingDocumentType (+ Translation)
-- =========================================================================
CREATE TABLE dbo.ProfessionalTrainingDocumentType (
  Id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ProfessionalTrainingDocumentType PRIMARY KEY,
  Code VARCHAR(50) NOT NULL,
  CreatedBy UNIQUEIDENTIFIER NOT NULL, CreatedAt DATETIME2 NOT NULL,
  UpdatedBy UNIQUEIDENTIFIER NULL, UpdatedAt DATETIME2 NULL,
  DeletedBy UNIQUEIDENTIFIER NULL, DeletedAt DATETIME2 NULL,
  IsActive BIT NOT NULL CONSTRAINT DF_PTDocType_IsActive DEFAULT(1)
);
GO

CREATE TABLE dbo.ProfessionalTrainingDocumentTypeTranslation (
  ProfessionalTrainingDocumentTypeId INT NOT NULL,
  LanguageId SMALLINT NOT NULL,
  Name NVARCHAR(100) NOT NULL,
  CreatedBy UNIQUEIDENTIFIER NOT NULL, CreatedAt DATETIME2 NOT NULL,
  UpdatedBy UNIQUEIDENTIFIER NULL, UpdatedAt DATETIME2 NULL,
  DeletedBy UNIQUEIDENTIFIER NULL, DeletedAt DATETIME2 NULL,
  CONSTRAINT PK_ProfessionalTrainingDocumentTypeTranslation PRIMARY KEY (ProfessionalTrainingDocumentTypeId, LanguageId),
  CONSTRAINT FK_PTDocTypeTrans_PTDocType FOREIGN KEY (ProfessionalTrainingDocumentTypeId) REFERENCES dbo.ProfessionalTrainingDocumentType(Id) ON DELETE CASCADE
);
GO

-- =========================================================================
-- Main: ProfessionalTraining
-- =========================================================================
CREATE TABLE dbo.ProfessionalTraining (
  Id UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_ProfessionalTraining PRIMARY KEY,
  PersonId UNIQUEIDENTIFIER NOT NULL,
  Title NVARCHAR(200) NOT NULL,
  ProfessionalTrainingTypeId INT NOT NULL,
  ProfessionalTrainingCertificateIssuerId INT NOT NULL,
  IssueDate DATETIME2 NULL,
  ExpiryDate DATETIME2 NULL,
  CreatedBy UNIQUEIDENTIFIER NOT NULL, CreatedAt DATETIME2 NOT NULL,
  UpdatedBy UNIQUEIDENTIFIER NULL, UpdatedAt DATETIME2 NULL,
  DeletedBy UNIQUEIDENTIFIER NULL, DeletedAt DATETIME2 NULL,
  IsActive BIT NOT NULL CONSTRAINT DF_PT_IsActive DEFAULT(1),
  CONSTRAINT FK_PT_Person FOREIGN KEY (PersonId) REFERENCES dbo.Person(Id) ON DELETE CASCADE,
  CONSTRAINT FK_PT_Type FOREIGN KEY (ProfessionalTrainingTypeId) REFERENCES dbo.ProfessionalTrainingType(Id),
  CONSTRAINT FK_PT_Issuer FOREIGN KEY (ProfessionalTrainingCertificateIssuerId) REFERENCES dbo.ProfessionalTrainingCertificateIssuer(Id)
);
GO

CREATE INDEX IX_ProfessionalTraining_PersonId ON dbo.ProfessionalTraining(PersonId);
GO

-- =========================================================================
-- Child documents: ProfessionalTrainingDocument
-- =========================================================================
CREATE TABLE dbo.ProfessionalTrainingDocument (
  Id UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_ProfessionalTrainingDocument PRIMARY KEY,
  ProfessionalTrainingId UNIQUEIDENTIFIER NOT NULL,
  ProfessionalTrainingDocumentTypeId INT NOT NULL,
  StorageInstanceId INT NOT NULL,
  FileName NVARCHAR(255) NOT NULL,
  FileSize BIGINT NOT NULL,
  ContentType VARCHAR(100) NOT NULL,
  CreatedBy UNIQUEIDENTIFIER NOT NULL, CreatedAt DATETIME2 NOT NULL,
  UpdatedBy UNIQUEIDENTIFIER NULL, UpdatedAt DATETIME2 NULL,
  DeletedBy UNIQUEIDENTIFIER NULL, DeletedAt DATETIME2 NULL,
  IsActive BIT NOT NULL CONSTRAINT DF_PTDoc_IsActive DEFAULT(1),
  CONSTRAINT FK_PTDoc_PT FOREIGN KEY (ProfessionalTrainingId) REFERENCES dbo.ProfessionalTraining(Id) ON DELETE CASCADE,
  CONSTRAINT FK_PTDoc_DocType FOREIGN KEY (ProfessionalTrainingDocumentTypeId) REFERENCES dbo.ProfessionalTrainingDocumentType(Id)
);
GO

CREATE INDEX IX_ProfessionalTrainingDocument_PTId ON dbo.ProfessionalTrainingDocument(ProfessionalTrainingId);
GO
