    CREATE TABLE [dbo].[Hero]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [PerkID] INT NULL, 
    [Weapon] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_Hero_ToTable] FOREIGN KEY ([PerkID]) REFERENCES [Perk]([Id])
)
