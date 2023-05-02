using GreekSmash.Dtos.Arena;
using GreekSmash.Dtos.Location;
using GreekSmash.Dtos.Villain;
using GreekSmash.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GreekSmash.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly ILogger<LocationsController> _logger;

        public LocationsController(
            ILocationService locationService,
            ILogger<LocationsController> logger)
        {
            _locationService = locationService;
            _logger = logger;
        }
        /// <summary>
        /// Gets all locations
        /// </summary>
        /// <returns>Returns all the locations</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/locations
        /// 
        /// </remarks>
        /// <response code="200">Successfully returned all locations</response>
        /// <response code="500">Internal server error</response>
        ///
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<LocationDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("all")]
        public async Task<IActionResult> GetLocations()
        {
            try
            {
                var locations = await _locationService.GetLocations();

                if (locations.IsNullOrEmpty())
                {
                    return NoContent();
                }

                return Ok(locations);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }
        /// <summary>
        /// Gets all locations with conditions
        /// </summary>
        /// <returns>Returns all the locations</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/locations
        /// 
        /// </remarks>
        /// <response code="200">Successfully returned all locations</response>
        /// <response code="500">Internal server error</response>
        ///
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<LocationDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAllLocations()
        {
            try
            {
                var locations = await _locationService.GetAllLocations();

                if (locations.IsNullOrEmpty())
                {
                    return NoContent();
                }

                return Ok(locations);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }
        /// <summary>
        /// Gets a location by id
        /// </summary>
        /// <param name="id">Location id</param>
        /// <returns>Returns a location by id</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/locations/1
        /// 
        /// </remarks>
        /// <response code="200">Successfully returned a location</response>
        /// <response code="400">location id is invalid</response>
        /// <response code="500">Internal server error</response>
        /// 
        [Produces("application/json")]
        [ProducesResponseType(typeof(LocationDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}", Name = "GetLocationById")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            try
            {
                var location = await _locationService.GetLocationById(id);
                return Ok(location);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }
        /// <summary>
        /// Creates a location
        /// </summary>
        /// <param name="locationDto">Location details</param>
        /// <returns>Returns the newly created location</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/locations
        ///     {
        ///         "name" : "Labyrinth"
        ///     }
        /// 
        /// </remarks>
        /// <response code="201">Successfully created a location</response>
        /// <response code="400">Location details are invalid</response>
        /// <response code="500">Internal server error</response>
        ///
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(LocationGetterDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateLocation([FromBody] LocationCreationDto locationDto)
        {
            try
            {
                var newLocation = await _locationService.CreateLocation(locationDto);

                return CreatedAtRoute("GetLocationById", new { id = newLocation.Id }, newLocation);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }
        /// <summary>
        /// Updates a location
        /// </summary>
        /// <param name="id">Location id</param>
        /// <param name="locationDto">location details</param>
        /// <returns>Returns the newly updated location</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /api/locations/6
        ///     {
        ///         "name" : "Labyrinth Maze"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Successfully updated a location</response>
        /// <response code="400">Location details are invalid</response>
        /// <response code="500">Internal server error</response>
        ///
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateLocation(int id, [FromBody] LocationCreationDto locationDto)
        {
            try
            {
                var newLoc = new LocationDto
                {
                    Id = id,
                    Name = locationDto.Name
                };
                var update = await _locationService.UpdateLocation(newLoc);

                if(!update)
                    return NotFound($"Location with id {id} does not exist.");

                return Ok($"Successfully updated location name");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Deletes a location
        /// </summary>
        /// <param name="id">Location id</param>
        /// <returns>Returns the id of newly deleted location</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/locations/1
        /// 
        /// </remarks>
        /// <response code="200">Successfully deleted a location</response>
        /// <response code="400">Location id is invalid</response>
        /// <response code="500">Internal server error</response>
        /// 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            try
            {
                var location = await _locationService.DeleteLocation(id);

                if(location==0)
                    return NotFound($"Location with id {id} does not exist.");

                return Ok($"Location with id {id} has been deleted.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
