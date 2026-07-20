CREATE TABLE [Users]
(
    [Id] INT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(150) NOT NULL,
    [Username] NVARCHAR(100) NOT NULL,
    [PasswordHash] NVARCHAR(255) NOT NULL,

    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

CREATE TABLE [Addresses]
(
    [Id] INT IDENTITY(1,1) NOT NULL,
    [Cep] NVARCHAR(9) NOT NULL,
    [Street] NVARCHAR(200) NOT NULL,
    [Complement] NVARCHAR(200) NULL,
    [District] NVARCHAR(150) NOT NULL,
    [City] NVARCHAR(150) NOT NULL,
    [State] NVARCHAR(2) NOT NULL,
    [Number] NVARCHAR(20) NOT NULL,
    [UserId] INT NOT NULL,

    CONSTRAINT [PK_Addresses]
        PRIMARY KEY ([Id]),

    CONSTRAINT [FK_Addresses_Users_UserId]
        FOREIGN KEY ([UserId])
        REFERENCES [Users]([Id])
        ON DELETE CASCADE
);

CREATE INDEX [IX_Addresses_UserId]
ON [Addresses]([UserId]);