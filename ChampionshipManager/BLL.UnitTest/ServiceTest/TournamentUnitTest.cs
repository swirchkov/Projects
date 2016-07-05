using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DAL.Models;
using BLL.UnitTest.FakeDataInitializer;
using Autofac;
using System.Linq;

namespace BLL.UnitTest.ServiceTest
{
    [TestClass]
    public class TournamentUnitTest : BaseUnitTest<Tournament, TournamentDTO>
    {
        private const string category = "BLL.Services.TournamentService";

        [TestMethod]
        [TestCategory(category)]
        public void test_tournament_create()
        {
            // arrange
            const string name = "tournament";
            TournamentDTO tour = new TournamentDTO()
            {
                Id = 0,
                Name = name,
                Logo = "logo1",
                IsFinished = false,
                IsStarted = false,
                SportKind = "football",
                ParticipateNumber = 3
            };

            // act 
            service.CreateItem(tour);

            // assert
            Assert.IsNotNull(repo.Find(t => t.Name == name).FirstOrDefault());
        }

        [TestCategory(category)]
        [TestMethod]
        public void test_tournament_update()
        {
            // arrange
            const string oldName = "editTournament";
            const string newName = "tournament";
            TournamentDTO tour = (TournamentDTO)repo.Find(t => t.Name == oldName).FirstOrDefault();

            // act
            tour.Name = newName;
            service.UpdateItem(tour);

            // assert
            Assert.IsNotNull(repo.Find(t => t.Name == newName).FirstOrDefault());
            Assert.IsNull(repo.Find(t => t.Name == oldName).FirstOrDefault());
        }

        [TestCategory(category)]
        [TestMethod]
        public void test_tournament_delete()
        {
            // arrange
            const string name = "deleteTournament";
            TournamentDTO tour = (TournamentDTO)repo.Find(t => t.Name == name).FirstOrDefault();

            // act
            service.DeleteItem(tour.Id);

            // assert 
            Assert.IsNull(repo.Find(t => t.Name == name).FirstOrDefault());
        }
    }
}
