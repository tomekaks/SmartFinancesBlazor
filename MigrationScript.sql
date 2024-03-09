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

CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetUsers] (
    [Id] nvarchar(450) NOT NULL,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [IsSuspended] bit NOT NULL,
    [SuspensionReason] nvarchar(max) NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Accounts] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Number] nvarchar(max) NULL,
    [Balance] decimal(18,2) NOT NULL,
    [UserId] nvarchar(450) NULL,
    [Budget] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Accounts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Accounts_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id])
);
GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Contacts] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [AccountNumber] nvarchar(max) NULL,
    [UserId] nvarchar(450) NULL,
    CONSTRAINT [PK_Contacts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Contacts_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id])
);
GO

CREATE TABLE [Expenses] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Amount] decimal(18,2) NOT NULL,
    [Type] int NOT NULL,
    [AccountId] int NOT NULL,
    [IsRegular] bit NOT NULL,
    CONSTRAINT [PK_Expenses] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Expenses_Accounts_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Accounts] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [RegularExpenses] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Amount] decimal(18,2) NOT NULL,
    [Type] int NOT NULL,
    [AccountId] int NOT NULL,
    CONSTRAINT [PK_RegularExpenses] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_RegularExpenses_Accounts_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Accounts] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Transfers] (
    [Id] int NOT NULL IDENTITY,
    [Amount] decimal(18,2) NOT NULL,
    [SendTime] datetime2 NOT NULL,
    [ReceiverName] nvarchar(max) NULL,
    [ReceiverAccountNumber] nvarchar(max) NULL,
    [AccountId] int NOT NULL,
    [Title] nvarchar(max) NULL,
    CONSTRAINT [PK_Transfers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Transfers_Accounts_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Accounts] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Accounts_UserId] ON [Accounts] ([UserId]);
GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
GO

CREATE INDEX [IX_Contacts_UserId] ON [Contacts] ([UserId]);
GO

CREATE INDEX [IX_Expenses_AccountId] ON [Expenses] ([AccountId]);
GO

CREATE INDEX [IX_RegularExpenses_AccountId] ON [RegularExpenses] ([AccountId]);
GO

CREATE INDEX [IX_Transfers_AccountId] ON [Transfers] ([AccountId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230416085045_AddIntialMigration', N'6.0.26');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transfers]') AND [c].[name] = N'Title');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Transfers] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Transfers] ALTER COLUMN [Title] nvarchar(max) NOT NULL;
ALTER TABLE [Transfers] ADD DEFAULT N'' FOR [Title];
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transfers]') AND [c].[name] = N'ReceiverName');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Transfers] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Transfers] ALTER COLUMN [ReceiverName] nvarchar(max) NOT NULL;
ALTER TABLE [Transfers] ADD DEFAULT N'' FOR [ReceiverName];
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transfers]') AND [c].[name] = N'ReceiverAccountNumber');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Transfers] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Transfers] ALTER COLUMN [ReceiverAccountNumber] nvarchar(max) NOT NULL;
ALTER TABLE [Transfers] ADD DEFAULT N'' FOR [ReceiverAccountNumber];
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Expenses]') AND [c].[name] = N'Type');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Expenses] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Expenses] ALTER COLUMN [Type] nvarchar(max) NOT NULL;
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Expenses]') AND [c].[name] = N'Name');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Expenses] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Expenses] ALTER COLUMN [Name] nvarchar(max) NOT NULL;
ALTER TABLE [Expenses] ADD DEFAULT N'' FOR [Name];
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Contacts]') AND [c].[name] = N'Name');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Contacts] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Contacts] ALTER COLUMN [Name] nvarchar(max) NOT NULL;
ALTER TABLE [Contacts] ADD DEFAULT N'' FOR [Name];
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Contacts]') AND [c].[name] = N'AccountNumber');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Contacts] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Contacts] ALTER COLUMN [AccountNumber] nvarchar(max) NOT NULL;
ALTER TABLE [Contacts] ADD DEFAULT N'' FOR [AccountNumber];
GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Accounts]') AND [c].[name] = N'Number');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Accounts] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Accounts] ALTER COLUMN [Number] nvarchar(max) NOT NULL;
ALTER TABLE [Accounts] ADD DEFAULT N'' FOR [Number];
GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Accounts]') AND [c].[name] = N'Name');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Accounts] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [Accounts] ALTER COLUMN [Name] nvarchar(max) NOT NULL;
ALTER TABLE [Accounts] ADD DEFAULT N'' FOR [Name];
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] ON;
INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
VALUES (N'abebd04b-4c91-40ca-a99e-8577ff0f262e', N'f9e93179-5bf2-4efc-ab8a-5694924a4225', N'Administrator', N'ADMINISTRATOR'),
(N'dea03c83-9eae-4ce3-9560-7b3aec0f1b00', N'8aace336-4edd-4cb6-9eb9-80d3e114ef21', N'TestUser', N'TESTUSER'),
(N'ee6ef51f-eaf9-406e-863e-b8012bd7045a', N'd3e34584-d137-4e4e-b577-7dc413b8a759', N'User', N'USER');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'FirstName', N'IsSuspended', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'SuspensionReason', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
    SET IDENTITY_INSERT [AspNetUsers] ON;
INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [FirstName], [IsSuspended], [LastName], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [SuspensionReason], [TwoFactorEnabled], [UserName])
VALUES (N'5330c916-053d-41e6-8a44-b9fe25cf27bf', 0, N'e1e91907-4198-4ffa-9770-f1053f2d389c', N'admin@email.com', CAST(1 AS bit), N'System', CAST(0 AS bit), N'Admin', CAST(0 AS bit), NULL, N'ADMIN@EMAIL.COM', N'ADMIN', N'AQAAAAEAACcQAAAAED4zcGhwQAWCxoDpPdspB2l8gRRVSG6KRepll3+iyHmlc/fG4dYyqf73fP43mllpQQ==', NULL, CAST(0 AS bit), N'4a2d0d9a-d925-49a2-a2e7-6c96e126781f', NULL, CAST(0 AS bit), N'Admin'),
(N'8f095269-a72b-4427-bcaf-d860249770c9', 0, N'5ec2edf2-acac-4c6d-b232-a5b81a5dc987', N'tylerdurden@fightclub.com', CAST(1 AS bit), N'Tyler', CAST(0 AS bit), N'Durden', CAST(0 AS bit), NULL, N'TYLERDURDEN@FIGHTCLUB.COM', N'FIRSTRULE', N'AQAAAAEAACcQAAAAEL1gwcASyHWciU1Pfuj2dIHO/Ip+eUG9UYGcTAZmsy08gasgkBckBqTIL4oy2TDuFw==', NULL, CAST(0 AS bit), N'beaab229-0397-44c6-96aa-fd0d8c33db16', NULL, CAST(0 AS bit), N'FirstRule'),
(N'9ef201b2-999c-4161-8f2b-d7994971e5ee', 0, N'532ad534-7779-4d1f-8dc9-e1a01a6dbc71', N'sarahconor@skynet.com', CAST(1 AS bit), N'Sarah', CAST(0 AS bit), N'Connor', CAST(0 AS bit), NULL, N'SARAHCONNOR@SKYNET.COM', N'ILIKEROBOTS', N'AQAAAAEAACcQAAAAEOnZC6RIxLi313SKcNoxtryDulakH59ZRxWkmHVVwdiMYWdJejVDI8ppPUeohjKU5g==', NULL, CAST(0 AS bit), N'ce2ebf19-2e4a-4112-9a82-a93377feccce', NULL, CAST(0 AS bit), N'ILikeRobots');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'FirstName', N'IsSuspended', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'SuspensionReason', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
    SET IDENTITY_INSERT [AspNetUsers] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
    SET IDENTITY_INSERT [AspNetUserRoles] ON;
INSERT INTO [AspNetUserRoles] ([RoleId], [UserId])
VALUES (N'abebd04b-4c91-40ca-a99e-8577ff0f262e', N'5330c916-053d-41e6-8a44-b9fe25cf27bf');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
    SET IDENTITY_INSERT [AspNetUserRoles] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
    SET IDENTITY_INSERT [AspNetUserRoles] ON;
INSERT INTO [AspNetUserRoles] ([RoleId], [UserId])
VALUES (N'dea03c83-9eae-4ce3-9560-7b3aec0f1b00', N'8f095269-a72b-4427-bcaf-d860249770c9');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
    SET IDENTITY_INSERT [AspNetUserRoles] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
    SET IDENTITY_INSERT [AspNetUserRoles] ON;
INSERT INTO [AspNetUserRoles] ([RoleId], [UserId])
VALUES (N'dea03c83-9eae-4ce3-9560-7b3aec0f1b00', N'9ef201b2-999c-4161-8f2b-d7994971e5ee');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
    SET IDENTITY_INSERT [AspNetUserRoles] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230416085536_AddDatabaseConfigurations', N'6.0.26');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Expenses]') AND [c].[name] = N'IsRegular');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Expenses] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [Expenses] DROP COLUMN [IsRegular];
GO

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Accounts]') AND [c].[name] = N'Name');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Accounts] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [Accounts] DROP COLUMN [Name];
GO

ALTER TABLE [Transfers] ADD [ReceiverId] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Transfers] ADD [SenderAccountNumber] nvarchar(max) NULL;
GO

ALTER TABLE [Transfers] ADD [SenderId] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Transfers] ADD [SenderName] nvarchar(max) NULL;
GO

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[RegularExpenses]') AND [c].[name] = N'Type');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [RegularExpenses] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [RegularExpenses] ALTER COLUMN [Type] nvarchar(max) NOT NULL;
GO

DECLARE @var12 sysname;
SELECT @var12 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[RegularExpenses]') AND [c].[name] = N'Name');
IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [RegularExpenses] DROP CONSTRAINT [' + @var12 + '];');
ALTER TABLE [RegularExpenses] ALTER COLUMN [Name] nvarchar(max) NOT NULL;
ALTER TABLE [RegularExpenses] ADD DEFAULT N'' FOR [Name];
GO

