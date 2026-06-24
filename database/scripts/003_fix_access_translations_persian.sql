-- 003_fix_access_translations_persian.sql
--
-- Fix mojibake-corrupted Persian seed data in two orphan lookup translation tables.
--
-- Affected tables (Dev + Prod):
--   AccessStatusTranslation         — 4 corrupted Persian rows (LanguageId 12)
--   AccessPermissionLevelTranslation — 3 corrupted Persian rows (LanguageId 12)
--
-- Root cause: original seed inserted Persian without the `N'...'` literal prefix,
-- so the bytes were stored as Latin-1 codepoints instead of Unicode.
--
-- Fix: DELETE all rows (English + Persian) and re-INSERT with proper N-prefixed
-- Unicode literals. English rows are also re-inserted to keep the operation idempotent.
--
-- Apply to BOTH KSS_Person_Dev and KSS_Person_Prod via:
--   sqlcmd ... -i 003_fix_access_translations_persian.sql -f 65001 -I

SET QUOTED_IDENTIFIER ON;
SET NOCOUNT ON;

BEGIN TRANSACTION;

-- ── AccessStatusTranslation ────────────────────────────────────────────
DELETE FROM dbo.AccessStatusTranslation;

INSERT INTO dbo.AccessStatusTranslation (AccessStatusId, LanguageId, Name) VALUES
    (1, 10, 'Pending'),
    (1, 12, N'در انتظار'),
    (2, 10, 'Active'),
    (2, 12, N'فعال'),
    (3, 10, 'Revoked'),
    (3, 12, N'لغو شده'),
    (4, 10, 'Expired'),
    (4, 12, N'منقضی شده');

-- ── AccessPermissionLevelTranslation ──────────────────────────────────
DELETE FROM dbo.AccessPermissionLevelTranslation;

INSERT INTO dbo.AccessPermissionLevelTranslation (AccessPermissionLevelId, LanguageId, Name) VALUES
    (1, 10, 'View'),
    (1, 12, N'مشاهده'),
    (2, 10, 'Edit'),
    (2, 12, N'ویرایش'),
    (3, 10, 'Full'),
    (3, 12, N'دسترسی کامل');

COMMIT TRANSACTION;

PRINT '003_fix_access_translations_persian.sql applied successfully.';
