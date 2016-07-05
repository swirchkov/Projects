using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using DAL.Models;
using BLL.UnitTest.FakeDataInitializer;
using BLL.DTO;

namespace BLL.UnitTest.DTOTest
{
    [TestClass]
    public class TournamentUnitTest
    {
        private IRepository<Tournament> repo = new TournamentRepository();
        private const string category = "BLL.DTO.TournamentDTO";

        [TestMethod]
        [TestCategory(category)]
        public void test_tournament_game_count()
        {
            // Arrange
            TournamentDTO tournament = (TournamentDTO)repo.Get(1);

            // Act 
            IEnumerable<GameDTO> games = tournament.Games;

            // Assert
            Assert.AreEqual(1, games.Count());
        }

        [TestCategory(category)]
        [TestMethod]
        public void test_tournament_game_object()
        {
            // Arrange 
            TournamentDTO tournament = (TournamentDTO)repo.Get(2);

            // Act
            IEnumerable<GameDTO> games = tournament.Games;

            // Assert
            Assert.AreEqual(2, games.FirstOrDefault().Id);
        }
    }
}
