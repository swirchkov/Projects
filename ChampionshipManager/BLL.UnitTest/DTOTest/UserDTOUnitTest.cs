using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.DI;
using BLL.UnitTest.FakeDataInitializer;
using BLL.DTO;
using DAL;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace BLL.UnitTest.DTOTest
{
    [TestClass]
    public class UserDTOUnitTest : BaseDTOTest
    {
        IRepository<User> repo = new UserRepository();
        private const string category = "BLL.DTO.UserDTO";

        [TestMethod]
        [TestCategory(category)]
        public void test_user_tournaments_number()
        {
            // arrange
            UserDTO user = (UserDTO)repo.Get(1);

            // act 
            IEnumerable<TournamentDTO> tours = user.Tournaments;

            // assert
            Assert.AreEqual(1, tours.Count());
        }

        [TestMethod]
        [TestCategory(category)]
        public void test_user_tournament_return_object()
        {
            // arrange
            UserDTO user = (UserDTO)repo.Get(2);

            // act
            IEnumerable<TournamentDTO> tournaments = user.Tournaments;

            //assert
            Assert.AreEqual(2, tournaments.First().Id);
        }
    }
}
