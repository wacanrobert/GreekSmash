using GreekSmash.Services;
using GreekSmash.Dtos.Hero;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using GreekSmash.Models;

namespace GreekSmash.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroService _heroService;
        private readonly ILogger<HeroesController> _logger;

        /// <summary>
        /// Constructor for Hero Controller which uses ILogger and IHeroService
        /// </summary>
        /// <param name="heroService"></param>
        /// <param name="logger"></param>

        public HeroesController(IHeroService heroService,
            ILogger<HeroesController> logger)
        {
            _heroService = heroService;
            _logger = logger;
        }

        /// <summary>
        /// Gets a hero by id
        /// </summary>
        /// <param name="id">Hero id</param>
        /// <returns>Returns a hero by id</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/heroes/1
        /// 
        /// </remarks>
        /// <response code="200">Successfully returned a hero</response>
        /// <response code="400">Hero id is invalid</response>
        /// <response code="500">Internal server error</response>
        /// 

        [HttpGet("{id}", Name = "GetHeroById")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHeroById(int id)
        {
            try
            {
                var hero = await _heroService.GetHeroById(id);
                if (hero == null)
                    return NotFound($"Hero with id {id} does not exist.");

                return Ok(hero);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Gets all heroes
        /// </summary>
        /// <returns>Returns all the heroes</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/heroes
        /// 
        /// </remarks>
        /// <response code="200">Successfully returned all heroes</response>
        /// <response code="500">Internal server error</response>
        ///

        [HttpGet(Name = "GetAllHeroes")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHeroes()
        {
            try
            {
                var heroes = await _heroService.GetAllHeroes();

                if (heroes.IsNullOrEmpty())
                {
                    return StatusCode(204, "Table has no values");
                }

                return Ok(heroes);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Creates a hero
        /// </summary>
        /// <param name="heroDto">Hero details</param>
        /// <returns>Returns the newly created hero</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/heroes
        ///     {
        ///         "name" : "Perseus",
        ///         "perkId" : 6,
        ///         "weapon" : "The Slayer of the Gorgon Medusa",
        ///         "description" : "Son of Zeus"
        ///     }
        /// 
        /// </remarks>
        /// <response code="201">Successfully created a hero</response>
        /// <response code="400">Hero details are invalid</response>
        /// <response code="500">Internal server error</response>
        ///

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(HeroDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateHero([FromBody] HeroCreationDto heroDto)
        {
            try
            {
                var newHero = await _heroService.CreateHero(heroDto);

                return CreatedAtRoute("GetHeroById", new { id = newHero.Id }, newHero);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Updates a hero
        /// </summary>
        /// <param name="id">Hero id</param>
        /// <param name="heroCreationDto">Hero details</param>
        /// <returns>Returns the newly updated hero</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /api/Heroes/1
        ///     {
        ///         "name" : "Perseus",
        ///         "perkId" : 6,
        ///         "weapon" : "The Slayer of the Gorgon Medusa",
        ///         "description" : "Son of Zeus"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Successfully updated a hero</response>
        /// <response code="400">Hero details are invalid</response>
        /// <response code="500">Internal server error</response>
        ///

        [HttpPut("{id}", Name = "PutHero")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateHero(int id, [FromBody] HeroCreationDto heroCreationDto)
        {
            try
            {
                var newHero = new HeroDto
                {
                    Id = id,
                    Name = heroCreationDto.Name,
                    PerkId = heroCreationDto.PerkId,
                    Weapon = heroCreationDto.Weapon,
                    Description = heroCreationDto.Description
                };
                var updateHero = await _heroService.UpdateHero(newHero);

                return Ok($"Successfully updated Hero");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }

        }

        /// <summary>
        /// Deletes a hero
        /// </summary>
        /// <param name="id">Hero id</param>
        /// <returns>Returns the id of newly deleted hero</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/heroes/1
        /// 
        /// </remarks>
        /// <response code="200">Successfully deleted a hero</response>
        /// <response code="400">Hero id is invalid</response>
        /// <response code="500">Internal server error</response>
        /// 

        [HttpDelete("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteHero(int id)
        {
            try
            {
                var hero = await _heroService.DeleteHero(id);
                return Ok($"Hero with id {id} has been deleted.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
