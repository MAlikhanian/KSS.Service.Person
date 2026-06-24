-- 006_rename_documenttype_PROD.sql
--
-- Drop trailing 's' on the two outlier tables to match the rest of the DB:
--   DocumentTypes            → DocumentType
--   DocumentTypeTranslations → DocumentTypeTranslation
-- Also rename the FK + index whose names embed the old plural form so the
-- naming stays consistent.
--
-- Apply ONLY to KSS_Person_Prod.

SET QUOTED_IDENTIFIER ON;
SET NOCOUNT ON;

BEGIN TRANSACTION;

EXEC sp_rename 'dbo.DocumentTypes',                       'DocumentType';
EXEC sp_rename 'dbo.DocumentTypeTranslations',            'DocumentTypeTranslation';

EXEC sp_rename 'dbo.FK_Documents_DocumentTypes',           'FK_Documents_DocumentType', 'OBJECT';
EXEC sp_rename 'dbo.DocumentType.IX_DocumentTypes_Code',   'IX_DocumentType_Code',       'INDEX';
EXEC sp_rename 'DF_DocumentTypes_IsActive',                'DF_DocumentType_IsActive';

COMMIT TRANSACTION;

PRINT '006_rename_documenttype_PROD.sql applied successfully.';
