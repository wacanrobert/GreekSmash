using GreekSmash.Dtos.Condition;
using GreekSmash.Dtos.Location;

namespace GreekSmash.Services
{
    public interface IConditionService
    {
        /// <summary>
        /// Gets all conditions
        /// </summary>
        /// <returns>list of all conditions in the database</returns>
        Task<IEnumerable<ConditionDto>> GetConditions();
        /// <summary>
        /// Gets all conditions
        /// </summary>
        /// <returns>list of all conditions in the database</returns>
        Task<IEnumerable<ConditionDto>> GetAllConditions();

        /// <summary>
        /// Gets a condition by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>data of the called condition</returns>
        Task<ConditionDto> GetConditionById(int id);

        /// <summary>
        /// Creates a new condition
        /// </summary>
        /// <param name="conditionToCreate"></param>
        /// <returns>data of the newly created condition</returns>
        Task<ConditionGetterDto> CreateCondition(ConditionCreationDto conditionToCreate);

        /// <summary>
        /// Updates a condition
        /// </summary>
        /// <param name="conditionToUpdate"></param>
        /// <returns>true if condition is successfully created</returns>
        Task<bool> UpdateCondition(ConditionDto conditionToUpdate);

        /// <summary>
        /// deletes a condition
        /// </summary>
        /// <param name="id"></param>
        Task<int> DeleteCondition(int id);
    }
}
