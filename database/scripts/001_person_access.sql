-- Migration: 001_person_access.sql
-- Creates the PersonAccess table that drives the Person Access Management feature.
-- A row in PersonAccess means: the person identified by GrantedToPersonId
-- has the given AccessLevel (1=View, 2=Edit) over the profile of PersonId.
--
-- An older empty PersonAccess table existed with a different schema
-- (PermissionLevelId, AccessStatusId, StartDate, EndDate, Notes …).
-- Since it contained no rows in either Dev or Prod, we drop and recreate
-- it with the schema this feature requires.

IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PersonAccess]') AND type = N'U')
BEGIN
    DROP TABLE [dbo].[PersonAccess];
END
GO

CREATE TABLE [dbo].[PersonAccess]
(
    [Id]                  UNIQUEIDENTIFIER NOT NULL,
    [PersonId]            UNIQUEIDENTIFIER NOT NULL,
    [GrantedToPersonId]   UNIQUEIDENTIFIER NOT NULL,
    [AccessLevel]         INT              NOT NULL,
    [CreatedAt]           DATETIME2(7)     NOT NULL,
    [UpdatedAt]           DATETIME2(7)     NULL,
    [CreatedBy]           UNIQUEIDENTIFIER NOT NULL,
    [UpdatedBy]           UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_PersonAccess] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE UNIQUE INDEX [UX_PersonAccess_Person_GrantedTo]
    ON [dbo].[PersonAccess] ([PersonId] ASC, [GrantedToPersonId] ASC);
GO
