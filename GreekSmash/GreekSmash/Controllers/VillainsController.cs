using GreekSmash.Dtos.Villain;
using GreekSmash.Models;
using GreekSmash.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GreekSmash.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillainsController : ControllerBase
    {
        private readonly IVillainService _villainService;
        private readonly ILogger<VillainsController> _logger;

        /// <summary>
        /// Constructor for Villain Controller which uses ILogger and IVillainService
        /// </summary>
        /// <param name="villainService"></param>
        /// <param name="logger"></param>
        public VillainsController(
            IVillainService villainService,
            ILogger<VillainsController> logger)
        {
            _villainService = villainService;
            _logger = logger;
        }

        /// <summary>
        /// Gets a villain by id
        /// </summary>
        /// <param name="id">Villain id</param>
        /// <returns>Returns a villain by id</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/villains/1
        /// 
        /// </remarks>
        /// <response code="200">Successfully returned a villain</response>
        /// <response code="400">Villain id is invalid</response>
        /// <response code="500">Internal server error</response>
        /// 
        [HttpGet("{id}", Name = "GetVillainById")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
         
        public async Task<IActionResult> GetVillainById(int id)
        {
            try
            {
                var villain = await _villainService.GetVillainById(id);

                if(villain == null)
                    return NotFound($"Villain with id {id} does not exist.");

                return Ok(villain);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Gets all villains
        /// </summary>
        /// <returns>Returns all the villains</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/villains
        /// 
        /// </remarks>
        /// <response code="200">Successfully returned all villains</response>
        /// <response code="500">Internal server error</response>
        /// 
        [HttpGet(Name = "GetAllVillains")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetVillains()
        {
            try
            {
                var villains = await _villainService.GetAllVillains();

                if (villains.IsNullOrEmpty())
                {
                    return StatusCode(204, "Table has no values");
                }

                return Ok(villains);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Creates a villain
        /// </summary>
        /// <param name="villainDto">Villain details</param>
        /// <returns>Returns the newly created villain</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/villains
        ///     {
        ///         "name" : "Kraken",
        ///         "perkId" : 6,
        ///         "weapon" : "Tentacles",
        ///         "description" : "Sea monster of tremendous size and strength"
        ///     }
        /// 
        /// </remarks>
        /// <response code="201">Successfully created a villain</response>
        /// <response code="400">Villain details are invalid</response>
        /// <response code="500">Internal server error</response>
        /// 
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(VillainDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateVillain([FromBody] VillainCreationDto villainDto)
        {
            try
            {
                var newVillain = await _villainService.CreateVillain(villainDto);
                
                return CreatedAtRoute("GetVillainById", new { id = newVillain.Id }, newVillain);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Updates a villain
        /// </summary>
        /// <param name="id">Villain id</param>
        /// <param name="villainCreationDto">Villain details</param>
        /// <returns>Returns the newly updated villain</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /api/villains/1
        ///     {
        ///         "name" : "Kraken",
        ///         "perkId" : 6,
        ///         "weapon" : "Tentacles",
        ///         "description" : "Sea monster of tremendous size and strength"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Successfully updated a villain</response>
        /// <response code="400">Villain details are invalid</response>
        /// <response code="500">Internal server error</response>
        /// 
        [HttpPut("{id}", Name = "PutVillain")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        
        public async Task<IActionResult> UpdateVillain(int id, [FromBody] VillainCreationDto villainCreationDto)
        {
            try
            {
                var newVillain = new VillainDto
                {
                    Id = id,
                    Name = villainCreationDto.Name,
                    PerkId = villainCreationDto.PerkId,
                    Weapon = villainCreationDto.Weapon,
                    Description = villainCreationDto.Description
                };
                var updateVillain = await _villainService.UpdateVillain(newVillain);

                if(!updateVillain)
                    return NotFound($"Villain with id {id} does not exist.");

                return Ok($"Successfully updated villain");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
            
        }

        /// <summary>
        /// Deletes a villain
        /// </summary>
        /// <param name="id">Villain id</param>
        /// <returns>Returns the id of newly deleted villain</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/villains/1
        /// 
        /// </remarks>
        /// <response code="200">Successfully deleted a villain</response>
        /// <response code="400">Villain id is invalid</response>
        /// <response code="500">Internal server error</response>
        /// 
        [HttpDelete("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteVillain(int id)
        {
            try
            {
                var villain = await _villainService.DeleteVillain(id);

                if(villain == 0)
                    return NotFound($"Villain with id {id} does not exist.");

                return Ok($"Villain with id {id} has been deleted.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
