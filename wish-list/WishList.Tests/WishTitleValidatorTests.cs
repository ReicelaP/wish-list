using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WishList.Core.Models;
using WishList.Core.Validations;

namespace WishList.Tests
{
    [TestClass]
    public class WishTitleValidatorTests
    {
        [TestMethod]
        public void IsValid_HaveValue_ReturnTrue()
        {
            //Arrange
            var wish = new Wish();
            wish.Title = "Ticket";

            //Act
            var result = WishTitleValidator.IsValid(wish);

            //Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void IsValid_EmptyValue_ReturnFalse()
        {
            //Arrange
            var wish = new Wish();
            wish.Title = "";

            //Act
            var result = WishTitleValidator.IsValid(wish);

            //Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void IsValid_NullValue_ReturnFalse()
        {
            //Arrange
            var wish = new Wish();
            wish.Title = null;

            //Act
            var result = WishTitleValidator.IsValid(wish);

            //Assert
            result.Should().BeFalse();
        }
    }
}
