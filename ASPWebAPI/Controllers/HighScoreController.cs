using ASPWebAPI.Models;
using ASPWebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _playersDataAccess = playersDataAccess;
        }

        public IEnumerable<HighScore> GetAllHighScores()
        {
            var players = _playersDataAccess.GetPlayers();
            var highScores = _highScoreDataAccess.GetHighScores();

            var returnedHighScores = new List<HighScore>();
            foreach (HighScore highScore in highScores)
            {
                highScore.Player = players.SingleOrDefault(player => string.Equals(player.UserName, highScore.PlayerUserName));
                returnedHighScores.Add(highScore);
            }

            return returnedHighScores;
        }

        public IHttpActionResult PutHighScore(string userName)
        {
            var existingPlayer = _playersDataAccess.GetPlayer(userName);

            HighScore highScore;

            if (existingPlayer == null)
            {
                _playersDataAccess.InsertPlayer(new Player { UserName = userName });

                highScore = new HighScore()
                                {
                                    PlayerUserName = userName,
                                    Score = 1
                                };

                _highScoreDataAccess.InsertHighScore(highScore);
            }
            else
            {
                highScore = _highScoreDataAccess.GetHighScore(existingPlayer.UserName);

                if (highScore == null)
                {
                    highScore = new HighScore()
                                {
                                    PlayerUserName = userName,
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

            return Created(new Uri(Request.RequestUri + userName), highScore);
        }
    }
}