using GreekSmash.Dtos.Arena;
using GreekSmash.Models;

namespace GreekSmash.Repositories
{
    public interface IArenaRepository
    {
        /// <summary>
        /// Gets all the battle records
        /// </summary>
        /// <returns>list of battle record</returns>
        Task<IEnumerable<ArenaDto>> GetAll();

        /// <summary>
        /// Gets a specified battle record
        /// </summary>
        /// <param name="id">specifies which record to get</param>
        /// <returns>Arena object</returns>
        Task<ArenaDto?> GetArena(int id);

        /// <summary>
        /// Create a new battle record
        /// </summary>
        /// <param name="arena">An object coming from the Body</param>
        /// <returns>id number of newly created record</returns>
        Task<int> CreateArena(Arena arena);

        /// <summary>
        /// Updates a battle record
        /// </summary>
        /// <param name="arena"> Object that contains that updated attributes</param>
        /// <returns>Arena object that is updated</returns>
        Task<bool> UpdateArena(Arena arena);

        /// <summary>
        /// Deletes a record
        /// </summary>
        /// <param name="id"> specifies which record to delete</param>
        /// <returns>A message containing if it is successfull or not</returns>
        Task<bool> DeleteArena(int id);
    }
}
