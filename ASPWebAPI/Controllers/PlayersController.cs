using ASPWebAPI.Models;
using ASPWebAPI.Services;
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
    }
}
