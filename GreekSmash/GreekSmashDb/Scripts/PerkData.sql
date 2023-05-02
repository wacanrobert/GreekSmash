USE [GreekSmashDb]
GO


SET IDENTITY_INSERT [dbo].[Perk] ON
INSERT [dbo].[Perk] ([Id], [Name], [Description])
VALUES
	(1, 'Wings of Icarus', 'Triple Jump (3rd jump costs 5% hp'),
	(2, 'Talaria of Mercury', 'More speed, less damage'),
	(3, 'Riptide', 'More damage, less speed'),
	(4, 'Fleeting Time', '20% CD Reduction, less Defense'),
	(5, 'Aegis of Immortality', '+Shield, +20 CD'),
	(6, 'Normie', 'No perk');
SET IDENTITY_INSERT [dbo].[Perk] OFF