USE [GreekSmashDb]
GO

SET IDENTITY_INSERT [dbo].[Villain] ON
INSERT [dbo].[Villain] ([Id], [Name], [PerkId], [Weapon], [Description])
VALUES
	(1, 'Minotaur', 6, 'Heavy Axe', 'Guardian of the Labyrinth'), 
	(2, 'Medusa', 6, 'Eye of Petrification', 'Snake-haired Gorgon'), 
	(3, 'Kraken', 6, 'Tentacles', 'Sea monster of tremendous size and strength'), 
	(4, 'Hydra', 6, 'Poisonous Breathe', 'Gigantic monster with nine heads'),
	(5, 'Cronus', 6, 'Scythe', 'King of Titans and God of time'), 
	(6, 'Cyclops', 6, 'Giant Mace', 'A one-eyed giant monster'), 
	(7, 'Cerberus', 6, 'Fangs', 'The monstrous watchdog of the Underworld'),
	(8, 'Giants', 6, 'Heavy Sword', 'A race of great strength and aggression'); 
SET IDENTITY_INSERT [dbo].[Villain] OFF