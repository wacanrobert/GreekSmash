using Dapper;
using GreekSmash.Context;
using GreekSmash.Models;

namespace GreekSmash.Repositories
{
    public class HeroRepository : IHeroRepository
    {
        private readonly DapperContext _context;

        public HeroRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<int> CreateHero(Hero hero)
        {
            var sql = "INSERT INTO Hero (Name, PerkId, Weapon, Description) " +
                "Values (@Name, @PerkId, @Weapon, @Description); " +
                "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, hero);
            }
        }

        public async Task<int> DeleteHero(int id)
        {
            var sql = "DELETE from Hero WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<IEnumerable<Hero>> GetAllHeroes()
        {
            var sql = "SELECT * FROM Hero";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<Hero>(sql);
            }
        }

        public async Task<Hero> GetHeroById(int id)         
        {
            var sql = "SELECT * FROM Hero where Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Hero>(sql, new { id });
            }
        }

        public async Task<bool> UpdateHero(Hero hero)
        {
            var sql = "UPDATE Hero SET Name = @Name,PerkId = @PerkId, Weapon = @Weapon, Description = @Description Where Id = @id";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(sql, new { hero.Name, hero.PerkID, hero.Weapon, hero.Description, hero.Id }) == 1;
            }
        }
    }
}
