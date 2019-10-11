using PGSTask.Web1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PGSTask.Web1.Data
{
    public class GameRepository : IGameRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public GameRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        /// <summary>
        /// Adding a new game entity to database
        /// </summary>
        /// <param name="game"></param>
        public void AddGame(Game game)
        {
            _repositoryContext.Add(game);
            _repositoryContext.SaveChanges();
        }
        /// <summary>
        /// Deleting game entity from database
        /// </summary>
        /// <param name="id"></param>
        public void DeleteGame(int id)
        {
            if (id != null)
            {
                var entity = _repositoryContext.Games.SingleOrDefault(x => id == x.Id);
                _repositoryContext.Remove(entity);
                _repositoryContext.SaveChanges();
            }
        }
        /// <summary>
        /// Getting list of all games
        /// </summary>
        /// <returns>List of all games</returns>
        public List<Game> GetAllGames()
        {
            return _repositoryContext.Games.ToList();
        }
        /// <summary>
        /// Getting game by id
        /// </summary>
        /// <param name="id">Game's id to get </param>
        /// <returns></returns>
        public Game GetGame(int? id)
        {
            var entity = _repositoryContext.Games.SingleOrDefault(x => id == x.Id);
            return entity;
        }
        /// <summary>
        /// Updating entity
        /// </summary>
        /// <param name="game">Entity to update</param>
        public void UpdateGame(Game game)
        {
            _repositoryContext.Update(game);
            _repositoryContext.SaveChanges();
        }
    }
}
