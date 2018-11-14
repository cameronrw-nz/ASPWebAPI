using ASPWebAPI.Models;
using ASPWebAPI.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ASPWebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class PlayersController : ApiController
    {
        private readonly IPlayersDataAccess _dataAccess;

        public PlayersController() : this((IPlayersDataAccess)WebApiConfig.UnityContainer.Resolve(typeof(IPlayersDataAccess), "", null))
        {
        }

        public PlayersController(IPlayersDataAccess playersDataAccess)
        {
            _dataAccess = playersDataAccess;
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return _dataAccess.GetPlayers();
        }

        // PUT: api/players/Cameron
        public IHttpActionResult PutPlayer([FromUri] string userName)
        {
            try
            {
                var existingPlayer = _dataAccess.GetPlayer(userName);
                if (existingPlayer == null)
                {
                    _dataAccess.InsertPlayer(new Player { UserName = userName });
                }
                else
                {
                        existingPlayer.UserName = userName;
                        _dataAccess.UpdatePlayer(existingPlayer);
                }
                
                return Created(new Uri(Request.RequestUri + userName), userName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
