using GreekSmash.Dtos.Condition;
using GreekSmash.Models;

namespace GreekSmash.Repositories
{
    public interface IConditionRepository
    {
        /// <summary>
        /// Gets all conditions
        /// </summary>
        /// <returns>List of conditions</returns>
        Task<IEnumerable<ConditionDto>> GetConditions();
        /// <summary>
        /// Gets all conditions
        /// </summary>
        /// <returns>List of conditions</returns>
        Task<IEnumerable<ConditionDto>> GetAllConditions();

        /// <summary>
        /// Gets condition given the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ConditionDto with corresponding id</returns>
        Task<ConditionDto> GetConditionById(int id);

        /// <summary>
        /// Creates a new condition
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>Id of newly created condition</returns>
        Task<int> CreateCondition(Condition condition);

        /// <summary>
        /// Updates a condition
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>Bool whether condition was updated</returns>
        Task<bool> UpdateCondition(Condition condition);

        /// <summary>
        /// Deletes a condition
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Id of newly deleted condition</returns>
        Task<int> DeleteCondition(int id);
    }
}
