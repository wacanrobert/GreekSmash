using GreekSmash.Dtos.Arena;
using GreekSmash.Repositories;
using GreekSmash.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GreekSmash.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArenasController : ControllerBase
    {
        private readonly IArenaService _arenaServ;
        private readonly ILogger<ArenasController> _logger;
        public ArenasController(IArenaService arenaService, ILogger<ArenasController> logger)
        {
            _arenaServ = arenaService;
            _logger = logger;
        }

        /// <summary>
        /// Gets all arena matches
        /// </summary>
        /// <returns>all arena</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     GET /api/arenas/
        ///     
        /// </remarks>
        /// <response code="200">Successfully get all arena match</response>
        /// <response code="204">No arena match found</response>
        /// <response code="500">Internal server error</response>
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<ArenaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAllArena()
        {
            try
            {
                var allArena = await _arenaServ.GetAllArena();
                if (allArena.IsNullOrEmpty())
                {
                    return NoContent();
                }

                return Ok(allArena);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Gets all arena matches
        /// </summary>
        /// <param name="id">specified which arena match to get</param>
        /// <returns>arena</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     GET /api/arenas/1
        ///     
        /// </remarks>
        /// <response code="200">Successfully get all arena match</response>
        /// <response code="404">No arena match found</response>
        /// <response code="500">Internal server error</response>
        [Produces("application/json")]
        [ProducesResponseType(typeof(ArenaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}", Name = "GetArenaById")]
        public async Task<IActionResult> GetArena(int id)
        {
            try
            {
                var arena = await _arenaServ.GetArenaById(id);
                if (arena == null)
                    return NotFound($"Arena with id {id} does not exist.");

                return Ok(arena);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Creates an arena match
        /// </summary>
        /// <param name="newArena">New arena details</param>
        /// <returns>new record of arena</returns>
        /// <remarks>
        /// SAMPLE REQUEST:
        /// 
        ///     POST /api/arenas/
        ///     {
        ///       "heroId": 1,
        ///       "villainId": 1,
        ///       "locationId": 1
        ///     }
        ///     
        /// </remarks>
        /// <response code="201">Successfully created an arena match</response>
        /// <response code="404">Arena details are invalid</response>
        /// <response code="500">Internal server error</response>
        /// 
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ArenaDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateArena([FromBody] ArenaCreationDto newArena)
        {
            try
            {
                var createArena = await _arenaServ.CreateArena(newArena);
                if (createArena == null)
                    return NotFound("Please recheck inputs.");

                return CreatedAtRoute("GetArenaById", new { createArena.Id }, createArena);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Updates an arena
        /// </summary>
        /// <param name="id"> specifies the arena match to update</param>
        /// <param name="arenaToUpd">New result of an arena</param>
        /// <returns>updated arena</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     PUT /api/arenas/1
        ///     {
        ///       "result": "Invalid"
        ///     }
        ///     
        /// </remarks>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ArenaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateArena(int id, [FromBody] ArenaUpdateDto arenaToUpd)
        {
            try
            {
                var arenaUpdate = await _arenaServ.UpdateArena(id, arenaToUpd);
                if (arenaUpdate)
                {
                    var arena = await _arenaServ.GetArenaById(id);
                    return Ok(arena);
                }

                return NotFound($"Arena Id {id} does not exist.");
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE /api/arenas/5
        /// <summary>
        /// Deletes an arena match
        /// </summary>
        /// <param name="id">specifies which arena match to delete</param>
        /// <returns>a message</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     DELETE /api/arenas/1
        ///     
        /// </remarks> 
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteArena(int id)
        {
            try
            {
                var checkArena = await _arenaServ.DeleteArena(id);
                if (!checkArena)
                {
                    return NotFound("Arena Record Id " + id + " was not found.");
                }

                return Ok("Arena Record Id " + id + " has successfully deleted.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}