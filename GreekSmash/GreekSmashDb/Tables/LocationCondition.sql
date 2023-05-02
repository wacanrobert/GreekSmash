CREATE TABLE [dbo].[LocationCondition]
(
	[LocationId] INT NULL,
	[ConditionId] INT NULL,
	CONSTRAINT [FK_Location_ToTable] FOREIGN KEY (LocationID) REFERENCES [Location]([Id]),
	CONSTRAINT [FK_Condition_ToTable] FOREIGN KEY (ConditionID) REFERENCES [Condition]([Id])
)
