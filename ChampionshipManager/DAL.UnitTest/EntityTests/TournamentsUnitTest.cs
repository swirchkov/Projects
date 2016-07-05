using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Models;
using System.Linq;
using System.Collections.Generic;

namespace DAL.UnitTest.EntityTests
{
    [TestClass]
    public class TournamentsUnitTest : AbstractUnitTest
    {
        private const string testCategory = "DAL.Tournaments";

        [TestMethod]
        [TestCategory(testCategory)]
        public void test_tournament_create()
        {
            //arrange 
            const string name = "cool tournament";
            Tournament tour = new Tournament()
            {
                Logo = "",
                Name = name,
                IsFinished = false,
                IsStarted = true
            };

            // act
            tournamentRepo.Create(tour);

            // assert
            Assert.IsTrue(tournamentRepo.Find(t => t.Name == name).Count() > 0);
        }

        [TestMethod]
        [TestCategory(testCategory)]
        public void test_tournament_edit()
        {
            // arrange
            const string name = "APLEdit";
            const string editlogo = "new logo of this";
            Tournament tournament = tournamentRepo.Find(t => t.Name == name).First();

            // act 
            tournament.Logo = editlogo;
            tournamentRepo.Update(tournament);

            // assert
            Assert.AreEqual(editlogo, tournamentRepo.Find(t => t.Name == name).FirstOrDefault().Logo);
        }

        [TestMethod]
        [TestCategory(testCategory)]
        public void test_tournament_delete()
        {
            // arrange
            const string name = "APLDelete";
            Tournament tour = tournamentRepo.Find(t => t.Name == name).FirstOrDefault();

            // act
            tournamentRepo.Delete(tour.Id);

            // assert
            Assert.IsNull(tournamentRepo.Find(t => t.Name == name).FirstOrDefault());
        }

        [TestMethod]
        [TestCategory(testCategory)]
        public void test_tournament_search_by_name()
        {
            // arrange
            const string name = "APL";
            const int foundObj = 1;

            // act
            IEnumerable<Tournament> tournaments = tournamentRepo.Find(t => t.Name == name);

            // assert
            Assert.AreEqual(foundObj, tournaments.Count());
        }

        [TestMethod]
        [TestCategory(testCategory)]
        public void test_tournament_search_by_finish_condition()
        {
            //arrange
            const int found = 2;

            // act
            IEnumerable<Tournament> tournaments = tournamentRepo.Find(t => t.IsFinished);

            // assert 
            Assert.AreEqual(found, tournaments.Count());
        }
    }
}
