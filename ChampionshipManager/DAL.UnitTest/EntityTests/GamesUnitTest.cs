using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Models;
using System.Linq;
using System.Collections.Generic;

namespace DAL.UnitTest.EntityTests
{
    [TestClass]
    public class GamesUnitTest : AbstractUnitTest
    {
        private const string testCategory = "DAL.Games";

        [TestMethod]
        [TestCategory(testCategory)]
        public void test_game_create()
        {
            // arrange
            // constant
            const string result = "4 : 2";
            Game game = new Game()
            {
                ResultView = result,
                Start = DateTime.Now,
                WinnerId = 1,
                TournamentId = 1
            };

            // act
            gameRepo.Create(game);

            // assert
            Assert.IsTrue(gameRepo.Find(g => g.ResultView == result).Count() > 0);
        }

        [TestMethod]
        [TestCategory(testCategory)]
        public void test_game_delete()
        {
            //arrange 
            // constants
            const string result = "WinnerDelete";
            Game item = gameRepo.Find(g => g.ResultView == result).First();

            // act
            gameRepo.Delete(item.Id);

            // assert
            Assert.AreEqual(null, gameRepo.Find(g => g.ResultView == result).FirstOrDefault());
        }

        [TestMethod]
        [TestCategory(testCategory)]
        public void test_game_update()
        {
            // arrange
            // constants
            const string result = "WinnerEdit";
            DateTime editedDate = DateTime.Now;

            Game item = gameRepo.Find(g => g.ResultView == result).FirstOrDefault();

            // act
            item.Start = editedDate;
            gameRepo.Update(item);

            // assert
            Assert.AreEqual(editedDate, gameRepo.Find(g => g.ResultView == result).FirstOrDefault().Start);
        }

        [TestMethod]
        [TestCategory(testCategory)]
        public void test_game_search_by_result()
        {
            // arrange
            const int findCount = 1;
            const string winResult = "winner";

            // act 
            IEnumerable<Game> games = gameRepo.Find(g => g.ResultView == winResult);

            // assert
            Assert.AreEqual(findCount, games.Count());
        }

        [TestMethod]
        [TestCategory(testCategory)]
        public void test_game_search_by_start_date()
        {
            // arrange
            const int objCount = 2;
            DateTime startDate = new DateTime(2016, 12, 12);

            // act
            IEnumerable<Game> games = gameRepo.Find(g => g.Start == startDate);

            // assert
            Assert.AreEqual(objCount, games.Count());
        }
    }
}
