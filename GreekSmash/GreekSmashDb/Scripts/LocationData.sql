USE [GreekSmashDb]
GO

SET IDENTITY_INSERT [dbo].[Location] ON
INSERT [dbo].[Location] ([Id], [Name])
VALUES
	(1, 'Athens'),
	(2, 'Underworld'),
	(3, 'Mt. Olympus'),
	(4, 'Troy'),
	(5, 'River Styx');
SET IDENTITY_INSERT [dbo].[Location] OFF