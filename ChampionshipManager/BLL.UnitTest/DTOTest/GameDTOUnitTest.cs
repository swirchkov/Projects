using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using DAL.Models;
using BLL.UnitTest.FakeDataInitializer;
using BLL.DTO;
using System.Collections.Generic;

namespace BLL.UnitTest.DTOTest
{
    [TestClass]
    public class GameDTOUnitTest : BaseDTOTest
    {
        private IRepository<Game> repo = new GameRepository();
        private const string category = "BLL.DTO.GameDTO";

        [TestMethod]
        [TestCategory(category)]
        public void test_game_tournament()
        {
            // Arrange
            GameDTO game = (GameDTO)repo.Get(1);

            // act
            TournamentDTO tour = game.Tournament;

            // assert
            Assert.AreEqual(1, tour.Id);
        }

        [TestMethod]
        [TestCategory(category)]
        public void test_game_participates()
        {
            // arrange
            GameDTO game = (GameDTO)repo.Get(2);

            // act
            IEnumerable<UserDTO> users = game.Participates;

            // assert
            Assert.AreEqual(1, users.Count());
            Assert.AreEqual(1, users.FirstOrDefault().Id);
        }
    }
}
