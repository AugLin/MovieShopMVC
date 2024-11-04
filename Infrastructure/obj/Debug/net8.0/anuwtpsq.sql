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

CREATE TABLE [Casts] (
    [Id] int NOT NULL IDENTITY,
    [Gender] VARCHAR(MAX) NOT NULL,
    [Name] VARCHAR(128) NOT NULL,
    [ProfilePath] VARCHAR(2084) NOT NULL,
    [TmdbUrl] VARCHAR(MAX) NOT NULL,
    CONSTRAINT [PK_Casts] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Genres] (
    [Id] int NOT NULL IDENTITY,
    [Name] VARCHAR(24) NOT NULL,
    CONSTRAINT [PK_Genres] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Movies] (
    [Id] int NOT NULL IDENTITY,
    [BackdropUrl] VARCHAR(2084) NULL,
    [Budget] DECIMAL(18,4) NULL,
    [CreatedBy] VARCHAR(MAX) NULL,
    [CreatedDate] datetime2 NULL,
    [ImdbUrl] VARCHAR(2084) NULL,
    [OriginalLanguage] VARCHAR(64) NULL,
    [Overview] VARCHAR(MAX) NULL,
    [PosterUrl] VARCHAR(2084) NULL,
    [Price] DECIMAL(5,2) NULL,
    [ReleaseDate] datetime2 NOT NULL,
    [Revenue] DECIMAL(18,4) NULL,
    [Runtime] int NULL,
    [Tagline] VARCHAR(512) NULL,
    [Title] VARCHAR(256) NULL,
    [TmdbUrl] VARCHAR(2084) NULL,
    [UpdatedBy] VARCHAR(MAX) NULL,
    [UpdatedDate] datetime2 NULL,
    CONSTRAINT [PK_Movies] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Roles] (
    [Id] int NOT NULL IDENTITY,
    [Name] VARCHAR(20) NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [DateOfBirth] datetime2 NOT NULL,
    [Email] VARCHAR(256) NOT NULL,
    [FirstName] VARCHAR(128) NOT NULL,
    [HashedPassword] VARCHAR(1024) NOT NULL,
    [IsLocked] int NOT NULL,
    [LastName] VARCHAR(128) NOT NULL,
    [PhoneNumber] VARCHAR(16) NULL,
    [ProfilePictureUrl] VARCHAR(MAX) NULL,
    [Salt] VARCHAR(1024) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [MovieCasts] (
    [CastId] int NOT NULL,
    [Character] VARCHAR(450) NOT NULL,
    [MovieId] int NOT NULL,
    CONSTRAINT [PK_MovieCasts] PRIMARY KEY ([CastId], [Character], [MovieId]),
    CONSTRAINT [FK_MovieCasts_Casts_CastId] FOREIGN KEY ([CastId]) REFERENCES [Casts] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_MovieCasts_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [MovieGenres] (
    [GenreId] int NOT NULL,
    [MovieId] int NOT NULL,
    CONSTRAINT [PK_MovieGenres] PRIMARY KEY ([GenreId], [MovieId]),
    CONSTRAINT [FK_MovieGenres_Genres_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genres] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_MovieGenres_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Trailers] (
    [Id] int NOT NULL IDENTITY,
    [MovieId] int NOT NULL,
    [Name] VARCHAR(2084) NOT NULL,
    [TrailerUrl] VARCHAR(2084) NOT NULL,
    CONSTRAINT [PK_Trailers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Trailers_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Favorites] (
    [MovieId] int NOT NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_Favorites] PRIMARY KEY ([MovieId], [UserId]),
    CONSTRAINT [FK_Favorites_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Favorites_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Purchases] (
    [MovieId] int NOT NULL,
    [UserId] int NOT NULL,
    [PurchaseTime] datetime2 NOT NULL,
    [PurchaseNumber] UNIQUEIDENTIFIER  NOT NULL,
    [TotalPrice] DECIMAL(5,2) NOT NULL,
    CONSTRAINT [PK_Purchases] PRIMARY KEY ([MovieId], [UserId]),
    CONSTRAINT [FK_Purchases_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Purchases_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Reviews] (
    [MovieId] int NOT NULL,
    [UserId] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [Rating] DECIMAL(3,2) NOT NULL,
    [ReviewText] VARCHAR(MAX) NOT NULL,
    CONSTRAINT [PK_Reviews] PRIMARY KEY ([MovieId], [UserId]),
    CONSTRAINT [FK_Reviews_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Reviews_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [UserRole] (
    [RoleId] int NOT NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY ([RoleId], [UserId]),
    CONSTRAINT [FK_UserRole_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserRole_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Favorites_UserId] ON [Favorites] ([UserId]);
GO

CREATE INDEX [IX_MovieCasts_MovieId] ON [MovieCasts] ([MovieId]);
GO

CREATE INDEX [IX_MovieGenres_MovieId] ON [MovieGenres] ([MovieId]);
GO

CREATE INDEX [IX_Purchases_UserId] ON [Purchases] ([UserId]);
GO

CREATE INDEX [IX_Reviews_UserId] ON [Reviews] ([UserId]);
GO

CREATE INDEX [IX_Trailers_MovieId] ON [Trailers] ([MovieId]);
GO

CREATE INDEX [IX_UserRole_UserId] ON [UserRole] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241031002454_init', N'8.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Order] (
    [Id] int NOT NULL IDENTITY,
    [Order_Date] datetime2 NOT NULL,
    [CustomerName] VARCHAR(2084) NOT NULL,
    [PaymentMethod] VARCHAR(2084) NOT NULL,
    [PaymentName] VARCHAR(2084) NOT NULL,
    [ShippingAddress] VARCHAR(2084) NOT NULL,
    [ShippingMethod] VARCHAR(2084) NOT NULL,
    [BillAmount] DECIMAL(5,2) NOT NULL,
    [Order_Status] VARCHAR(2084) NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Order_Detail] (
    [Id] int NOT NULL IDENTITY,
    [OrderId] int NOT NULL,
    [ProductId] int NOT NULL,
    [ProductName] VARCHAR(2084) NOT NULL,
    [Quantity] int NOT NULL,
    [Price] DECIMAL(5,2) NOT NULL,
    [Discount] DECIMAL(3,2) NOT NULL,
    CONSTRAINT [PK_Order_Detail] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Order_Detail_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Order] ([Id]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_Order_Detail_OrderId] ON [Order_Detail] ([OrderId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241104195732_Update_Order', N'8.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Order] ADD [CustomerId] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241104200725_Update_Order1', N'8.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP INDEX [IX_Order_Detail_OrderId] ON [Order_Detail];
GO

CREATE INDEX [IX_Order_Detail_OrderId] ON [Order_Detail] ([OrderId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241104201701_Update_Order2', N'8.0.10');
GO

COMMIT;
GO

