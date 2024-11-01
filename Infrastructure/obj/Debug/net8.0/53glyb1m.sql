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

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241031002454_init'
)
BEGIN
    CREATE TABLE [Casts] (
        [Id] int NOT NULL IDENTITY,
        [Gender] VARCHAR(MAX) NOT NULL,
        [Name] VARCHAR(128) NOT NULL,
        [ProfilePath] VARCHAR(2084) NOT NULL,
        [TmdbUrl] VARCHAR(MAX) NOT NULL,
        CONSTRAINT [PK_Casts] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241031002454_init'
)
BEGIN
    CREATE TABLE [Genres] (
        [Id] int NOT NULL IDENTITY,
        [Name] VARCHAR(24) NOT NULL,
        CONSTRAINT [PK_Genres] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241031002454_init'
)
BEGIN
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
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241031002454_init'
)
BEGIN
    CREATE TABLE [Roles] (
        [Id] int NOT NULL IDENTITY,
        [Name] VARCHAR(20) NOT NULL,
        CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241031002454_init'
)
BEGIN
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
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241031002454_init'
)
BEGIN
    CREATE TABLE [MovieCasts] (
        [CastId] int NOT NULL,
        [Character] VARCHAR(450) NOT NULL,
        [MovieId] int NOT NULL,
        CONSTRAINT [PK_MovieCasts] PRIMARY KEY ([CastId], [Character], [MovieId]),
        CONSTRAINT [FK_MovieCasts_Casts_CastId] FOREIGN KEY ([CastId]) REFERENCES [Casts] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_MovieCasts_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241031002454_init'
)
BEGIN
    CREATE TABLE [MovieGenres] (
        [GenreId] int NOT NULL,
        [MovieId] int NOT NULL,
        CONSTRAINT [PK_MovieGenres] PRIMARY KEY ([GenreId], [MovieId]),
        CONSTRAINT [FK_MovieGenres_Genres_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genres] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_MovieGenres_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241031002454_init'
)
BEGIN
    CREATE TABLE [Trailers] (
        [Id] int NOT NULL IDENTITY,
        [MovieId] int NOT NULL,
        [Name] VARCHAR(2084) NOT NULL,
        [TrailerUrl] VARCHAR(2084) NOT NULL,
        CONSTRAINT [PK_Trailers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Trailers_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241031002454_init'
)
BEGIN
    CREATE TABLE [Favorites] (
        [MovieId] int NOT NULL,
        [UserId] int NOT NULL,
        CONSTRAINT [PK_Favorites] PRIMARY KEY ([MovieId], [UserId]),
        CONSTRAINT [FK_Favorites_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Favorites_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241031002454_init'
)
BEGIN
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
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241031002454_init'
)
BEGIN
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
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241031002454_init'
)
BEGIN
    CREATE TABLE [UserRole] (
        [RoleId] int NOT NULL,
        [UserId] int NOT NULL,
        CONSTRAINT [PK_UserRole] PRIMARY KEY ([RoleId], [UserId]),
        CONSTRAINT [FK_UserRole_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_UserRole_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241031002454_init'
)
BEGIN
    CREATE INDEX [IX_Favorites_UserId] ON [Favorites] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241031002454_init'
)
BEGIN
    CREATE INDEX [IX_MovieCasts_MovieId] ON [MovieCasts] ([MovieId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241031002454_init'
)
BEGIN
    CREATE INDEX [IX_MovieGenres_MovieId] ON [MovieGenres] ([MovieId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241031002454_init'
)
BEGIN
    CREATE INDEX [IX_Purchases_UserId] ON [Purchases] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241031002454_init'
)
BEGIN
    CREATE INDEX [IX_Reviews_UserId] ON [Reviews] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241031002454_init'
)
BEGIN
    CREATE INDEX [IX_Trailers_MovieId] ON [Trailers] ([MovieId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241031002454_init'
)
BEGIN
    CREATE INDEX [IX_UserRole_UserId] ON [UserRole] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241031002454_init'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241031002454_init', N'8.0.10');
END;
GO

COMMIT;
GO

