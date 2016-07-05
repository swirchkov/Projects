using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Interfaces;
using BLL.DTO;
using DAL;
using DAL.Models;
using BLL.UnitTest.FakeDataInitializer;
using Autofac;
using BLL.Validators;

namespace BLL.UnitTest.ValidatorTest
{
    [TestClass]
    public class UserValidationUnitTest : BaseUnitTest<User, UserDTO> 
    {
        private const string category = "BLL.Validators.UserValidation";

        [TestCategory(category)]
        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void test_null_validation()
        {
            // arrange
            UserDTO user = new UserDTO()
            {
                Id = 0,
                Name = "",
                Surname = "",
                Patronymic = ""
            };

            // act
            service.CreateItem(user);

            // Assert by expecting exception
        }

        [TestCategory(category)]
        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void test_empty_strings()
        {
            // arrange
            UserDTO user = new UserDTO()
            {
                Comment = "",
                Email = "sss@aa.ua",
                Name = "",
                Surname = "   ",
                Password = "  ",
                Patronymic = "",
                PhoneNumber = "",
                Photo = "    ",
                Role = "",
            };

            // act
            service.CreateItem(user);

            // assert by expecting validation exception because string is empty or whitespace
        }

        [TestCategory(category)]
        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void test_email_verification()
        {
            // arrange
            UserDTO user = new UserDTO()
            {
                Comment = "comment",
                Email = "sss@aaua",
                Name = "name1",
                Surname = "Name1",
                Password = "pass",
                Patronymic = "patron",
                PhoneNumber = "0991111111",
                Photo = "/images/photo.jpg",
                Role = "user"
            };

            // act
            service.CreateItem(user);

            // assert by expecting validation exception cause email shouldn't be validated
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
