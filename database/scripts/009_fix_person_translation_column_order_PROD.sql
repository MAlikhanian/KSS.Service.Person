-- 009_fix_person_translation_column_order_PROD.sql
--
-- Drop+recreate dbo.Person and dbo.Translation in KSS_Person_Prod to fix column order.
-- Source for restored data: KSS_Person_Dev (which is an exact copy of current Prod data).
--
-- Person changes:
--   * Move CreatedAt/UpdatedAt to end (currently mid-table at pos 9-10)
--   * Add audit columns: CreatedBy, UpdatedBy, DeletedBy, DeletedAt
--   * Add IsActive at end
--   * UpdatedAt becomes NULL (per CLAUDE.md: only set on actual updates)
--   * Reorder business cols into logical groupings
--
-- Translation changes:
--   * Consolidate split audit clump into canonical order:
--     CreatedBy, CreatedAt, UpdatedBy, UpdatedAt, DeletedBy, DeletedAt
--
-- Apply ONLY to KSS_Person_Prod.

SET QUOTED_IDENTIFIER ON;
SET NOCOUNT ON;
SET XACT_ABORT ON;

DECLARE @system_user UNIQUEIDENTIFIER = '00000000-0000-0000-0000-000000000001';

BEGIN TRANSACTION;

-- ── Step 1: Drop trigger
IF OBJECT_ID('dbo.TR_Translation_DisplayName', 'TR') IS NOT NULL
    DROP TRIGGER dbo.TR_Translation_DisplayName;

-- ── Step 2: Drop 11 incoming FKs to Person
ALTER TABLE dbo.Address       DROP CONSTRAINT FK_Address_Person;
ALTER TABLE dbo.Document      DROP CONSTRAINT FK_Document_Person;
ALTER TABLE dbo.Education     DROP CONSTRAINT FK_Education_Person;
ALTER TABLE dbo.Email         DROP CONSTRAINT FK_Email_Person;
ALTER TABLE dbo.Employment    DROP CONSTRAINT FK_Employment_Person;
ALTER TABLE dbo.Nationality   DROP CONSTRAINT FK_Nationality_Person;
ALTER TABLE dbo.Phone         DROP CONSTRAINT FK_Phone_Person;
ALTER TABLE dbo.Relationship  DROP CONSTRAINT FK_Relationship_Person;
ALTER TABLE dbo.Relationship  DROP CONSTRAINT FK_Relationship_RelatedPerson;
ALTER TABLE dbo.[Status]      DROP CONSTRAINT FK_Status_Person;
ALTER TABLE dbo.[Translation] DROP CONSTRAINT FK_Translation_Person;

-- ── Step 3: Drop Translation, then Person
DROP TABLE dbo.[Translation];
DROP TABLE dbo.Person;

