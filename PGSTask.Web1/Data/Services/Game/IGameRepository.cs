using PGSTask.Web1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PGSTask.Web1.Data
{
    public interface IGameRepository
    {
        void AddGame(Game game);

        void UpdateGame(Game game);

        void DeleteGame(int? id);

        Game GetGame(int id);

        List<Game> GetAllGames();
    }
}