ALTER TABLE [AspNetUsers] ADD [NumberOfAccounts] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Accounts] ADD [Type] nvarchar(max) NULL;
GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'cc646c3d-cac1-414b-90a2-830b11a627fd'
WHERE [Id] = N'abebd04b-4c91-40ca-a99e-8577ff0f262e';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'5ac59f5c-2532-4797-9603-64ca502a7bad'
WHERE [Id] = N'dea03c83-9eae-4ce3-9560-7b3aec0f1b00';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'5bf9bfe4-f5e8-4562-af78-11c8d9fe4140'
WHERE [Id] = N'ee6ef51f-eaf9-406e-863e-b8012bd7045a';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'7bf2ff6e-80c5-4cba-94b3-6cdd8e6aca27', [PasswordHash] = N'AQAAAAEAACcQAAAAEJ8mh5vRqeOMtzhNDp9yF5Ls9F7Yjb7l6hmShDgzLzbMYEUIvOihb03rsD0S/T7hag==', [SecurityStamp] = N'ea8a4001-0493-45b6-80ff-a3e1a6ebf352'
WHERE [Id] = N'5330c916-053d-41e6-8a44-b9fe25cf27bf';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'59865b8f-aeae-449b-a3b9-80ab780a54cd', [PasswordHash] = N'AQAAAAEAACcQAAAAEIqzRZx5/s6DVvLFH1GqhpbpwCQEc91zBipq6TC2FKTCMdQmiqTLJnNm19YH27bH1g==', [SecurityStamp] = N'84f37f77-7d92-46cd-8b87-1626964838a1'
WHERE [Id] = N'8f095269-a72b-4427-bcaf-d860249770c9';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'd4a91669-ff17-4e03-9ceb-af1067495aca', [PasswordHash] = N'AQAAAAEAACcQAAAAELIKYNqzKHa4BqQ8sKObrWhe+3Vhl252iXQF+idfUKz8VhJ1vLt3zRUM5vHCz8++xw==', [SecurityStamp] = N'f132b133-7d94-4568-a502-e9eb103c5663'
WHERE [Id] = N'9ef201b2-999c-4161-8f2b-d7994971e5ee';
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230905133731_ChangesInModels', N'6.0.26');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var13 sysname;
SELECT @var13 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Accounts]') AND [c].[name] = N'Type');
IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [Accounts] DROP CONSTRAINT [' + @var13 + '];');
ALTER TABLE [Accounts] ALTER COLUMN [Type] nvarchar(max) NOT NULL;
ALTER TABLE [Accounts] ADD DEFAULT N'' FOR [Type];
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Balance', N'Budget', N'Number', N'Type', N'UserId') AND [object_id] = OBJECT_ID(N'[Accounts]'))
    SET IDENTITY_INSERT [Accounts] ON;
INSERT INTO [Accounts] ([Id], [Balance], [Budget], [Number], [Type], [UserId])
VALUES (-2, 2000.0, 0.0, N'22BBBB222222', N'Main', N'8f095269-a72b-4427-bcaf-d860249770c9'),
(-1, 2000.0, 0.0, N'11AAAA111111', N'Main', N'9ef201b2-999c-4161-8f2b-d7994971e5ee');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Balance', N'Budget', N'Number', N'Type', N'UserId') AND [object_id] = OBJECT_ID(N'[Accounts]'))
    SET IDENTITY_INSERT [Accounts] OFF;
GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'eaa3e751-bb19-4583-b61a-e2c7dfc0abc0'
WHERE [Id] = N'abebd04b-4c91-40ca-a99e-8577ff0f262e';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'917bb97c-2b00-4efe-a761-a544dbc4b7ca'
WHERE [Id] = N'dea03c83-9eae-4ce3-9560-7b3aec0f1b00';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'b324d314-29ee-4405-9f72-17ac3aa74051'
WHERE [Id] = N'ee6ef51f-eaf9-406e-863e-b8012bd7045a';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'ebb4a702-49a1-44bd-8cff-898ed8440af6', [PasswordHash] = N'AQAAAAEAACcQAAAAEMjLMjg2m0fRsr3X0vugNCJ+J3v5F8Zp1ZsDfDEDaWxljtOz7/NIp6fUyNKduDwwjg==', [SecurityStamp] = N'c961be3e-1d49-4c64-85b3-f7c18a45e9f7'
WHERE [Id] = N'5330c916-053d-41e6-8a44-b9fe25cf27bf';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'dcb5c1b9-ae9f-44bb-a7a4-ff73b2b9ee9c', [PasswordHash] = N'AQAAAAEAACcQAAAAEMlmbIED9jKLM1cgp0jnT5X++BIJR8knlQdLYtG8gr0GgOKUXZ0yzbgZHkroSTIymA==', [SecurityStamp] = N'4c8860f4-5ea2-4296-a449-cfa75033b2cc'
WHERE [Id] = N'8f095269-a72b-4427-bcaf-d860249770c9';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'4159ac76-6a9e-46c1-b7a2-fe7200f807a9', [PasswordHash] = N'AQAAAAEAACcQAAAAEPeJBLD6lkxh5TKF2ksvFSq+iVuIZjdAnUDGaFj/gqU75NJyXXA1J1ttAtDdkYPqYw==', [SecurityStamp] = N'21ca95d5-4c69-4216-aad8-19d269a84bdd'
WHERE [Id] = N'9ef201b2-999c-4161-8f2b-d7994971e5ee';
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230905135833_SeedAccountsForTestUsers', N'6.0.26');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Transfers] DROP CONSTRAINT [FK_Transfers_Accounts_AccountId];
GO

