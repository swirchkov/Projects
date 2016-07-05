using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using DAL.Models;
using BLL.UnitTest.FakeDataInitializer;
using BLL.Interfaces;
using BLL.DTO;
using Autofac;
using System.Linq;

namespace BLL.UnitTest.ServiceTest
{
    [TestClass]
    public class GameUnitTest : BaseUnitTest<Game, GameDTO>
    {
        private const string category = "BLL.Services.GameService";

        [TestMethod]
        [TestCategory(category)]
        public void test_game_create()
        {
            // Arrange
            const string result = "winner1";
            GameDTO game = new GameDTO()
            {
                Id = 0,  // Sql server will automaticle generate id
                ResultView = result,
                Start = DateTime.Now,
                TournamentId = 1
            };

            // act
            service.CreateItem(game);

            // assert
            Assert.IsNotNull(repo.Find(g => g.ResultView == result).FirstOrDefault());
        }

        [TestMethod]
        [TestCategory(category)]
        public void test_game_update()
        {
            // Arrange
            const string oldResult = "editGame";
            const string newResult = "new game";
            GameDTO game = (GameDTO)repo.Find(g => g.ResultView == oldResult).FirstOrDefault();

            // Act 
            game.ResultView = newResult;
            service.UpdateItem(game);

            // Assert
            Assert.IsNotNull(repo.Find(g => g.ResultView == newResult).FirstOrDefault());
            Assert.IsNull(repo.Find(g => g.ResultView == oldResult).FirstOrDefault());
        }

        [TestMethod]
        [TestCategory(category)]
        public void test_game_delete()
        {
            // Arrange
            const string result = "deleteGame";
            GameDTO game = (GameDTO)repo.Find(g => g.ResultView == result).First();

            // act
            service.DeleteItem(game.Id);

            // Assert
            Assert.IsNull(repo.Find(g => g.ResultView == result).FirstOrDefault());
        }
    }
}
