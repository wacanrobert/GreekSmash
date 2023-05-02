using AutoMapper;
using GreekSmash.Dtos.Villain;
using GreekSmash.Models;
using GreekSmash.Repositories;

namespace GreekSmash.Services
{
    public class VillainService : IVillainService
    {
        private readonly IVillainRepository _repository;
        private readonly IMapper _mapper;

        public VillainService(IVillainRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<VillainDto> CreateVillain(VillainCreationDto villainToCreate)
        {
            var villainModel = _mapper.Map<Villain>(villainToCreate);

            villainModel.Id = await _repository.CreateVillain(villainModel);

            return _mapper.Map<VillainDto>(villainModel);
        }

        public async Task<int> DeleteVillain(int id)
        {
            return await _repository.DeleteVillain(id);
        }

        public async Task<IEnumerable<VillainDto>> GetAllVillains()
        {
            var villainModels = await _repository.GetAllVillains();

            return _mapper.Map<IEnumerable<VillainDto>>(villainModels);
        }

        public async Task<VillainDto> GetVillainById(int id)
        {
            Villain villainModel = await _repository.GetVillainById(id);
            
            return _mapper.Map<VillainDto>(villainModel);
        }

        public async Task<bool> UpdateVillain(VillainDto villainToUpdate)
        {
            var villainModel = _mapper.Map<Villain>(villainToUpdate);

            return await _repository.UpdateVillain(villainModel);

        }
    }
}
