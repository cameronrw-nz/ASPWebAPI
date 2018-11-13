using ASPWebAPI.Models;
using System.Collections.Generic;

namespace ASPWebAPI.Services
{
    public interface IHighScoreDataAccess
    {
        IEnumerable<HighScore> GetHighScores();

        HighScore GetHighScore(string playerUserName);

        void InsertHighScore(HighScore insertedHighScore);

        void UpdateHighScore(HighScore updatedHighScore);
    }
}