DECLARE @var14 sysname;
SELECT @var14 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transfers]') AND [c].[name] = N'SenderName');
IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [Transfers] DROP CONSTRAINT [' + @var14 + '];');
ALTER TABLE [Transfers] ALTER COLUMN [SenderName] nvarchar(max) NOT NULL;
ALTER TABLE [Transfers] ADD DEFAULT N'' FOR [SenderName];
GO

DECLARE @var15 sysname;
SELECT @var15 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transfers]') AND [c].[name] = N'SenderAccountNumber');
IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [Transfers] DROP CONSTRAINT [' + @var15 + '];');
ALTER TABLE [Transfers] ALTER COLUMN [SenderAccountNumber] nvarchar(max) NOT NULL;
ALTER TABLE [Transfers] ADD DEFAULT N'' FOR [SenderAccountNumber];
GO

DECLARE @var16 sysname;
SELECT @var16 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transfers]') AND [c].[name] = N'AccountId');
IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [Transfers] DROP CONSTRAINT [' + @var16 + '];');
ALTER TABLE [Transfers] ALTER COLUMN [AccountId] int NULL;
GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'a6b145ca-da78-4d25-9dc0-1e44755f207e'
WHERE [Id] = N'abebd04b-4c91-40ca-a99e-8577ff0f262e';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'c72436ac-efd3-4b55-b02a-f6d83a564bff'
WHERE [Id] = N'dea03c83-9eae-4ce3-9560-7b3aec0f1b00';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'b65fb1c8-4fc8-49e5-9e0f-a247f8ce4dcc'
WHERE [Id] = N'ee6ef51f-eaf9-406e-863e-b8012bd7045a';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'a9858349-dda3-4e1b-a739-253ad13ba5d5', [PasswordHash] = N'AQAAAAEAACcQAAAAEMQgChw4L2q2M5Ng+Gp4q4rqKxyKtZpexpEgNplWVC1pDwfRwDZmtVpJf5xsHMBl2A==', [SecurityStamp] = N'49041d5c-6a92-4294-ac1a-d6e348d61e1e'
WHERE [Id] = N'5330c916-053d-41e6-8a44-b9fe25cf27bf';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'63dd4016-e33d-4881-8657-da3475a4e4c3', [PasswordHash] = N'AQAAAAEAACcQAAAAEEUEBaEy7vnNeQi3vfkQ77CYgKBWXuKvgQBIKPv9Noyg4ISfqn0yfN6xC5LLD8kjIg==', [SecurityStamp] = N'64b9786b-088d-4567-a401-6b0d77c564d8'
WHERE [Id] = N'8f095269-a72b-4427-bcaf-d860249770c9';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'8214ad36-9057-48e0-a7ba-441cae22dd79', [PasswordHash] = N'AQAAAAEAACcQAAAAEI5JeQWFrk+ihMLEpPfLMM6fva3a2d0gJY8+k3q1JRT/QawiP17/PUhnkeijsH1zmA==', [SecurityStamp] = N'af915c2a-9d59-4d80-8531-67cfd7445281'
WHERE [Id] = N'9ef201b2-999c-4161-8f2b-d7994971e5ee';
SELECT @@ROWCOUNT;

GO

ALTER TABLE [Transfers] ADD CONSTRAINT [FK_Transfers_Accounts_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Accounts] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230913101211_ChangesInTransferModel', N'6.0.26');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var17 sysname;
SELECT @var17 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transfers]') AND [c].[name] = N'SenderName');
IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [Transfers] DROP CONSTRAINT [' + @var17 + '];');
ALTER TABLE [Transfers] ALTER COLUMN [SenderName] nvarchar(max) NULL;
GO

