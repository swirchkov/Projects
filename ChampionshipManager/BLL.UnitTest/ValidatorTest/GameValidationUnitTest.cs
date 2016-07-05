using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.DTO;
using DAL.Models;
using BLL.Validators;

namespace BLL.UnitTest.ValidatorTest
{
    [TestClass]
    public class GameValidationUnitTest : BaseUnitTest<Game, GameDTO>
    {
        private const string category = "BLL.Validators.GameValidator";

        [TestCategory(category)]
        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void test_null_relation_with_tournament()
        {
            // Arrange
            GameDTO game = new GameDTO();

            // act
            service.CreateItem(game);

            // assert by expecting validation exception
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
