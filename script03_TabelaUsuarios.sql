BEGIN TRANSACTION;
ALTER TABLE [TB_PERSONAGENS] ADD [FotoPersonagem] varbinary(max) NULL;

ALTER TABLE [TB_PERSONAGENS] ADD [UsuarioID] int NULL;

CREATE TABLE [TB_ARMAS] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(200) NOT NULL,
    [Dano] int NOT NULL,
    [Raridade] int NOT NULL,
    CONSTRAINT [PK_TB_ARMAS] PRIMARY KEY ([Id])
);

CREATE TABLE [TB_USUARIOS] (
    [Id] int NOT NULL IDENTITY,
    [Username] varchar(200) NOT NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    [Foto] varbinary(max) NULL,
    [Latitude] float NULL,
    [Longitude] float NULL,
    [DataAcesso] datetime2 NULL,
    [Perfil] varchar(200) NULL DEFAULT 'Jogador',
    [Email] varchar(200) NULL,
    CONSTRAINT [PK_TB_USUARIOS] PRIMARY KEY ([Id])
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome', N'Raridade') AND [object_id] = OBJECT_ID(N'[TB_ARMAS]'))
    SET IDENTITY_INSERT [TB_ARMAS] ON;
INSERT INTO [TB_ARMAS] ([Id], [Dano], [Nome], [Raridade])
VALUES (1, 25, 'Tíbia (sim o osso da perna)', 1),
(2, 40, 'Machado de Execução', 2),
(3, 25, 'Cajado Candelabro', 3),
(4, 30, 'Pedaço de Pilar', 3),
(5, 30, 'Pistoleta Trevosa', 1),
(6, 35, 'Foice', 4),
(7, 45, 'Crânio Mágico (sei lá)', 4);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome', N'Raridade') AND [object_id] = OBJECT_ID(N'[TB_ARMAS]'))
    SET IDENTITY_INSERT [TB_ARMAS] OFF;

UPDATE [TB_PERSONAGENS] SET [FotoPersonagem] = NULL, [UsuarioID] = 1
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersonagem] = NULL, [UsuarioID] = 1
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersonagem] = NULL, [UsuarioID] = 1
WHERE [Id] = 3;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersonagem] = NULL, [UsuarioID] = 1
WHERE [Id] = 4;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersonagem] = NULL, [UsuarioID] = 1
WHERE [Id] = 5;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersonagem] = NULL, [UsuarioID] = 1
WHERE [Id] = 6;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersonagem] = NULL, [UsuarioID] = 1
WHERE [Id] = 7;
SELECT @@ROWCOUNT;


IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Email', N'Foto', N'Latitude', N'Longitude', N'PasswordHash', N'PasswordSalt', N'Perfil', N'Username') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] ON;
INSERT INTO [TB_USUARIOS] ([Id], [DataAcesso], [Email], [Foto], [Latitude], [Longitude], [PasswordHash], [PasswordSalt], [Perfil], [Username])
VALUES (1, NULL, 'seuEmail@gmail.com', NULL, -23.520024100000001E0, -46.596497999999997E0, 0x4DF628A2114E3DFDD56DBF7FDD7C50D0A6BD446FCFE810E7AC3411C8731D15F9476615D41D545BFD1B805272301C00E9D0E10C3FC4C41314AFB4B26582B79586, 0xC76285F76E47AC7AAABA5DF08FEBC4B85BD28D0CB1FEFD4D26EE66CBD0BD9C8F95B7A1B04C94FED5DFF90B2F0F35B41B2860DA857B433E5F567BCA0BC3144B9E254922691D4E68665917BCB1B77FF2645E2E77B8032C19ACB2F1E43E9F53910BA01C13E09632F08CD7E1F7E67513733E690ADA5DCEA7D24115C0CD9B5C1D8557, 'Admin', 'UsuarioAdmin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Email', N'Foto', N'Latitude', N'Longitude', N'PasswordHash', N'PasswordSalt', N'Perfil', N'Username') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] OFF;

CREATE INDEX [IX_TB_PERSONAGENS_UsuarioID] ON [TB_PERSONAGENS] ([UsuarioID]);

ALTER TABLE [TB_PERSONAGENS] ADD CONSTRAINT [FK_TB_PERSONAGENS_TB_USUARIOS_UsuarioID] FOREIGN KEY ([UsuarioID]) REFERENCES [TB_USUARIOS] ([Id]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250424002143_MigracaoUsuario', N'9.0.3');

COMMIT;
GO

