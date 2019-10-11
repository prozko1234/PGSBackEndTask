using Microsoft.AspNetCore.Mvc;
using Moq;
using PGSTask.Web1.Controllers;
using PGSTask.Web1.Data;
using PGSTask.Web1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTestProject
{
    public class GameControllerTest
    {
        /// <summary>
        /// Test doesnt work, problem with types
        /// </summary>
        [Fact]
        public void IndexReturnsAViewWithAListOfGames()
        {
            var games = new GamesViewModel();
            var mockRepo = new Mock<IGameRepository>();
            mockRepo.Setup(repo => repo.GetAllGames()).Returns(GetTestGames());
            var controller = new GamesController(mockRepo.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Game>> (
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        private List<Game> GetTestGames()
        {
            var games = new GamesViewModel ()
            {
                Games = {
                    new Game()
                {
                    Id = 7,
                    Title = "aaa",
                    ReleaseDate = Convert.ToDateTime("2009-05-06 00:00:00.0000000"),
                    Genre = "aaa",
                    Platform = "aaa",
                    Developer = "aaa",
                    Price = 11
                },
                new Game()
                {
                    Id = 7,
                    Title = "iii",
                    ReleaseDate = Convert.ToDateTime("2016-08-09 00:00:00.0000000"),
                    Genre = "iii",
                    Platform = "iii",
                    Developer = "iii",
                    Price = 222
                }
                }
            };
            return games.Games;
        }
    }
}