DECLARE @var18 sysname;
SELECT @var18 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transfers]') AND [c].[name] = N'ReceiverName');
IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [Transfers] DROP CONSTRAINT [' + @var18 + '];');
ALTER TABLE [Transfers] ALTER COLUMN [ReceiverName] nvarchar(max) NULL;
GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'25e8f60d-842a-4f6d-8337-e7ac443399e5'
WHERE [Id] = N'abebd04b-4c91-40ca-a99e-8577ff0f262e';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'f7f956cf-ec3c-446b-8cc9-5c7944b063f1'
WHERE [Id] = N'dea03c83-9eae-4ce3-9560-7b3aec0f1b00';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'241b38eb-6de3-449c-be31-51abf75dd69a'
WHERE [Id] = N'ee6ef51f-eaf9-406e-863e-b8012bd7045a';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'31ae1810-7742-4067-b392-fd3e6f634056', [PasswordHash] = N'AQAAAAEAACcQAAAAECKWD9hFbQyyOgJNqfsCTiDm4uArmHVaSJHfLFu6+i7qp67LBUCesXrTEXAbOjpnBw==', [SecurityStamp] = N'cac1551a-fc51-4d5d-9050-a96a099bb852'
WHERE [Id] = N'5330c916-053d-41e6-8a44-b9fe25cf27bf';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'9086c218-6a38-44c0-abd8-2b4953b7967c', [PasswordHash] = N'AQAAAAEAACcQAAAAEBGhMCi0SoS/x8A2fHifpEubN+Ak/HmLIY4koSHA2cbpYztK0QfOJ3FuGaiWw2378w==', [SecurityStamp] = N'9f02f617-46b6-430f-9ee7-b7bad90b407d'
WHERE [Id] = N'8f095269-a72b-4427-bcaf-d860249770c9';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'a0ad147f-fe35-44f5-91b7-5cd5458fb216', [PasswordHash] = N'AQAAAAEAACcQAAAAEFN1QN6+Z8paGXXQtlYDmS89YI/4xIWgBffxZScNexovfSZyKZLN8O9VLEexztgYbw==', [SecurityStamp] = N'866bc2a5-b550-4109-84a8-ca7215f8c7a2'
WHERE [Id] = N'9ef201b2-999c-4161-8f2b-d7994971e5ee';
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230913110530_RemovedIsRequiredFromSenderAndReceiversName', N'6.0.26');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var19 sysname;
SELECT @var19 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Expenses]') AND [c].[name] = N'Type');
IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [Expenses] DROP CONSTRAINT [' + @var19 + '];');
ALTER TABLE [Expenses] DROP COLUMN [Type];
GO

ALTER TABLE [Expenses] ADD [ExpenseTypeId] int NOT NULL DEFAULT 0;
GO

CREATE TABLE [ExpenseTypes] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(255) NOT NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_ExpenseTypes] PRIMARY KEY ([Id])
);
GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'004accd9-f7cd-43f6-a090-e0d8334fba19'
WHERE [Id] = N'abebd04b-4c91-40ca-a99e-8577ff0f262e';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'66c02032-e626-4ee2-bf35-cf4387205c68'
WHERE [Id] = N'dea03c83-9eae-4ce3-9560-7b3aec0f1b00';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'909b097d-8ee1-42e5-a781-ac8a7160cd82'
WHERE [Id] = N'ee6ef51f-eaf9-406e-863e-b8012bd7045a';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'b9a54a0e-67b5-421d-b71f-0eed7090704d', [PasswordHash] = N'AQAAAAEAACcQAAAAEBrYZ1I/3mYr25oOObFHYMlz+KiV6mnXofa3lU6FqGpwcZP626GQaMbrrh+eMFsf0w==', [SecurityStamp] = N'47fb63ee-81a8-4e85-8d13-3f561c0a44d7'
WHERE [Id] = N'5330c916-053d-41e6-8a44-b9fe25cf27bf';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'd5c63552-0801-4af4-8e9c-a26b01140b2e', [PasswordHash] = N'AQAAAAEAACcQAAAAEKD90HSRTEeY4T0YGNvsvG2b5XaDCDqqW4PjrLBNhxawCn8CdGoe8mGOVyJ4CPvGfQ==', [SecurityStamp] = N'eea9451a-a3a6-4119-8062-6b4b71a3a73a'
WHERE [Id] = N'8f095269-a72b-4427-bcaf-d860249770c9';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'4b937ae9-181b-4a4f-9e62-407c04551bdc', [PasswordHash] = N'AQAAAAEAACcQAAAAEC1mm97Etniexzs0oVvQvtpnotpENx3WQLgGcvjKMPA1qfyfA3KRoVbkoen8AgKLZQ==', [SecurityStamp] = N'dc625e36-0a4b-4fb7-8c57-e0bc7898d314'
WHERE [Id] = N'9ef201b2-999c-4161-8f2b-d7994971e5ee';
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name') AND [object_id] = OBJECT_ID(N'[ExpenseTypes]'))
    SET IDENTITY_INSERT [ExpenseTypes] ON;
INSERT INTO [ExpenseTypes] ([Id], [Description], [Name])
VALUES (1, NULL, N'Housing'),
(2, NULL, N'Utilities'),
(3, NULL, N'Food'),
(4, NULL, N'Clothes'),
(5, NULL, N'Health'),
(6, NULL, N'Entertainment'),
(7, NULL, N'Transportation'),
(8, NULL, N'Personal'),
(9, NULL, N'Household');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name') AND [object_id] = OBJECT_ID(N'[ExpenseTypes]'))
    SET IDENTITY_INSERT [ExpenseTypes] OFF;
GO

CREATE INDEX [IX_Expenses_ExpenseTypeId] ON [Expenses] ([ExpenseTypeId]);
GO

