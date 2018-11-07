using ASPWebAPI.Models;
using System.Collections.Generic;

namespace ASPWebAPI.Services
{
    public interface IHighScoreDataAccess
    {
        IEnumerable<HighScore> GetHighScores();
    }
}
