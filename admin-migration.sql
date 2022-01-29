IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Organisations] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(128) NOT NULL,
    CONSTRAINT [PK_Organisations] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] uniqueidentifier NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Name] nvarchar(128) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [OrganisationMembers] (
    [OrganisationId] uniqueidentifier NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_OrganisationMembers] PRIMARY KEY ([OrganisationId], [UserId]),
    CONSTRAINT [FK_OrganisationMembers_Organisations_OrganisationId] FOREIGN KEY ([OrganisationId]) REFERENCES [Organisations] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrganisationMembers_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_OrganisationMembers_UserId] ON [OrganisationMembers] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220127090725_InitialMigration', N'5.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Organisations]'))
    SET IDENTITY_INSERT [Organisations] ON;
INSERT INTO [Organisations] ([Id], [Name])
VALUES ('00000000-0000-0000-0000-de00000000de', N'00000000-0000-0000-0000-DE00000000DE');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Organisations]'))
    SET IDENTITY_INSERT [Organisations] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Name') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([Id], [Email], [Name])
VALUES ('00000000-0000-0000-0000-ad00000000ad', N'admin@admin.com', N'admin user');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Name') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'OrganisationId', N'UserId') AND [object_id] = OBJECT_ID(N'[OrganisationMembers]'))
    SET IDENTITY_INSERT [OrganisationMembers] ON;
INSERT INTO [OrganisationMembers] ([OrganisationId], [UserId])
VALUES ('00000000-0000-0000-0000-de00000000de', '00000000-0000-0000-0000-ad00000000ad');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'OrganisationId', N'UserId') AND [object_id] = OBJECT_ID(N'[OrganisationMembers]'))
    SET IDENTITY_INSERT [OrganisationMembers] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220127093237_InitialAdminSeedMigration', N'5.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [Organisations] SET [Name] = N'dev organisation'
WHERE [Id] = '00000000-0000-0000-0000-de00000000de';
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220127093742_FixAdminSeedMigration', N'5.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Organisations]'))
    SET IDENTITY_INSERT [Organisations] ON;
INSERT INTO [Organisations] ([Id], [Name])
VALUES ('00000000-0000-0000-0000-b000000000b0', N'manager organisation');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Organisations]'))
    SET IDENTITY_INSERT [Organisations] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'OrganisationId', N'UserId') AND [object_id] = OBJECT_ID(N'[OrganisationMembers]'))
    SET IDENTITY_INSERT [OrganisationMembers] ON;
INSERT INTO [OrganisationMembers] ([OrganisationId], [UserId])
VALUES ('00000000-0000-0000-0000-b000000000b0', '00000000-0000-0000-0000-ad00000000ad');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'OrganisationId', N'UserId') AND [object_id] = OBJECT_ID(N'[OrganisationMembers]'))
    SET IDENTITY_INSERT [OrganisationMembers] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220127094335_AddNewOrganisationSeedMigration', N'5.0.13');
GO

COMMIT;
GO

