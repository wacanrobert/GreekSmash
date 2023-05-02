using GreekSmash.Models;

namespace GreekSmash.Repositories
{
    public interface IHeroRepository
    {
        /// <summary>
        /// Get all Heroes
        /// </summary>
        /// <returns>All Heroes</returns>
        Task<IEnumerable<Hero>> GetAllHeroes();

        /// <summary>
        /// Get hero by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Hero with the said id</returns>
        Task<Hero> GetHeroById(int id);

        /// <summary>
        /// Creates a hero
        /// </summary>
        /// <param name="hero"></param>
        /// <returns>Id of the new hero</returns>
        Task<int> CreateHero(Hero hero);

        /// <summary>
        /// Updates a hero
        /// </summary>
        /// <param name="hero"></param>
        /// <returns>bool wether hero is updated or not</returns>
        Task<bool> UpdateHero(Hero hero);

        /// <summary>
        /// Deletes a hero
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Id of the deleted hero</returns>
        Task<int> DeleteHero(int id);

    }
}
