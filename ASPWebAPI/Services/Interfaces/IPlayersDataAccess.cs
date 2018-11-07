using ASPWebAPI.Models;
using System.Collections.Generic;

namespace ASPWebAPI.Services
{
    public interface IPlayersDataAccess
    {
        IEnumerable<Player> GetPlayers();

        void InsertPlayer(Player insertedPlayer);

        void UpdatePlayer(Player updatedPlayer);

        void DeletePlayer(int playerId);
    }
}