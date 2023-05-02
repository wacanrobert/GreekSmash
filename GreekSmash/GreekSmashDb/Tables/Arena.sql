CREATE TABLE [dbo].[Arena]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [HeroId] INT NULL, 
    [VillainId] INT NULL, 
    [LocationId] INT NULL, 
    [Result] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Arena_ToTable] FOREIGN KEY ([HeroId]) REFERENCES [Hero]([Id]), 
    CONSTRAINT [FK_Arena_ToTable_1] FOREIGN KEY ([VillainId]) REFERENCES [Villain]([Id]), 
    CONSTRAINT [FK_Arena_ToTable_2] FOREIGN KEY ([LocationId]) REFERENCES [Location]([Id])
)
