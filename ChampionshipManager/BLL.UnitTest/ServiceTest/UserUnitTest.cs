using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Interfaces;
using BLL.DTO;
using Autofac;
using DAL;
using DAL.Models;
using BLL.UnitTest.FakeDataInitializer;
using System.Linq;

namespace BLL.UnitTest.ServiceTest
{
    [TestClass]
    public class UserUnitTest : BaseUnitTest<User, UserDTO>
    {
        private const string category = "BLL.Services.UserService";

        [TestMethod]
        [TestCategory(category)]
        public void test_user_create()
        {
            // Arrange
            UserDTO user = new UserDTO()
            {
                Name = "user1",
                Surname = "sur1",
                Password = "pass1",
                Patronymic = "patr1",
                Email = "mail@nnn.com",
                Comment = "some comment",
                Photo = "photo.jpg",
                Role = "user"
            };

            // act
            service.CreateItem(user);

            // Assert
            Assert.IsNotNull(repo.Find(u => u.Name == user.Name && u.Email == user.Email).FirstOrDefault());
        }

        [TestMethod]
        [TestCategory(category)]
        public void test_user_update()
        {
            // Arrange
            const string oldName = "editUser";
            const string newName = "new user";
            UserDTO user = (UserDTO)repo.Get(3);

            //Act 
            user.Name = newName;
            service.UpdateItem(user);

            // Assert 
            Assert.IsNull(repo.Find(u => u.Name == oldName).FirstOrDefault());
            Assert.IsNotNull(repo.Find(u => u.Name == newName).FirstOrDefault());
        }

        [TestCategory(category)]
        [TestMethod]
        public void test_user_delete()
        {
            // Arrange
            const string name = "deleteUser";
            UserDTO user = (UserDTO)repo.Find(u => u.Name == name).FirstOrDefault();

            // Act 
            service.DeleteItem(user.Id);

            // Assert
            Assert.IsNull(repo.Find(u => u.Name == name).FirstOrDefault());
        }
    }
}
