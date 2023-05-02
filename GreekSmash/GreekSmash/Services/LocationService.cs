using AutoMapper;
using GreekSmash.Dtos.Location;
using GreekSmash.Models;
using GreekSmash.Repositories;

namespace GreekSmash.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _repository;
        private readonly IMapper _mapper;

        public LocationService(ILocationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<LocationGetterDto> CreateLocation(LocationCreationDto locationToCreate)
        {
            var locationModel = _mapper.Map<Location>(locationToCreate);

            locationModel.Id = await _repository.CreateLocation(locationModel);

            return _mapper.Map<LocationGetterDto>(locationModel);
        }

        public async Task<int> DeleteLocation(int id)
        {
            return await _repository.DeleteLocation(id);
        }

        public async Task<IEnumerable<LocationDto>> GetAllLocations()
        {
            return await _repository.GetAllLocations();
        }
        public async Task<IEnumerable<LocationDto>> GetLocations()
        {
            return await _repository.GetLocations();
        }

        public async Task<LocationDto> GetLocationById(int id)
        {
            var locationModel = await _repository.GetLocationById(id);

            return _mapper.Map<LocationDto>(locationModel);
        }

        public async Task<bool> UpdateLocation(LocationDto locationToUpdate)
        {
            var locationModel = _mapper.Map<Location>(locationToUpdate);

            return await _repository.UpdateLocation(locationModel);
        }
    }
}
