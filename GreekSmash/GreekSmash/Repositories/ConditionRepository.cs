using Dapper;
using GreekSmash.Context;
using GreekSmash.Dtos.Condition;
using GreekSmash.Dtos.Location;
using GreekSmash.Models;

namespace GreekSmash.Repositories
{
    public class ConditionRepository : IConditionRepository
    {
        private readonly DapperContext _context;

        public ConditionRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<int> CreateCondition(Condition condition)
        {
            var sql = "INSERT INTO Condition (Description) VALUES (@Description); " +
               "SELECT SCOPE_IDENTITY();";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(sql, new {Description = condition.Description});
            }
        }

        public async Task<int> DeleteCondition(int id)
        {
            var sql = "DELETE FROM Condition " +
                "WHERE Id = @Id;";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(sql, new { id });
            }
        }

        public async Task<IEnumerable<ConditionDto>> GetConditions()
        {
            var sql = "SELECT * FROM Condition";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<ConditionDto>(sql);
            }
        }
        public async Task<IEnumerable<ConditionDto>> GetAllConditions()
        {
            var sql = "SELECT * FROM Condition c INNER JOIN LocationCondition lc ON c.Id = lc.ConditionId INNER JOIN Location l on lc.LocationID = l.Id";

            using (var connection = _context.CreateConnection())
            {
                var conditions = await connection.QueryAsync<ConditionDto, LocationGetterDto, ConditionDto>(sql, MapConditionLocation);

                return conditions.GroupBy(p => p.Id).Select(g =>
                {
                    var groupedCondition = g.First();
                    groupedCondition.Locations = g.SelectMany(p => p.Locations).ToList();
                    return groupedCondition;
                });
            }
        }

        public async Task<ConditionDto?> GetConditionById(int id)
        {
            var sql = "SELECT * FROM Condition c INNER JOIN LocationCondition lc ON c.Id = lc.ConditionId INNER JOIN Location l on lc.LocationID = l.Id WHERE c.Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var conditions = await connection.QueryAsync<ConditionDto, LocationGetterDto, ConditionDto>(sql, MapConditionLocation, new { id });

                return conditions.GroupBy(p => p.Id).Select(g =>
                {
                    var groupedCondition = g.First();
                    groupedCondition.Locations = g.SelectMany(p => p.Locations).ToList();
                    return groupedCondition;
                }).SingleOrDefault();
            }
        }

        public async Task<bool> UpdateCondition(Condition condition)
        {
            var sql = "UPDATE Condition SET Description = @Description Where Id = @id";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(sql, new { condition.Description, condition.Id })==1;
            }
        }

        public static ConditionDto MapConditionLocation(ConditionDto condition, LocationGetterDto location)
        {
            condition.Locations.Add(location);
            return condition;
        }
    }
}
