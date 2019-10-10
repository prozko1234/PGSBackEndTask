using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PGSTask.Web1.Data;
using PGSTask.Web1.Models;

namespace PGSTask.Web1.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameRepository _gameRepository;

        public GamesController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public IActionResult Index()
        {
            var games = _gameRepository.GetAllGames();

            var gamesList = new GamesViewModel
            {
                Games = games
            };

            return View("Index", gamesList);
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                _gameRepository.DeleteGame(id);
                return View("Index");
            }

            return View("/Other/Error");
        }
    }
}