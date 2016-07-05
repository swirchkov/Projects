using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Effort;
using System.IO;
using Effort.DataLoaders;
using DAL.Models;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;

namespace DAL.UnitTest.EntityTests
{
    [TestClass]
    public class UsersUnitTest : AbstractUnitTest
    {
        private const string testCategory = "DAL.Users";

        [TestMethod]
        [TestCategory(testCategory)]
        public void test_user_create()
        {
            // arrange
            User user = new User()
            {
                Name = "John",
                Surname = "Doe",
                Patronymic = "Bill",
                Password = "nerra_tos",
                Email = "nerra@non.com",
                Photo = "/photos/ava.jpg"
            };

            // act 
            userRepo.Create(user);

            // assert
            Assert.IsNotNull(userRepo.Find(u => u.Name == "John" && u.Email == "nerra@non.com").FirstOrDefault());
        }

        [TestMethod]
        [TestCategory(testCategory)]
        public void test_user_update()
        {
            // arrange
            
            // constants 
            const string userName = "UserEdit";
            const string userSurname = "Edited";

            User user = userRepo.Find(u => u.Name == userName).FirstOrDefault();
            user.Surname = userSurname;

            // act 
            userRepo.Update(user);

            // assert 
            Assert.AreEqual(userSurname, userRepo.Find(u => u.Name == userName).FirstOrDefault().Surname);
        }

        [TestMethod]
        [TestCategory(testCategory)]
        public void test_user_delete()
        {
            // arrange 

            // constants
            const string userName = "UserDelete";
            User user = userRepo.Find(u => u.Name == userName).FirstOrDefault();

            // act
            userRepo.Delete(user.Id);

            // assert
            Assert.IsNull(userRepo.Find(u => u.Name == userName).FirstOrDefault());
        }

        [TestMethod]
        [TestCategory(testCategory)]
        public void test_user_search_by_name()
        {
            // arrange
            // constants
            const string userName = "First";

            // act 
            IEnumerable<User> users = userRepo.Find(u => u.Name == userName);

            // assert
            Assert.AreEqual(1, users.Count());
            Assert.AreEqual("First", users.First().Name); 
        }

        [TestMethod]
        [TestCategory(testCategory)]
        public void test_user_search_by_email()
        {
            // arrange
            // constants
            const string email = "111@mail.com";

            // act
            IEnumerable<User> users = userRepo.Find(u => u.Email == email);

            // assert
            Assert.AreEqual(2, users.Count());
        }

    }
}
