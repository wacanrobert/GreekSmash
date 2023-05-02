using GreekSmash.Dtos.Villain;
using GreekSmash.Models;

namespace GreekSmash.Services
{
    public interface IVillainService
    {
        /// <summary>
        /// Get all villains
        /// </summary>
        /// <returns>All villains</returns>
        Task<IEnumerable<VillainDto>> GetAllVillains();

        /// <summary>
        /// Get villain by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>VillainDto containing id</returns>
        Task<VillainDto> GetVillainById(int id);

        /// <summary>
        /// Creates a villain
        /// </summary>
        /// <param name="villainToCreate"></param>
        /// <returns>VillainDto of newly created villain</returns>
        Task<VillainDto> CreateVillain(VillainCreationDto villainToCreate);

        /// <summary>
        /// Updates a villain
        /// </summary>
        /// <param name="villainToUpdate"></param>
        /// <returns>Bool wether villain is updated or not</returns>
        Task<bool> UpdateVillain(VillainDto villainToUpdate);

        /// <summary>
        /// Deletes a villain
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Id of newly deleted villain</returns>
        Task<int> DeleteVillain(int id);
    }
}
