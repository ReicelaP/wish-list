using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using WishList.Core.Models;
using WishList.Core.Services;
using WishList.Services;
using System.Collections.Generic;

namespace WishList.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private IUserService _userService;

        [TestInitialize]
        public void SetUp()
        {
            _userService = new UserService();
        }

        [TestMethod]
        public void GetNames_haveValue_returnStringOfNames()
        {
            //Arrange
            var userList = new UserList();
            var users = new List<User>();
            userList.Users = users;

            var user = new User();
            user.Type = "user";
            user.Id = 150709;
            user.Name = "johnsmith";
            user.Email = "jsmith@example.com";

            users.Add(user);

            //Act
            var result = _userService.GetNames(userList);

            //Assert
            result.Should().Be("johnsmith");
        }

        [TestMethod]
        public void GetNames_noValue_returnsEmptyString()
        {
            //Arrange
            var userList = new UserList();
            var users = new List<User>();
            userList.Users = users;

            //Act
            var result = _userService.GetNames(userList);

            //Assert
            result.Should().Be("");
        }
    }
}
