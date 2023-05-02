CREATE PROCEDURE spArena_GetAllRecord
AS
BEGIN
	SELECT a.*, h.*, v.*, l.*, c.* FROM Arena a 
	Inner JOIN Hero h ON a.HeroId = h.Id 
	INNER JOIN Villain v ON a.VillainId = v.Id 
	INNER JOIN Location l ON a.LocationId = l.Id 
	INNER JOIN LocationCondition lc ON l.Id = lc.LocationId 
	INNER JOIN Condition c ON lc.ConditionId = c.Id;
END
