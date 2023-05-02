using AutoMapper;
using GreekSmash.Dtos.Arena;
using GreekSmash.Models;
using GreekSmash.Repositories;

namespace GreekSmash.Services
{
    public class ArenaService : IArenaService
    {
        private readonly IArenaRepository _repository;
        private readonly IHeroRepository _heroRepository;
        private readonly IVillainRepository _villainRepository;
        private readonly IMapper _mapper;

        public ArenaService(IArenaRepository repository, 
                            IHeroRepository heroRepository, 
                            IVillainRepository villainRepository,
                            IMapper mapper)
        {
            _repository = repository;
            _heroRepository = heroRepository;
            _villainRepository = villainRepository;
            _mapper = mapper;
        }

        public async Task<ArenaDto?> CreateArena(ArenaCreationDto newArena)
        {
            var arenaModel = new Arena
            {
                Hero = await _heroRepository.GetHeroById(newArena.HeroId),
                Villain = await _villainRepository.GetVillainById(newArena.VillainId),
                Location = new Location { Id = newArena.LocationId }
            };
            if(arenaModel.Hero == null || arenaModel.Villain == null || 
                    arenaModel.Location == null)
            {
                return null;
            }

            arenaModel.Result = RandomWinner(arenaModel);
            arenaModel.Id = await _repository.CreateArena(arenaModel);
            var arena = await _repository.GetArena(arenaModel.Id);
            return _mapper.Map<ArenaDto>(arena);
        }

        
        public async Task<IEnumerable<ArenaDto>> GetAllArena()
        {
            var allArena = await _repository.GetAll();
            return _mapper.Map<IEnumerable<ArenaDto>>(allArena);
        }

        public async Task<ArenaDto?> GetArenaById(int id)
        {
            var arena = await _repository.GetArena(id);
            if (arena == null)
                return null;

            return _mapper.Map<ArenaDto>(arena); ;
        }

        public async Task<bool> UpdateArena(int id, ArenaUpdateDto arenaUpd)
        {
            var arena = new Arena
            {
                Id = id,
                Result = arenaUpd.Result
            };
            return await _repository.UpdateArena(arena);
        }
        public async Task<bool> DeleteArena(int id)
        {
            return await _repository.DeleteArena(id);
        }

        /// <summary>
        /// Generates a random winner when creating a arena record
        /// Random winner for now because it needs to be played in order to win
        /// </summary>
        /// <param name="arena"> the created arena record</param>
        /// <returns>a string containing the winner</returns>
        public String RandomWinner(Arena arena)
        {
            Random r = new Random();
            int rand = r.Next(1, 3);
            if (rand == 1)
                return arena.Hero?.Name + " Win!";
            else
                return arena.Villain?.Name + " Win!";
        }
    }
}