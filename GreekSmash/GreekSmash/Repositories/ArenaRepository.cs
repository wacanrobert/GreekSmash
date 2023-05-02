using Dapper;
using GreekSmash.Context;
using GreekSmash.Dtos.Arena;
using GreekSmash.Dtos.Condition;
using GreekSmash.Dtos.Location;
using GreekSmash.Models;
using System.Data;

namespace GreekSmash.Repositories
{
    public class ArenaRepository : IArenaRepository
    {
        private readonly DapperContext _context;

        public ArenaRepository(DapperContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new match in arena
        /// </summary>
        /// <param name="arena">arena match to be created</param>
        /// <returns>id number of newly created arena match</returns>
        public async Task<int> CreateArena(Arena arena)
        {
            var sql = "INSERT INTO Arena (HeroId, VillainId, LocationId, Result) " +
                "Values (@HeroId, @VillainId, @LocationId, @Result); " +
                "SELECT SCOPE_IDENTITY();";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(sql,
                    new { HeroId = arena.Hero?.Id, VillainId = arena.Villain?.Id, LocationId = arena.Location?.Id, arena.Result });
            }
        }

        /// <summary>
        /// Gets all the arena matches
        /// </summary>
        /// <returns>all arena matches</returns>
        public async Task<IEnumerable<ArenaDto>> GetAll()
        {
            var sql = "[spArena_GetAllRecord]";

            using (var connection = _context.CreateConnection())
            {
                var allArena = await connection.QueryAsync<ArenaDto, Hero, Villain, LocationDto, ConditionGetterDto, ArenaDto>(
                                sql,
                                MapArenaHeroVillainLocationCondition,
                                commandType: CommandType.StoredProcedure);

                return allArena.GroupBy(a => a.Id).Select(b =>
                {
                    var firstAre = b.First();
                    firstAre.Location!.Conditions = b.SelectMany(arena => arena.Location!.Conditions).ToList();
                    return firstAre;
                });
            }
        }

        /// <summary>
        /// Gets the arena match according to id
        /// </summary>
        /// <param name="id">specifies the arena match to get</param>
        /// <returns>arena match</returns>
        public async Task<ArenaDto?> GetArena(int id)
        {
            var sql = "[spArena_GetAllArenaRecordById]";

            using (var connection = _context.CreateConnection())
            {
                var arena = await connection.QueryAsync<ArenaDto, Hero, Villain, LocationDto, ConditionGetterDto, ArenaDto>(
                            sql,
                            MapArenaHeroVillainLocationCondition,
                            new { Id = id },
                            commandType: CommandType.StoredProcedure);

                return arena.GroupBy(a => a.Id).Select(b =>
                {
                    var firstAre = b.First();
                    firstAre.Location!.Conditions = b.SelectMany(arena => arena.Location!.Conditions).ToList();
                    return firstAre;
                }).SingleOrDefault();
            }
        }

        /// <summary>
        /// Updates an arena match
        /// Only the Result can be updated
        /// </summary>
        /// <param name="arena">the arena match to be updated </param>
        /// <returns> true if success update otherwise false </returns>
        public async Task<bool> UpdateArena(Arena arena)
        {
            var sql = "UPDATE Arena SET Result = @Result WHERE Id = @Id;";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(sql, new { Result = arena.Result, Id = arena.Id }) > 0;
            }
        }

        /// <summary>
        /// Deletes an arena match
        /// </summary>
        /// <param name="id">specifies the arena match to be deleted</param>
        /// <returns>true if success delete otherwise false</returns>
        public async Task<bool> DeleteArena(int id)
        {
            var sql = "DELETE FROM Arena WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(sql, new { Id = id }) > 0;
            }
        }

        /// <summary>
        /// helper function to map the parameters
        /// </summary>
        /// <param name="arena">Arena</param>
        /// <param name="hero">Hero</param>
        /// <param name="villain">Villain</param>
        /// <param name="location">Location</param>
        /// <param name="condition">Condition</param>
        /// <returns>arena</returns>
        public static ArenaDto MapArenaHeroVillainLocationCondition
            (ArenaDto arena, Hero hero, Villain villain, LocationDto location, ConditionGetterDto condition)
        {
            arena.Hero = hero;
            arena.Villain = villain;
            location.Conditions.Add(condition);
            arena.Location = location;
            return arena;
        }

    }
}