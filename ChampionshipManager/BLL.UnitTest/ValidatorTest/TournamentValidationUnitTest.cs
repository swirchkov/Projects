using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Models;
using BLL.DTO;
using BLL.Validators;
using System.Threading;

namespace BLL.UnitTest.ValidatorTest
{
    [TestClass]
    public class TournamentValidationUnitTest : BaseUnitTest<Tournament, TournamentDTO>
    {
        private const string category = "BLL.Validators.TournamnentValidator";

        [TestMethod]
        [TestCategory(category)]
        [ExpectedException(typeof(ValidationException))]
        public void test_participate_number()
        {
            // arrange
            TournamentDTO t = new TournamentDTO()
            {
                Name = "tour",
                Logo = "logo",
                SportKind = "football"
            };

            // act
            service.CreateItem(t);

            // assert by expecting validation exception
        }

        [TestCategory(category)]
        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void test_null_values()
        {
            // arrange
            TournamentDTO tour = new TournamentDTO()
            {
                Name = ""
            };

            // act
            service.CreateItem(tour);

            // assert checking by expexting validation exception
        }

        [TestCategory(category)]
        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void test_empty_strings()
        {
            // arrange
            TournamentDTO tour = new TournamentDTO()
            {
                Name = "   ",
                Logo = "   ",
                SportKind = ""
            };

            // act 
            service.CreateItem(tour);

            // assert by expecting exception
        }

        [TestCategory(category)]
        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void test_delete_not_existing_entity()
        {
            // arrange
            const int id = -1;

            // act
            service.DeleteItem(id);

            // assert by expecting validation exception
        }
    }
}
