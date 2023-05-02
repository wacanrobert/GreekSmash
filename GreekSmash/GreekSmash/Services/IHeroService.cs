using GreekSmash.Dtos.Hero;
using GreekSmash.Models;

namespace GreekSmash.Services
{
    public interface IHeroService
    {
        /// <summary>
        /// Get all heroes
        /// </summary>
        /// <returns>All heroes</returns>
        Task<IEnumerable<HeroDto>> GetAllHeroes();
        /// <summary>
        /// Get hero by id  
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HeroDto containing id</returns>
        Task<HeroDto> GetHeroById(int id);
        /// <summary>
        /// Creates a h ero
        /// </summary>
        /// <param name="heroToCreate"></param>
        /// <returns>HeroDto of newly created hero</returns>
        Task<HeroDto> CreateHero(HeroCreationDto heroToCreate);
        /// <summary>
        /// Updates a hero
        /// </summary>
        /// <param name="heroToUpdate"></param>
        /// <returns>Bool wether hero is updated or not</returns>
        Task<bool> UpdateHero(HeroDto heroToUpdate);
        /// <summary>
        /// Deletes a hero  
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Id of the newly deleted hero</returns>
        Task<int> DeleteHero(int id);
    }
}