-- ── Step 4: Recreate Person with canonical column order
CREATE TABLE dbo.Person (
    Id                                UNIQUEIDENTIFIER  NOT NULL CONSTRAINT DF_Person_Id DEFAULT (NEWSEQUENTIALID()),
    SexId                             TINYINT           NOT NULL,
    PreferredLanguageId               SMALLINT          NOT NULL,
    NationalId                        VARCHAR(20)       NOT NULL,
    DateOfBirth                       DATE              NOT NULL,
    BirthCountryId                    SMALLINT          NOT NULL,
    BirthRegionId                     SMALLINT          NOT NULL,
    BirthCityId                       INT               NOT NULL,
    BirthCertificateNumber            VARCHAR(20)       NULL,
    BirthCertificateSeriesLetterId    TINYINT           NULL,
    BirthCertificateSeriesNumber      VARCHAR(2)        NULL,
    BirthCertificateSerial            VARCHAR(6)        NULL,
    BirthCertificateIssueCountryId    SMALLINT          NOT NULL CONSTRAINT DF_Person_BCIssueCountryId DEFAULT ((1)),
    BirthCertificateIssueRegionId     SMALLINT          NOT NULL CONSTRAINT DF_Person_BCIssueRegionId  DEFAULT ((1)),
    BirthCertificateIssueCityId       INT               NOT NULL CONSTRAINT DF_Person_BCIssueCityId    DEFAULT ((1)),
    ReligionId                        SMALLINT          NULL     CONSTRAINT DF_Person_ReligionId       DEFAULT ((1)),
    PassportNumber                    VARCHAR(20)       NULL,
    MilitaryServiceStatusId           TINYINT           NULL     CONSTRAINT DF_Person_MilitaryServiceStatusId DEFAULT ((1)),
    MilitaryServiceLocationId         SMALLINT          NULL,
    InsuranceTypeId                   TINYINT           NULL     CONSTRAINT DF_Person_InsuranceTypeId   DEFAULT ((1)),
    InsuranceNumber                   VARCHAR(30)       NULL,
    MaritalStatusId                   TINYINT           NOT NULL CONSTRAINT DF_Person_MaritalStatusId   DEFAULT ((1)),
    CreatedBy                         UNIQUEIDENTIFIER  NOT NULL,
    CreatedAt                         DATETIME2         NOT NULL,
    UpdatedBy                         UNIQUEIDENTIFIER  NULL,
    UpdatedAt                         DATETIME2         NULL,
    DeletedBy                         UNIQUEIDENTIFIER  NULL,
    DeletedAt                         DATETIME2         NULL,
    IsActive                          BIT               NOT NULL CONSTRAINT DF_Person_IsActive          DEFAULT (1),
    CONSTRAINT PK_Person PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_Person_Sex                            FOREIGN KEY (SexId)                          REFERENCES dbo.Sex(Id),
    CONSTRAINT FK_Person_BirthCertificateSeriesLetter   FOREIGN KEY (BirthCertificateSeriesLetterId) REFERENCES dbo.BirthCertificateSeriesLetter(Id),
    CONSTRAINT FK_Person_Religion                       FOREIGN KEY (ReligionId)                     REFERENCES dbo.Religion(Id),
    CONSTRAINT FK_Person_MilitaryServiceLocation        FOREIGN KEY (MilitaryServiceLocationId)      REFERENCES dbo.MilitaryServiceLocation(Id),
    CONSTRAINT FK_Person_InsuranceType                  FOREIGN KEY (InsuranceTypeId)                REFERENCES dbo.InsuranceType(Id),
    CONSTRAINT FK_Person_MaritalStatus                  FOREIGN KEY (MaritalStatusId)                REFERENCES dbo.MaritalStatus(Id)
);

CREATE UNIQUE NONCLUSTERED INDEX IX_Person_NationalId          ON dbo.Person(NationalId);
CREATE NONCLUSTERED INDEX        IX_Person_SexId               ON dbo.Person(SexId);
CREATE NONCLUSTERED INDEX        IX_Person_PreferredLanguageId ON dbo.Person(PreferredLanguageId);
CREATE NONCLUSTERED INDEX        IX_Person_BirthCountryId      ON dbo.Person(BirthCountryId);
CREATE NONCLUSTERED INDEX        IX_Person_BirthRegionId       ON dbo.Person(BirthRegionId);
CREATE NONCLUSTERED INDEX        IX_Person_BirthCityId         ON dbo.Person(BirthCityId);
CREATE NONCLUSTERED INDEX        IX_Person_ReligionId          ON dbo.Person(ReligionId);
CREATE NONCLUSTERED INDEX        IX_Person_InsuranceTypeId     ON dbo.Person(InsuranceTypeId);

-- ── Step 5: Restore Person data from Dev (dynamic SQL — defers binding until after CREATE TABLE runs)
EXEC sp_executesql N'
INSERT INTO dbo.Person (
    Id, SexId, PreferredLanguageId, NationalId, DateOfBirth,
    BirthCountryId, BirthRegionId, BirthCityId,
    BirthCertificateNumber, BirthCertificateSeriesLetterId, BirthCertificateSeriesNumber, BirthCertificateSerial,
    BirthCertificateIssueCountryId, BirthCertificateIssueRegionId, BirthCertificateIssueCityId,
    ReligionId, PassportNumber, MilitaryServiceStatusId, MilitaryServiceLocationId,
    InsuranceTypeId, InsuranceNumber, MaritalStatusId,
    CreatedBy, CreatedAt, UpdatedBy, UpdatedAt, DeletedBy, DeletedAt, IsActive
)
SELECT
    Id, SexId, PreferredLanguageId, NationalId, DateOfBirth,
    BirthCountryId, BirthRegionId, BirthCityId,
    BirthCertificateNumber, BirthCertificateSeriesLetterId, BirthCertificateSeriesNumber, BirthCertificateSerial,
    BirthCertificateIssueCountryId, BirthCertificateIssueRegionId, BirthCertificateIssueCityId,
    ReligionId, PassportNumber, MilitaryServiceStatusId, MilitaryServiceLocationId,
    InsuranceTypeId, InsuranceNumber, MaritalStatusId,
    @sysu, CreatedAt, NULL, NULL, NULL, NULL, 1
FROM KSS_Person_Dev.dbo.Person;
', N'@sysu UNIQUEIDENTIFIER', @sysu = @system_user;

