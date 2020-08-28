using System.Collections.Generic;
using System.Linq;
using DefinitiveEdition.Api.Data;
using DefinitiveEdition.Api.Data.Models;
using DefinitiveEdition.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DefinitiveEdition.Api.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public GamesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("search/{query}")]
        public ActionResult<List<Game>> SearchGames(string query)
        {
            var gameList = _appDbContext.Game.Where(x => x.Name != null && x.Name.Contains(query)).ToList();

            if (gameList == null)
            {
                return NotFound();
            }

            return Ok(gameList);
        }

        [HttpPost]
        public ActionResult AddGame(GameResource resource)
        {
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteGame(GameResource resource)
        {
            return Ok();
        }
    }
}
