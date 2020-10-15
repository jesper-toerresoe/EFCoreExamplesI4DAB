IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Author] (
    [FirstName] nvarchar(450) NOT NULL,
    [LastName] nvarchar(450) NOT NULL,
    [ImageUrl] nvarchar(max) NULL,
    CONSTRAINT [PK_Author] PRIMARY KEY ([FirstName], [LastName])
);

GO

CREATE TABLE [Book] (
    [Isbn] int NOT NULL IDENTITY,
    [price] real NOT NULL,
    [ImageUrl] nvarchar(max) NULL,
    [Title] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [PublishedOn] datetime2 NOT NULL,
    CONSTRAINT [PK_Book] PRIMARY KEY ([Isbn])
);

GO

CREATE TABLE [BookAuthors] (
    [BookAuthorsId] int NOT NULL IDENTITY,
    [BookIsbn] int NOT NULL,
    [AuthorFirstName] nvarchar(450) NULL,
    [AuthorLastName] nvarchar(450) NULL,
    CONSTRAINT [PK_BookAuthors] PRIMARY KEY ([BookAuthorsId]),
    CONSTRAINT [FK_BookAuthors_Book_BookIsbn] FOREIGN KEY ([BookIsbn]) REFERENCES [Book] ([Isbn]) ON DELETE CASCADE,
    CONSTRAINT [FK_BookAuthors_Author_AuthorFirstName_AuthorLastName] FOREIGN KEY ([AuthorFirstName], [AuthorLastName]) REFERENCES [Author] ([FirstName], [LastName]) ON DELETE NO ACTION
);

GO

CREATE TABLE [PriceOffer] (
    [Id] int NOT NULL IDENTITY,
    [NewPrice] real NOT NULL,
    [PromotionText] nvarchar(max) NULL,
    [BookIsbn] int NOT NULL,
    CONSTRAINT [PK_PriceOffer] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PriceOffer_Book_BookIsbn] FOREIGN KEY ([BookIsbn]) REFERENCES [Book] ([Isbn]) ON DELETE CASCADE
);

GO

CREATE TABLE [Review] (
    [Id] int NOT NULL IDENTITY,
    [Votername] nvarchar(max) NULL,
    [Comment] nvarchar(max) NULL,
    [NumStars] int NOT NULL,
    [BookIsbn] int NOT NULL,
    CONSTRAINT [PK_Review] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Review_Book_BookIsbn] FOREIGN KEY ([BookIsbn]) REFERENCES [Book] ([Isbn]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_BookAuthors_BookIsbn] ON [BookAuthors] ([BookIsbn]);

GO

CREATE INDEX [IX_BookAuthors_AuthorFirstName_AuthorLastName] ON [BookAuthors] ([AuthorFirstName], [AuthorLastName]);

GO

CREATE UNIQUE INDEX [IX_PriceOffer_BookIsbn] ON [PriceOffer] ([BookIsbn]);

GO