-- ── Step 6: Recreate Translation with canonical column order
CREATE TABLE dbo.[Translation] (
    PersonId      UNIQUEIDENTIFIER  NOT NULL,
    LanguageId    SMALLINT          NOT NULL,
    FirstName     NVARCHAR(50)      NOT NULL,
    LastName      NVARCHAR(50)      NOT NULL,
    FatherName    NVARCHAR(50)      NULL,
    DisplayName   NVARCHAR(100)     NULL,
    CreatedBy     UNIQUEIDENTIFIER  NOT NULL,
    CreatedAt     DATETIME2         NOT NULL,
    UpdatedBy     UNIQUEIDENTIFIER  NULL,
    UpdatedAt     DATETIME2         NULL,
    DeletedBy     UNIQUEIDENTIFIER  NULL,
    DeletedAt     DATETIME2         NULL,
    CONSTRAINT PK_Translation PRIMARY KEY CLUSTERED (PersonId, LanguageId),
    CONSTRAINT FK_Translation_Person FOREIGN KEY (PersonId) REFERENCES dbo.Person(Id) ON DELETE CASCADE
);

CREATE NONCLUSTERED INDEX IX_Translation_LanguageId ON dbo.[Translation](LanguageId);

-- ── Step 7: Restore Translation data from Dev (dynamic SQL — defers binding)
EXEC sp_executesql N'
INSERT INTO dbo.[Translation] (
    PersonId, LanguageId, FirstName, LastName, FatherName, DisplayName,
    CreatedBy, CreatedAt, UpdatedBy, UpdatedAt, DeletedBy, DeletedAt
)
SELECT
    PersonId, LanguageId, FirstName, LastName, FatherName, DisplayName,
    CreatedBy, CreatedAt, UpdatedBy, UpdatedAt, DeletedBy, DeletedAt
FROM KSS_Person_Dev.dbo.[Translation];
';

-- ── Step 8: Recreate trigger
EXEC('
CREATE TRIGGER dbo.TR_Translation_DisplayName ON dbo.[Translation]
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t
       SET DisplayName = RTRIM(t.FirstName + N'' '' + t.LastName)
      FROM dbo.[Translation] t
      INNER JOIN inserted i ON i.PersonId = t.PersonId AND i.LanguageId = t.LanguageId
     WHERE t.DisplayName IS NULL OR t.DisplayName = N'''';
END;
');

-- ── Step 9: Recreate 10 incoming FKs to Person (Translation FK already in step 6)
ALTER TABLE dbo.Address      ADD CONSTRAINT FK_Address_Person      FOREIGN KEY (PersonId)        REFERENCES dbo.Person(Id) ON DELETE CASCADE;
ALTER TABLE dbo.Document     ADD CONSTRAINT FK_Document_Person     FOREIGN KEY (PersonId)        REFERENCES dbo.Person(Id);
ALTER TABLE dbo.Education    ADD CONSTRAINT FK_Education_Person    FOREIGN KEY (PersonId)        REFERENCES dbo.Person(Id);
ALTER TABLE dbo.Email        ADD CONSTRAINT FK_Email_Person        FOREIGN KEY (PersonId)        REFERENCES dbo.Person(Id) ON DELETE CASCADE;
ALTER TABLE dbo.Employment   ADD CONSTRAINT FK_Employment_Person   FOREIGN KEY (PersonId)        REFERENCES dbo.Person(Id) ON DELETE CASCADE;
ALTER TABLE dbo.Nationality  ADD CONSTRAINT FK_Nationality_Person  FOREIGN KEY (PersonId)        REFERENCES dbo.Person(Id) ON DELETE CASCADE;
ALTER TABLE dbo.Phone        ADD CONSTRAINT FK_Phone_Person        FOREIGN KEY (PersonId)        REFERENCES dbo.Person(Id) ON DELETE CASCADE;
ALTER TABLE dbo.Relationship ADD CONSTRAINT FK_Relationship_Person FOREIGN KEY (PersonId)        REFERENCES dbo.Person(Id) ON DELETE CASCADE;
ALTER TABLE dbo.Relationship ADD CONSTRAINT FK_Relationship_RelatedPerson FOREIGN KEY (RelatedPersonId) REFERENCES dbo.Person(Id);
ALTER TABLE dbo.[Status]     ADD CONSTRAINT FK_Status_Person       FOREIGN KEY (PersonId)        REFERENCES dbo.Person(Id) ON DELETE CASCADE;

COMMIT TRANSACTION;

PRINT '009_fix_person_translation_column_order_PROD.sql applied successfully.';
