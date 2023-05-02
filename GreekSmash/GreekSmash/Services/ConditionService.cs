using AutoMapper;
using GreekSmash.Dtos.Condition;
using GreekSmash.Models;
using GreekSmash.Repositories;

namespace GreekSmash.Services
{
    public class ConditionService : IConditionService
    {
        private readonly IConditionRepository _repository;
        private readonly IMapper _mapper;

        public ConditionService(IConditionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ConditionGetterDto> CreateCondition(ConditionCreationDto conditionToCreate)
        {
            //var conditionModel = _mapper.Map<Condition>(conditionToCreate);
            var conditionModel = new Condition
            {
                Description = conditionToCreate.Description,
            };

            conditionModel.Id = await _repository.CreateCondition(conditionModel);

            return _mapper.Map<ConditionGetterDto>(conditionModel);
        }

        public async Task<int> DeleteCondition(int id)
        {
            return await _repository.DeleteCondition(id);
        }
        public async Task<IEnumerable<ConditionDto>> GetConditions()
        {
            var conditionModels = await _repository.GetConditions();

            return _mapper.Map<IEnumerable<ConditionDto>>(conditionModels);
        }
        public async Task<IEnumerable<ConditionDto>> GetAllConditions()
        {
            var conditionModels = await _repository.GetAllConditions();

            return _mapper.Map<IEnumerable<ConditionDto>>(conditionModels);
        }

        public async Task<ConditionDto> GetConditionById(int id)
        {
            var conditionModel = await _repository.GetConditionById(id);
            return _mapper.Map<ConditionDto>(conditionModel);
        }

        public async Task<bool> UpdateCondition(ConditionDto conditionToUpdate)
        {
            var conditionModel = _mapper.Map<Condition>(conditionToUpdate);

            return await _repository.UpdateCondition(conditionModel);
        }
    }
}
