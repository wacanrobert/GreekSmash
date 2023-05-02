using GreekSmash.Dtos.Location;
using GreekSmash.Models;

namespace GreekSmash.Services
{
    public interface ILocationService
    {
        /// <summary>
        /// gets all locations
        /// </summary>
        /// <returns>list of all locations</returns>
        Task<IEnumerable<LocationDto>> GetLocations();
        /// <summary>
        /// gets all locations
        /// </summary>
        /// <returns>list of all locations</returns>
        Task<IEnumerable<LocationDto>> GetAllLocations();

        /// <summary>
        /// gets a location by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>data of the called location</returns>
        Task<LocationDto> GetLocationById(int id);

        /// <summary>
        /// creates a new location
        /// </summary>
        /// <param name="locationToCreate"></param>
        /// <returns>data of the newly created location</returns>
        Task<LocationGetterDto> CreateLocation(LocationCreationDto locationToCreate);

        /// <summary>
        /// updates a location
        /// </summary>
        /// <param name="locationToUpdate"></param>
        /// <returns>true if location if successfully updated</returns>
        Task<bool> UpdateLocation(LocationDto locationToUpdate);

        /// <summary>
        /// deletes a location
        /// </summary>
        /// <param name="id"></param>
        Task<int> DeleteLocation(int id);
    }
}
