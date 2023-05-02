using Dapper;
using GreekSmash.Context;
using GreekSmash.Models;
using Microsoft.VisualBasic;
using System.Net;

namespace GreekSmash.Repositories
{
    public class VillainRepository : IVillainRepository
    {
        private readonly DapperContext _context;

        public VillainRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<int> CreateVillain(Villain villain)
        {
            var sql = "INSERT INTO Villain (Name, PerkId, Weapon, Description) VALUES (@Name, @PerkId, @Weapon, @Description); " +
                "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, villain);
            }
        }

        public async Task<int> DeleteVillain(int id)
        {
            var sql = "DELETE from Villain WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<IEnumerable<Villain>> GetAllVillains()
        {
            var sql = "SELECT * FROM Villain";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<Villain>(sql);
            }
        }

        public async Task<Villain> GetVillainById(int id)
        {
            var sql = "SELECT * FROM Villain where Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Villain>(sql, new { id });
            }
        }

        public async Task<bool> UpdateVillain(Villain villain)
        {
            var sql = "UPDATE Villain SET Name = @Name,PerkId = @PerkId, Weapon = @Weapon, Description = @Description Where Id = @id";
            
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(sql, new { villain.Name, villain.PerkId, villain.Weapon, villain.Description, villain.Id })==1;
            }
        }
    }
}
