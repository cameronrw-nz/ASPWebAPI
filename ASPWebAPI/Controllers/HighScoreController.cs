using ASPWebAPI.Models;
using ASPWebAPI.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ASPWebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class HighScoreController : ApiController
    {
        private readonly IHighScoreDataAccess _highScoreDataAccess;
        private readonly IPlayersDataAccess _playersDataAccess;

        public HighScoreController() 
            : this((IHighScoreDataAccess)WebApiConfig.UnityContainer.Resolve(typeof(IHighScoreDataAccess), null, null), 
                  (IPlayersDataAccess)WebApiConfig.UnityContainer.Resolve(typeof(IPlayersDataAccess), null, null)) 
        {
        }

        public HighScoreController(IHighScoreDataAccess highScoreDataAccess, IPlayersDataAccess playersDataAccess)
        {
            _highScoreDataAccess = highScoreDataAccess;
        }

        public IEnumerable<HighScore> GetAllHighScores()
        {
            return _highScoreDataAccess.GetHighScores();
        }

        public IHttpActionResult PostHighScore([FromBody]Player player)
        {
            var existingPlayer = _playersDataAccess.GetPlayer(player.UserName);

            if (existingPlayer == null)
            {
                _playersDataAccess.InsertPlayer(player);

                var highScore = new HighScore()
                                {
                                    PlayerId = player.PlayerId,
                                    Score = 1
                                };

                _highScoreDataAccess.InsertHighScore(highScore);
            }
            else
            {
                var highScore = _highScoreDataAccess.GetHighScore(existingPlayer.PlayerId);

                if (highScore == null)
                {
                    highScore = new HighScore()
                                {
                                    PlayerId = player.PlayerId,
                                    Score = 1
                                };

                    _highScoreDataAccess.InsertHighScore(highScore);
                }
                else
                {
                    highScore.Score++;
                    _highScoreDataAccess.UpdateHighScore(highScore);
                }
            }

            return Created(new Uri(Request.RequestUri + player.PlayerId.ToString()), player);
        }
    }
}