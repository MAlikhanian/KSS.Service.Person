-- =============================================================================
-- Migration 014 — protect global RoleAccess rows
-- =============================================================================
-- Global RoleAccess rows (PersonId IS NULL) define system-wide visibility for
-- admin-style roles (SuperAdmin, PersonAdmin, etc.). Losing them locks every
-- non-admin user out of the person list. They MUST not be deleted at runtime.
--
-- The application-layer guard lives in RoleAccessService.UpsertGrantAsync /
-- RevokeByPairAsync. This trigger is a defensive second layer that catches
-- raw SQL or any bypass of the service layer.
--
-- The trigger only blocks DELETEs targeting global rows. Per-person rows
-- (PersonId IS NOT NULL) delete normally.
-- =============================================================================
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO

IF OBJECT_ID(N'dbo.trg_RoleAccess_ProtectGlobals', N'TR') IS NOT NULL
    DROP TRIGGER dbo.trg_RoleAccess_ProtectGlobals;
GO

CREATE TRIGGER dbo.trg_RoleAccess_ProtectGlobals
ON dbo.RoleAccess
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM deleted WHERE PersonId IS NULL)
    BEGIN
        RAISERROR ('Global RoleAccess rows (PersonId IS NULL) are immutable — manage via versioned migrations only.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END;

    -- Per-person rows pass through.
    DELETE r
    FROM dbo.RoleAccess r
    INNER JOIN deleted d ON r.Id = d.Id;
END;
GO
