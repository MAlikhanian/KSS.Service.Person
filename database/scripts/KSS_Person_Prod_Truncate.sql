-- ============================================================
-- Database: KSS_Person_Prod (microservice: person)
-- Delete data from data tables only (child-before-parent order). Lookup/seed tables are left intact.
-- Uses DELETE so FK-referenced parents (Address, Person, etc.) can be cleared; TRUNCATE would fail on them.
-- ============================================================
USE [KSS_Person_Prod];
GO

-- Data tables only: children before parents.
DELETE FROM dbo.[Relationship];
DELETE FROM dbo.[Employment];
DELETE FROM dbo.[AddressTranslation];
DELETE FROM dbo.[Address];
DELETE FROM dbo.[Phone];
DELETE FROM dbo.[Email];
DELETE FROM dbo.[PersonTranslation];
DELETE FROM dbo.[Person];
GO