CREATE UNIQUE INDEX [IX_ExpenseTypes_Name] ON [ExpenseTypes] ([Name]);
GO

ALTER TABLE [Expenses] ADD CONSTRAINT [FK_Expenses_ExpenseTypes_ExpenseTypeId] FOREIGN KEY ([ExpenseTypeId]) REFERENCES [ExpenseTypes] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230923133758_AddExpenseTypeTable', N'6.0.26');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var20 sysname;
SELECT @var20 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[RegularExpenses]') AND [c].[name] = N'Type');
IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [RegularExpenses] DROP CONSTRAINT [' + @var20 + '];');
ALTER TABLE [RegularExpenses] DROP COLUMN [Type];
GO

ALTER TABLE [RegularExpenses] ADD [ExpenseTypeId] int NOT NULL DEFAULT 0;
GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'bbe75fd4-e4dc-460c-9c6c-9a6850a9624c'
WHERE [Id] = N'abebd04b-4c91-40ca-a99e-8577ff0f262e';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'319c9377-76fb-4f3e-8fa0-12c0adaa4562'
WHERE [Id] = N'dea03c83-9eae-4ce3-9560-7b3aec0f1b00';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'5fc8850d-ca35-47cb-9d06-4a41e7f4c5b9'
WHERE [Id] = N'ee6ef51f-eaf9-406e-863e-b8012bd7045a';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'4d2233bf-c060-4ad2-801b-ee2d2b1a5baf', [PasswordHash] = N'AQAAAAEAACcQAAAAEDoSFJshobXAF4xgNqrjIrQLCCCltJR5H4+Zn/qLJbyANt6zpsRsWCXj4zvb2VqOhA==', [SecurityStamp] = N'c4e865ed-0f7d-470b-9738-54fa879e7a1d'
WHERE [Id] = N'5330c916-053d-41e6-8a44-b9fe25cf27bf';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'af1a1e78-a725-4494-971f-86e71b4b0a61', [PasswordHash] = N'AQAAAAEAACcQAAAAEARSl68Xqm/T3NWlJWNZg2tg6NA0TGZPEyaHXkB4WBW90wIpzGsIP1tcciTjacT+ag==', [SecurityStamp] = N'4a225e47-5590-404a-bad5-d2fa2f1f6026'
WHERE [Id] = N'8f095269-a72b-4427-bcaf-d860249770c9';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'4809da27-eb11-4ba8-83e3-5de476770f06', [PasswordHash] = N'AQAAAAEAACcQAAAAED2jQRvu2EB/omS1ds9ntWOg7PCSGeyJ6vHc19vI3UmlTCw7t75f0jvtGpJR0QFBKA==', [SecurityStamp] = N'd8cbfd95-2045-4968-af86-cad5ea9b1a39'
WHERE [Id] = N'9ef201b2-999c-4161-8f2b-d7994971e5ee';
SELECT @@ROWCOUNT;

GO

CREATE INDEX [IX_RegularExpenses_ExpenseTypeId] ON [RegularExpenses] ([ExpenseTypeId]);
GO

ALTER TABLE [RegularExpenses] ADD CONSTRAINT [FK_RegularExpenses_ExpenseTypes_ExpenseTypeId] FOREIGN KEY ([ExpenseTypeId]) REFERENCES [ExpenseTypes] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231005092153_RefactoredRegularExpenseToUseExpenseType', N'6.0.26');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var21 sysname;
SELECT @var21 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Accounts]') AND [c].[name] = N'Type');
IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [Accounts] DROP CONSTRAINT [' + @var21 + '];');
ALTER TABLE [Accounts] ALTER COLUMN [Type] int NOT NULL;
GO

UPDATE [Accounts] SET [Type] = 1
WHERE [Id] = -2;
SELECT @@ROWCOUNT;

GO

