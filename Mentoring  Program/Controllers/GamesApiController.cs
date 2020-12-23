using System.Net;
using MentoringProgram.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MentoringProgram.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{api-version:apiVersion}/games")]
    [Produces("application/json")]
    public class GamesApiController : ControllerBase
    {
        [SwaggerOperation("GetAllGames")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [HttpGet("allgames")]
        public IActionResult GetAllGames()
        {
            return Ok();
        }

        [HttpGet("game/{id}", Name = nameof(GetGame))]
        [SwaggerOperation("GetGame")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public IActionResult GetGame([FromRoute] int id)
        {
            return Ok();
        }

        [HttpPost("game")]
        [SwaggerOperation("PostGame")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        public IActionResult PostGame([FromBody] Game game)
        {
            return CreatedAtAction(
                "GetGame",
                new { id = 1 },
                new Game()
            );
        }

        [HttpPut("game/{id}")]
        [SwaggerOperation("PutGame")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public IActionResult PutGame([FromRoute] int id, [FromBody] Game game)
        {
            return NoContent();
        }

        [HttpDelete("game/{id}")]
        [SwaggerOperation("DeleteGame")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public ActionResult<Game> DeleteGame([FromRoute] int id)
        {
            return new Game();
        }
    }
}
