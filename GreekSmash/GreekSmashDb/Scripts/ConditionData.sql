USE [GreekSmashDb]
GO


SET IDENTITY_INSERT [dbo].[Condition] ON
INSERT [dbo].[Condition] ([Id], [Description])
VALUES
	(1, 'Enable drops'),
	(2, 'More gravity'),
	(3, 'Less gravity'),
	(4, '2x Speed'),
	(5, 'Enable traps');
SET IDENTITY_INSERT [dbo].[Condition] OFF