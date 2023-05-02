USE [GreekSmashDb]
GO


SET IDENTITY_INSERT [dbo].[Arena] ON
INSERT [dbo].[Arena] ([Id], [HeroId], [VillainId], [LocationId], [Result])
VALUES
	(1, 1, 1, 1, 'Perseus Win!'),
	(2, 2, 2, 2, 'Jason Win!')
SET IDENTITY_INSERT [dbo].[Arena] OFF