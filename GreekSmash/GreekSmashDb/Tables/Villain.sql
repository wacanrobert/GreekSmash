CREATE TABLE [dbo].[Villain]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [PerkId] INT NULL, 
    [Weapon] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_Villain_ToTable] FOREIGN KEY ([PerkId]) REFERENCES [Perk]([Id])
)
