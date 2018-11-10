using ASPWebAPI.Models;
using System.Collections.Generic;

namespace ASPWebAPI.Services
{
    public interface IHighScoreDataAccess
    {
        IEnumerable<HighScore> GetHighScores();

        HighScore GetHighScore(int playerId);

        void InsertHighScore(HighScore insertedHighScore);

        void UpdateHighScore(HighScore updatedHighScore);
    }
}
