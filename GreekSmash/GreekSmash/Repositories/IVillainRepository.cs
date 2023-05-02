using GreekSmash.Models;

namespace GreekSmash.Repositories
{
    public interface IVillainRepository
    {
        /// <summary>
        /// Get all villains
        /// </summary>
        /// <returns>All villains</returns>
        Task<IEnumerable<Villain>> GetAllVillains();

        /// <summary>
        /// Gets villain by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Villain with the containing the id</returns>
        Task<Villain> GetVillainById(int id);

        /// <summary>
        /// Creates a villain
        /// </summary>
        /// <param name="villain"></param>
        /// <returns>Id of newly created villain</returns>
        Task<int> CreateVillain(Villain villain);

        /// <summary>
        /// Updates a villain
        /// </summary>
        /// <param name="villain"></param>
        /// <returns>bool whether villain is updated or not</returns>
        Task<bool> UpdateVillain(Villain villain);

        /// <summary>
        /// Deletes a villain
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Id of newly deleted villain</returns>
        Task<int> DeleteVillain(int id);
    }
}
