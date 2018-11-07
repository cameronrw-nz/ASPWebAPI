using ASPWebAPI.Models;
using ASPWebAPI.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ASPWebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class HighScoreController : ApiController
    {
        private readonly IHighScoreDataAccess _dataAccess;

        public HighScoreController() : this((IHighScoreDataAccess)WebApiConfig.UnityContainer.Resolve(typeof(IHighScoreDataAccess), null, null))
        {
        }

        public HighScoreController(IHighScoreDataAccess highScoreDataAccess)
        {
            _dataAccess = highScoreDataAccess;
        }

        public IEnumerable<HighScore> GetAllHighScores()
        {
            return _dataAccess.GetHighScores();
        }
    }
}