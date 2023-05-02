using GreekSmash.Dtos.Location;
using GreekSmash.Models;

namespace GreekSmash.Repositories
{
    public interface ILocationRepository
    {
        /// <summary>
        /// Gets all locations
        /// </summary>
        /// <returns>List of Locations</returns>
        Task<IEnumerable<LocationDto>> GetLocations();
        /// <summary>
        /// Gets all locations
        /// </summary>
        /// <returns>List of Locations</returns>
        Task<IEnumerable<LocationDto>> GetAllLocations();

        /// <summary>
        /// Gets location by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>LocationDto with corresponding id</returns>
        Task<LocationDto> GetLocationById(int id);

        /// <summary>
        /// Creates a new location
        /// </summary>
        /// <param name="location"></param>
        /// <returns>Id of newly created location</returns>
        Task<int> CreateLocation(Location location);

        /// <summary>
        /// Updates a location
        /// </summary>
        /// <param name="location"></param>
        /// <returns>Bool whether location was updated</returns>
        Task<bool> UpdateLocation(Location location);

        /// <summary>
        /// Deletes a location
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Id of newly deleted location</returns>
        Task<int> DeleteLocation(int id);
    }
}
