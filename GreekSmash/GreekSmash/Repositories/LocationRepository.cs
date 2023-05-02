using Dapper;
using GreekSmash.Context;
using GreekSmash.Dtos.Condition;
using GreekSmash.Dtos.Location;
using GreekSmash.Models;
using Microsoft.Extensions.Hosting;

namespace GreekSmash.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly DapperContext _context;

        public LocationRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<int> CreateLocation(Location location)
        {
            var sql = "INSERT INTO Location (Name) VALUES (@Name); " +
                "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, location);
            }
        }

        public async Task<int> DeleteLocation(int id)
        {
            var sql = "DELETE FROM Location " +
                "WHERE Id = @Id;";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(sql, new {id});
            }
        }

        public async Task<IEnumerable<LocationDto>> GetLocations()
        {
            var sql = "SELECT * FROM Location";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<LocationDto>(sql);
            }
        }
        public async Task<IEnumerable<LocationDto>> GetAllLocations()
        {
            var sql = "SELECT * FROM Location l INNER JOIN LocationCondition lc ON l.Id = lc.LocationId INNER JOIN Condition c on lc.ConditionId = c.Id";

            using (var connection = _context.CreateConnection())
            {
                var locations = await connection.QueryAsync<LocationDto, ConditionGetterDto, LocationDto>(sql, MapLocationCondition);

                return locations.GroupBy(p => p.Id).Select(g =>
                {
                    var groupedLocation = g.First();
                    groupedLocation.Conditions = g.SelectMany(p => p.Conditions).ToList();
                    return groupedLocation;
                });
            }
        }

        public async Task<LocationDto> GetLocationById(int id)
        {
            var sql = "SELECT * FROM Location l INNER JOIN LocationCondition lc ON l.Id = lc.LocationId INNER JOIN Condition c on lc.ConditionId = c.Id WHERE l.Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var locations = await connection.QueryAsync<LocationDto, ConditionGetterDto, LocationDto>(sql, MapLocationCondition, new { id });

                return locations.GroupBy(p => p.Id).Select(g =>
                {
                    var groupedLocation = g.First();
                    groupedLocation.Conditions = g.SelectMany(p => p.Conditions).ToList();
                    return groupedLocation;
                }).Single();
            }
        }

        public async Task<bool> UpdateLocation(Location location)
        {
            var sql = "UPDATE Location SET Name = @Name Where Id = @id";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(sql, new { location.Name, location.Id })==1;
            }
        }

        public static LocationDto MapLocationCondition (LocationDto location, ConditionGetterDto condition)
        {
            location.Conditions.Add(condition);
            return location;
        }
    }
}