UPDATE [Accounts] SET [Type] = 1
WHERE [Id] = -1;
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'fd8a923a-cab1-424d-94a9-a5fdb6e36f84'
WHERE [Id] = N'abebd04b-4c91-40ca-a99e-8577ff0f262e';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'791c9e43-a64f-437d-b2c2-de2431772d76'
WHERE [Id] = N'dea03c83-9eae-4ce3-9560-7b3aec0f1b00';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'b4f079c7-12fc-4a79-b234-91ccf62e76a1'
WHERE [Id] = N'ee6ef51f-eaf9-406e-863e-b8012bd7045a';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'b8b3d5fa-286e-4233-a2f7-ffdf645c7b57', [PasswordHash] = N'AQAAAAEAACcQAAAAEIwH5zBG1K6h3PZ1oiXphAUb0KfoLhVJYEkH3zj15QDP9y1HapRERhiBKSNs3F1ANw==', [SecurityStamp] = N'cecbb5f9-43de-4c39-8ba4-83273fb9bb21'
WHERE [Id] = N'5330c916-053d-41e6-8a44-b9fe25cf27bf';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'2a2b3577-2a0c-4bec-97d5-35df2b93fe1e', [PasswordHash] = N'AQAAAAEAACcQAAAAEHzoaPVYpO/CCt/viidunroe32/CxIQ/obIKN/HvTDyIwvjcC01BH+j4U+CkekjuMw==', [SecurityStamp] = N'48991d5f-06b8-45f0-997d-352cb507dc12'
WHERE [Id] = N'8f095269-a72b-4427-bcaf-d860249770c9';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'04ca9541-e3f0-4d48-b2c7-9ac87cdfadb3', [PasswordHash] = N'AQAAAAEAACcQAAAAEJnW5v89WHwEZwXkp+SlJcCfwfTS7R2N4vhYMHMwwPzE1v9gy/TL4mI6/4YK7TVNaA==', [SecurityStamp] = N'98145324-ef67-485b-a1cb-097b6dcd3ec2'
WHERE [Id] = N'9ef201b2-999c-4161-8f2b-d7994971e5ee';
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231021143100_ChangedTypeProperyInAccountToInt', N'6.0.26');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'64487dc0-f202-44ed-ac93-1217d7d1a1b6'
WHERE [Id] = N'abebd04b-4c91-40ca-a99e-8577ff0f262e';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'de929e7e-8463-456f-bb32-18be75a368bf'
WHERE [Id] = N'dea03c83-9eae-4ce3-9560-7b3aec0f1b00';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'43eaeca9-bf6d-41a2-aff4-d00232f42751'
WHERE [Id] = N'ee6ef51f-eaf9-406e-863e-b8012bd7045a';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'8693463e-043a-48f4-ae88-6b6f97dd717f', [PasswordHash] = N'AQAAAAEAACcQAAAAEA1Do+WSW83eoJ4uRouf86dSbGMNcBYvdxtGhxGy9gxkfmf89L+ng6FKjvkpDaVPhg==', [SecurityStamp] = N'c40035e8-3757-4350-a15f-8cee30a4ff56'
WHERE [Id] = N'5330c916-053d-41e6-8a44-b9fe25cf27bf';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'688d64a0-b347-4d42-bc64-3bd4ad6c48f9', [PasswordHash] = N'AQAAAAEAACcQAAAAEJRuCA72xmaDNGx+zHM+gPRKzj3zKqzZvLJzkCkwnJp7QHh3d4nvWne9JLzd/1gPrQ==', [SecurityStamp] = N'02d06423-2b32-40b2-b29b-8cb2bdae6d16'
WHERE [Id] = N'8f095269-a72b-4427-bcaf-d860249770c9';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'49b3945c-0b1f-48fc-a2bc-af6809108348', [PasswordHash] = N'AQAAAAEAACcQAAAAEMT5UQTCKm+NIDmaBsXKsixcgMzjIEVqep93EP8IIgjs+EOFRQcg3fx2WPb88432lw==', [SecurityStamp] = N'dfde8a92-52f4-4692-8c5e-c8b73be648d3'
WHERE [Id] = N'9ef201b2-999c-4161-8f2b-d7994971e5ee';
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231021143740_SeedDataAgain', N'6.0.26');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Balance', N'Budget', N'Number', N'Type', N'UserId') AND [object_id] = OBJECT_ID(N'[Accounts]'))
    SET IDENTITY_INSERT [Accounts] ON;
INSERT INTO [Accounts] ([Id], [Balance], [Budget], [Number], [Type], [UserId])
VALUES (-4, 2000.0, 0.0, N'44DDDD444444', 3, N'8f095269-a72b-4427-bcaf-d860249770c9'),
(-3, 2000.0, 0.0, N'33CCCC333333', 2, N'9ef201b2-999c-4161-8f2b-d7994971e5ee');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Balance', N'Budget', N'Number', N'Type', N'UserId') AND [object_id] = OBJECT_ID(N'[Accounts]'))
    SET IDENTITY_INSERT [Accounts] OFF;
GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'5e28ea23-b28f-4910-abe3-7c65463d93c3'
WHERE [Id] = N'abebd04b-4c91-40ca-a99e-8577ff0f262e';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'6d7f4618-4b62-4e1c-b091-7c58f267d22e'
WHERE [Id] = N'dea03c83-9eae-4ce3-9560-7b3aec0f1b00';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'4e65cc54-6a89-4531-9692-3f951223fa57'
WHERE [Id] = N'ee6ef51f-eaf9-406e-863e-b8012bd7045a';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'b6b9fcb9-1a6d-4a19-8114-0d29a9c3e1d9', [PasswordHash] = N'AQAAAAEAACcQAAAAEFRIAkFYI6LQPMClkXwLejIFuMIfa3KEINjPxa5olTjrjxKO4z4r/UbMt8/+ijX8JQ==', [SecurityStamp] = N'aaec16bd-6053-4b97-901f-77d0c5c25094'
WHERE [Id] = N'5330c916-053d-41e6-8a44-b9fe25cf27bf';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'e6109c1e-3514-496e-bd82-3695953627bb', [PasswordHash] = N'AQAAAAEAACcQAAAAEIC9EMxB3NWprqPHT4kUE/b43+Lu24uuBngGNVo+4PE97hz8kW1hCtSVACfwAwFTqQ==', [SecurityStamp] = N'9527b3e6-f36b-4a16-903c-c0eadef42ed1'
WHERE [Id] = N'8f095269-a72b-4427-bcaf-d860249770c9';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'182a75fa-1cc0-4a8d-b024-940fe81ff72f', [PasswordHash] = N'AQAAAAEAACcQAAAAEKXw8VyV6GEhPy8AyTc5aP+FdFTFGXZe9mNKG3QVpf0KP/gk4Wcn5lFQ/zcdUbv7Hg==', [SecurityStamp] = N'f2abdcfd-d8de-4c33-a9b4-454d06d65bca'
WHERE [Id] = N'9ef201b2-999c-4161-8f2b-d7994971e5ee';
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231028125459_SeedMoreAccounts', N'6.0.26');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Expenses] DROP CONSTRAINT [FK_Expenses_Accounts_AccountId];
GO

