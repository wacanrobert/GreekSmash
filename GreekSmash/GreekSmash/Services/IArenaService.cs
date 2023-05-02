using GreekSmash.Dtos.Arena;
using GreekSmash.Models;

namespace GreekSmash.Services
{
    public interface IArenaService
    {
        /// <summary>
        /// Gets all arena record and convert them into ArenaDto
        /// </summary>
        /// <returns>all arena record in ArenaDto format</returns>
        Task<IEnumerable<ArenaDto>> GetAllArena();

        /// <summary>
        /// Gets an arena by its id and converts it into ArenaDto
        /// </summary>
        /// <param name="id">specified which record to access</param>
        /// <returns>ArenaDto version of the arena match</returns>
        Task<ArenaDto?> GetArenaById(int id);

        /// <summary>
        /// Creates Arena record
        /// The winner result is random
        /// The Arena is passed to the CreateArena() in ArenaRepository
        /// </summary>
        /// <param name="arena">object to be created as a arena</param>
        /// <returns>ArenaDto</returns>
        Task<ArenaDto?> CreateArena(ArenaCreationDto arena);

        /// <summary>
        /// Updates an arena by using ArenaUpdateDto
        /// </summary>
        /// <param name="id"> specifies the arena record to update </param>
        /// <param name="arena">ArenaUpdateDto</param>
        /// <returns>true if success update, false if not</returns>
        Task<bool> UpdateArena(int id, ArenaUpdateDto arena);

        /// <summary>
        /// Deletes an arena match by using the id
        /// </summary>
        /// <param name="id">spcifies which record to delete</param>
        /// <returns></returns>
        Task<bool> DeleteArena(int id);

    }
}
