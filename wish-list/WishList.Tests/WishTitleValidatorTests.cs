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
            //Act
            var wish = new Wish();
            wish.Title = "Ticket";

            //Assert
            var result = WishTitleValidator.IsValid(wish);

            //Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void IsValid_NullOrEmpty_ReturnFalse()
        {
            //Act
            var wish = new Wish();
            wish.Title = "";

            //Assert
            var result = WishTitleValidator.IsValid(wish);

            //Assert
            result.Should().BeFalse();
        }
    }
}
