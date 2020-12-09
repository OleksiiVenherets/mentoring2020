using Mentoring_Program.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Mentoring_Program.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{api-version:apiVersion}/games")]
    [Produces("application/json")]
    public class GamesController : ControllerBase
    {
        [SwaggerOperation("GetAllGames")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [HttpGet("getallgames")]
        public IActionResult GetAllGames()
        {
            return Ok();
        }

        [HttpGet("getgame/{id}", Name = nameof(GetGame))]
        [SwaggerOperation("GetGame")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public IActionResult GetGame([FromRoute]int id)
        {
            return Ok();
        }

        [HttpPost("postgame")]
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

        [HttpPut("putgame/{id}")]
        [SwaggerOperation("PutGame")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public IActionResult PutGame([FromRoute] int id, [FromBody] Game game)
        {
            return NoContent();
        }

        [HttpDelete("deletegame/{id}")]
        [SwaggerOperation("DeleteGame")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public ActionResult<Game> DeleteGame([FromRoute] int id)
        {
            return new Game();
        }
    }
}
