using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        /// <summary>
        /// Opens view with a list of games
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var games = _gameRepository.GetAllGames();

            var gamesList = new GamesViewModel
            {
                Games = games
            };

            return View("Index", gamesList);
        }
        /// <summary>
        /// Opens view for delete confimation
        /// </summary>
        /// <param name="id"> game's id</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Delete(int ?id)
        {
            if(id == null)
            {
                return View("Error");
            };

            var entity = _gameRepository.GetGame(id);
           
            return View("Delete", entity);
        }
        /// <summary>
        /// Delets game from database
        /// </summary>
        /// <param name="id"> game's id</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
                _gameRepository.DeleteGame(id);
                return RedirectToAction(nameof(Index));
        }
 /// <summary>
 /// Opens view for game's entity creation
 /// </summary>
 /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        /// <summary>
        /// Creates new game entity
        /// </summary>
        /// <param name="game"> Game object</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,ReleaseDate,Genre,Platform,Developer,Price")] Game game)
        {
            if (ModelState.IsValid)
            {
                _gameRepository.AddGame(game);
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }
        /// <summary>
        /// Opens view for editing game's entity
        /// </summary>
        /// <param name="id"> game's id</param>
        /// <returns></returns>
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = _gameRepository.GetGame(id);

            if (game == null)
            {
                return NotFound();
            }
            return PartialView("Edit", game);
        }

       /// <summary>
       /// Edits game entity
       /// </summary>
       /// <param name="id"> game's id</param>
       /// <param name="game"> game object</param>
       /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Platform,Developer,Price")] Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _gameRepository.UpdateGame(game);
                }
                catch (DbUpdateConcurrencyException)
                {
                        return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

    }
}