USE [GreekSmashDb]
GO

SET IDENTITY_INSERT [dbo].[Hero] ON
INSERT [dbo].[Hero] ([Id], [Name], [PerkID], [Weapon], [Description])
VALUES
	(1, 'Perseus', 6, 'Harpe', 'The Slayer of the Gorgon Medusa, Son of Zeus'),
	(2, 'Jason', 6, 'Argo Sword', 'Hero and leader of the Argonauts'),
	(3, 'Achilles', 6, 'Meteor Spear', 'The greatest warrior of the army of Agamemnon'),
	(4, 'Orpheus', 6, 'Lyre', 'Hero endowed with superhuman musical skills'),
	(5, 'Heracles', 6, 'Golden Mace', 'God of strength and heroes'),
	(6, 'Icarus', 6, 'Wings', 'The boy who flew close to the sun'),
	(7, 'Orion', 6, 'Bow and Arrow', 'A Demigod and a great hunter'),
	(8, 'Kratos', 6, 'Blades of Chaos', 'God of War, Ghost of Sparta');
SET IDENTITY_INSERT [dbo].[Hero] OFF