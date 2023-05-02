using GreekSmash.Dtos.Hero;
using AutoMapper;
using GreekSmash.Models;
using GreekSmash.Repositories;

namespace GreekSmash.Services
{   
    public class HeroService : IHeroService
    {
        private readonly IHeroRepository _repository;
        private readonly IMapper _mapper;
        public HeroService(IHeroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<HeroDto> CreateHero(HeroCreationDto heroToCreate)
        {
            var heroModel = _mapper.Map<Hero>(heroToCreate);

            heroModel.Id = await _repository.CreateHero(heroModel);

            return _mapper.Map<HeroDto>(heroModel); 
        }

        public async Task<int> DeleteHero(int id)
        {
            return await _repository.DeleteHero(id);
        }

        public async Task<IEnumerable<HeroDto>> GetAllHeroes()
        {
            var heroModels = await _repository.GetAllHeroes();

            return _mapper.Map<IEnumerable<HeroDto>>(heroModels);
        }

        public async Task<HeroDto> GetHeroById(int id)
        {
            Hero heroModel = await _repository.GetHeroById(id);
            return _mapper.Map<HeroDto>(heroModel);
        }

        public async Task<bool> UpdateHero(HeroDto heroToUpdate)
        {
            var heroModel = _mapper.Map<Hero>(heroToUpdate);

            return await _repository.UpdateHero(heroModel);
        }
    }
}
