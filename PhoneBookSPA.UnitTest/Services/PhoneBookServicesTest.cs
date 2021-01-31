using System;
using System.Threading.Tasks;
using NUnit.Framework;
using PhoneBookSPA.Services;
using Moq;
using Microsoft.Extensions.Configuration;

namespace PhoneBookSPA.UnitTest.Services
{
    [TestFixture]
    public class PhoneBookServicesTest
    {
        [Test]
        public async Task GetPhoneBookDetails_Valid_ReturnData()
        {
            //Arrange
            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.SetupGet(z=>z[It.IsAny<string>()]).Returns("http://www.mocky.io/v2/581335f71000004204abaf83");
            PhoneBookServices _phoneBookServices = new PhoneBookServices(mockConfiguration.Object);

            //Act
            var response = await _phoneBookServices.GetPhoneBookDetails();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(10, response.Contacts.Count);
        }

        [Test]
        public async Task GetPhoneBookDetails_InvalidURL_ReturnNull()
        {
            //Arrange
            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.SetupGet(z => z[It.IsAny<string>()]).Returns("http://www.mocky.io/v2/581335f71000004204ab");
            PhoneBookServices _phoneBookServices = new PhoneBookServices(mockConfiguration.Object);

            //Act
            var response = await _phoneBookServices.GetPhoneBookDetails();

            //Assert
            Assert.IsNotNull(response);
        }
    }
}
