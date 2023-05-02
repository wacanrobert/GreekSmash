using GreekSmash.Dtos.Arena;
using GreekSmash.Dtos.Condition;
using GreekSmash.Dtos.Location;
using GreekSmash.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GreekSmash.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConditionsController : ControllerBase
    {
        private readonly IConditionService _conditionService;
        private readonly ILogger<ConditionsController> _logger;

        public ConditionsController(
            IConditionService conditionService,
            ILogger<ConditionsController> logger)
        {
            _conditionService = conditionService;
            _logger = logger;
        }
        /// <summary>
        /// Gets all conditions with locations
        /// </summary>
        /// <returns>Returns all the conditions</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/conditions
        /// 
        /// </remarks>
        /// <response code="200">Successfully returned all conditions</response>
        /// <response code="500">Internal server error</response>
        ///
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<ConditionDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAllConditions()
        {
            try
            {
                var conditions = await _conditionService.GetAllConditions();

                if (conditions.IsNullOrEmpty())
                {
                    return NoContent();
                }

                return Ok(conditions);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Gets all conditions
        /// </summary>
        /// <returns>Returns all the conditions</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/conditions
        /// 
        /// </remarks>
        /// <response code="200">Successfully returned all conditions</response>
        /// <response code="500">Internal server error</response>
        ///
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<ConditionDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("all")]
        public async Task<IActionResult> GetConditions()
        {
            try
            {
                var conditions = await _conditionService.GetConditions();

                if (conditions.IsNullOrEmpty())
                {
                    return NoContent();
                }

                return Ok(conditions);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Gets a condition by id
        /// </summary>
        /// <param name="id">condition id</param>
        /// <returns>Returns a condition by id</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/conditions/1
        /// 
        /// </remarks>
        /// <response code="200">Successfully returned a condition</response>
        /// <response code="400">condition id is invalid</response>
        /// <response code="500">Internal server error</response>
        [Produces("application/json")]
        [ProducesResponseType(typeof(ConditionDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}", Name = "GetConditionById")] 
        public async Task<IActionResult> GetConditionById(int id)
        {
            try
            {
                var condition = await _conditionService.GetConditionById(id);

                if(condition==null)
                    return NotFound($"Condition with id {id} does not exist.");

                return Ok(condition);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }
        /// <summary>
        /// Creates a condition
        /// </summary>
        /// <param name="conditionDto">condition details</param>
        /// <returns>Returns the newly created condition</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/conditions
        ///     {
        ///         "description" : "Drops healing potion"
        ///     }
        /// 
        /// </remarks>
        /// <response code="201">Successfully created a condition</response>
        /// <response code="400">condition details are invalid</response>
        /// <response code="500">Internal server error</response>
        /// 
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ConditionGetterDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCondition([FromBody] ConditionCreationDto conditionDto)
        {
            try
            {
                var newCondition = await _conditionService.CreateCondition(conditionDto);

                return CreatedAtRoute("GetConditionById", new { id = newCondition.Id }, newCondition);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }
        /// <summary>
        /// Updates a condition
        /// </summary>
        /// <param name="id">condition id</param>
        /// <param name="conditionDto">condition details</param>
        /// <returns>Returns the newly updated condition</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /api/conditions/6
        ///     {
        ///         "description" : "Drops healing potion doubling the current hp"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Successfully updated a condition</response>
        /// <response code="400">condition details are invalid</response>
        /// <response code="500">Internal server error</response>
        ///
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCondition(int id, [FromBody] ConditionCreationDto conditionDto)
        {
            try
            {
                var newCondition = new ConditionDto
                {
                    Id = id,
                    Description = conditionDto.Description
                };
                var update = await _conditionService.UpdateCondition(newCondition);

                if(!update)
                    return NotFound($"Location with id {id} does not exist.");

                return Ok($"Successfully updated condition description");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }
        /// <summary>
        /// Deletes a condition
        /// </summary>
        /// <param name="id">condition id</param>
        /// <returns>Returns the id of newly deleted condition</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/conditions/1
        /// 
        /// </remarks>
        /// <response code="200">Successfully deleted a condition</response>
        /// <response code="400">condition id is invalid</response>
        /// <response code="500">Internal server error</response>
        ///
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ConditionDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCondition(int id)
        {
            try
            {
                var conditions = await _conditionService.DeleteCondition(id);

                if(conditions==0)
                    return NotFound($"Villain with id {id} does not exist.");

                return Ok($"Condition with id {id} has been deleted.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