EXEC sp_rename N'[Expenses].[AccountId]', N'MonthlySummaryId', N'COLUMN';
GO

EXEC sp_rename N'[Expenses].[IX_Expenses_AccountId]', N'IX_Expenses_MonthlySummaryId', N'INDEX';
GO

CREATE TABLE [YearlySummaries] (
    [Id] int NOT NULL IDENTITY,
    [Year] int NOT NULL,
    [Budget] decimal(18,2) NOT NULL,
    [AmountSpent] decimal(18,2) NOT NULL,
    [AmountSaved] decimal(18,2) NOT NULL,
    [AccountId] int NOT NULL,
    CONSTRAINT [PK_YearlySummaries] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_YearlySummaries_Accounts_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Accounts] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [MonthlySummaries] (
    [Id] int NOT NULL IDENTITY,
    [Month] int NOT NULL,
    [Year] int NOT NULL,
    [Budget] decimal(18,2) NOT NULL,
    [AmountSpent] decimal(18,2) NOT NULL,
    [AmountSaved] decimal(18,2) NOT NULL,
    [YearlySummaryId] int NOT NULL,
    CONSTRAINT [PK_MonthlySummaries] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_MonthlySummaries_YearlySummaries_YearlySummaryId] FOREIGN KEY ([YearlySummaryId]) REFERENCES [YearlySummaries] ([Id]) ON DELETE CASCADE
);
GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'6e2ddc07-da93-4d5e-b34b-8a076a568cdf'
WHERE [Id] = N'abebd04b-4c91-40ca-a99e-8577ff0f262e';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'38be67b5-6a6d-4209-a11e-757dd02a9177'
WHERE [Id] = N'dea03c83-9eae-4ce3-9560-7b3aec0f1b00';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'fde9113c-52b7-496a-ad0c-4b1077a77d29'
WHERE [Id] = N'ee6ef51f-eaf9-406e-863e-b8012bd7045a';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'7ebd2c48-af2b-482e-88cc-ba071a0c0691', [PasswordHash] = N'AQAAAAEAACcQAAAAENx+5GwFuux9EhtmWy+PPYqmcaU5m0qqBxd/A2ZNQ5nfeW5KxdLo1k4BQz16n9fO5A==', [SecurityStamp] = N'861d6332-c348-4367-ab14-cc585be60a30'
WHERE [Id] = N'5330c916-053d-41e6-8a44-b9fe25cf27bf';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'bc7b4e7c-164e-40ad-9db4-55e390a0ecbe', [PasswordHash] = N'AQAAAAEAACcQAAAAEIrcwZkDQFK9tT3G/VUHVB8cL1fCHOfYhJoo3Y9HWsKel29QzUAw45DqX1wCf/JLHw==', [SecurityStamp] = N'83b58101-62a8-4772-8df7-237b04ce759a'
WHERE [Id] = N'8f095269-a72b-4427-bcaf-d860249770c9';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'59f8773c-7c42-42a1-8563-14d34d8bb305', [PasswordHash] = N'AQAAAAEAACcQAAAAEJIzWSV+7JkstFV/Wpzr8nSap2041VNH5KOJw/ZjSgeydZI7NdXVi64XhLzAL+7teg==', [SecurityStamp] = N'9f429d6f-fcae-472f-8e9b-329477c9e7fb'
WHERE [Id] = N'9ef201b2-999c-4161-8f2b-d7994971e5ee';
SELECT @@ROWCOUNT;

GO

CREATE INDEX [IX_MonthlySummaries_YearlySummaryId] ON [MonthlySummaries] ([YearlySummaryId]);
GO

CREATE INDEX [IX_YearlySummaries_AccountId] ON [YearlySummaries] ([AccountId]);
GO

ALTER TABLE [Expenses] ADD CONSTRAINT [FK_Expenses_MonthlySummaries_MonthlySummaryId] FOREIGN KEY ([MonthlySummaryId]) REFERENCES [MonthlySummaries] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231202135912_AddYearlyAndMonthlySummariesTables', N'6.0.26');
GO

COMMIT;
GO