CREATE INDEX [IX_Review_BookIsbn] ON [Review] ([BookIsbn]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200303090220_InitialMigration', N'3.1.8');

GO

ALTER TABLE [Book] ADD [Isbn13] int NOT NULL DEFAULT 0;

GO

CREATE UNIQUE INDEX [IX_Book_Isbn13] ON [Book] ([Isbn13]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200304075244_a_isbn13_unique', N'3.1.8');

GO

ALTER TABLE [BookAuthors] DROP CONSTRAINT [FK_BookAuthors_Book_BookIsbn];

GO

ALTER TABLE [PriceOffer] DROP CONSTRAINT [FK_PriceOffer_Book_BookIsbn];

GO

ALTER TABLE [Review] DROP CONSTRAINT [FK_Review_Book_BookIsbn];

GO

ALTER TABLE [Book] DROP CONSTRAINT [PK_Book];

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Book]') AND [c].[name] = N'Isbn');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Book] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Book] DROP COLUMN [Isbn];

GO

ALTER TABLE [Book] ADD [Isbn10] int NOT NULL IDENTITY;

GO

ALTER TABLE [Book] ADD CONSTRAINT [PK_Book] PRIMARY KEY ([Isbn10]);

GO

ALTER TABLE [BookAuthors] ADD CONSTRAINT [FK_BookAuthors_Book_BookIsbn] FOREIGN KEY ([BookIsbn]) REFERENCES [Book] ([Isbn10]) ON DELETE CASCADE;

GO

ALTER TABLE [PriceOffer] ADD CONSTRAINT [FK_PriceOffer_Book_BookIsbn] FOREIGN KEY ([BookIsbn]) REFERENCES [Book] ([Isbn10]) ON DELETE CASCADE;

GO

ALTER TABLE [Review] ADD CONSTRAINT [FK_Review_Book_BookIsbn] FOREIGN KEY ([BookIsbn]) REFERENCES [Book] ([Isbn10]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200304075702_bIsbnToIsbn10', N'3.1.8');

GO

CREATE TABLE [Voter] (
    [FirstName] nvarchar(450) NOT NULL,
    [LastName] nvarchar(450) NOT NULL,
    [Email] nvarchar(max) NULL,
    CONSTRAINT [PK_Voter] PRIMARY KEY ([FirstName], [LastName])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200304080034_cCreateVoter', N'3.1.8');

GO

ALTER TABLE [Review] ADD [VoterFirstName] nvarchar(450) NULL;

GO

ALTER TABLE [Review] ADD [VoterLastName] nvarchar(450) NULL;

GO

CREATE INDEX [IX_Review_VoterFirstName_VoterLastName] ON [Review] ([VoterFirstName], [VoterLastName]);

GO

ALTER TABLE [Review] ADD CONSTRAINT [FK_Review_Voter_VoterFirstName_VoterLastName] FOREIGN KEY ([VoterFirstName], [VoterLastName]) REFERENCES [Voter] ([FirstName], [LastName]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200304080547_dReviewVoterRelationship', N'3.1.8');

GO

ALTER TABLE [Book] ADD CONSTRAINT [constraint_pages_positive] CHECK ('pages' > 0);

GO

ALTER TABLE [Book] ADD [Pages] int NOT NULL DEFAULT 0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200304081132_eBookPages', N'3.1.8');

GO

ALTER TABLE [Book] ADD [AuthorFirstName] nvarchar(450) NULL;

GO

ALTER TABLE [Book] ADD [AuthorLastName] nvarchar(450) NULL;

GO

CREATE INDEX [IX_Book_AuthorFirstName_AuthorLastName] ON [Book] ([AuthorFirstName], [AuthorLastName]);

GO

ALTER TABLE [Book] ADD CONSTRAINT [FK_Book_Author_AuthorFirstName_AuthorLastName] FOREIGN KEY ([AuthorFirstName], [AuthorLastName]) REFERENCES [Author] ([FirstName], [LastName]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200304081526_dPrimaryAuthorOnBook', N'3.1.8');

GO

CREATE TABLE [Edition] (
    [ID] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [BookIsbn10] int NOT NULL,
    CONSTRAINT [PK_Edition] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Edition_Book_BookIsbn10] FOREIGN KEY ([BookIsbn10]) REFERENCES [Book] ([Isbn10]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Edition_BookIsbn10] ON [Edition] ([BookIsbn10]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200304083114_gEditionPlusRelationshipToBook', N'3.1.8');

GO

ALTER TABLE [Edition] ADD CONSTRAINT [constraint_edition] CHECK ('name' = 'paperback' OR 'name' = 'e-book' OR 'name' = 'hardback' OR 'name' = 'audio');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200304083205_gAEdtionNameConstrain', N'3.1.8');

GO

ALTER TABLE [Book] ADD [NextBookIsbn10] int NOT NULL DEFAULT 0;

GO

CREATE UNIQUE INDEX [IX_Book_NextBookIsbn10] ON [Book] ([NextBookIsbn10]);

GO

ALTER TABLE [Book] ADD CONSTRAINT [FK_Book_Book_NextBookIsbn10] FOREIGN KEY ([NextBookIsbn10]) REFERENCES [Book] ([Isbn10]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200304083713_hNextInSeries', N'3.1.8');

GO

