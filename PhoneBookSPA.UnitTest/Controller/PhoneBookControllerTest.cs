using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using PhoneBookSPA.Controllers;
using PhoneBookSPA.Interface;
using PhoneBookSPA.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PhoneBookSPA.UnitTest.Controller
{
    [TestFixture]  
    public class PhoneBookControllerTest
    {
        /// <summary>
        /// Test method for Ok(200) response
        /// </summary>
        [Test]
        public void GetPhoneBook_ValidDetails_Return200()
        {
            //Arrange
            var mockPhoneBookService = new Mock<IPhoneBookServices>();
            PhoneBook entity = new PhoneBook();
            mockPhoneBookService.Setup(x => x.GetPhoneBookDetails())
                .Returns(Task.FromResult(entity));
            var controller = new PhoneBookController(mockPhoneBookService.Object);

            //Act
            var response = controller.Get();
            var okResult = response as ObjectResult;

            //Assert
            mockPhoneBookService.Verify(v => v.GetPhoneBookDetails(), Times.Once());
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
        }

        /// <summary>
        /// Test method for NotFound(404) response
        /// </summary>
        [Test]
        public void GetPhoneBook_NotFound_Return404()
        {
            //Arrange
            var mockPhoneBookService = new Mock<IPhoneBookServices>();
            PhoneBook entity = null;
            mockPhoneBookService.Setup(x => x.GetPhoneBookDetails())
                .Returns(Task.FromResult(entity));
            var controller = new PhoneBookController(mockPhoneBookService.Object);

            //Act
            var response = controller.Get();
     
            //Assert
            mockPhoneBookService.Verify(v => v.GetPhoneBookDetails(), Times.Once());
            Assert.IsInstanceOf<NotFoundResult>(response);
        }

        /// <summary>
        /// Test method to return all the phone book details
        /// </summary>
        [Test]
        public void GetPhoneBook_ValidDetails_ReturnData()
        {
            //Arrange
            var mockPhoneBookService = new Mock<IPhoneBookServices>();
            PhoneBook entity = new PhoneBook();
            entity.Contacts.Add(new Contacts { name = "Oleta Level", phone_number = "+442032960159", address = "10 London Wall, London EC2M 6SA, UK" });
            entity.Contacts.Add(new Contacts { name = "Maida Harju", phone_number = "+442032960899", address = "Woodside House, 94 Tockholes Rd, Darwen BB3 1LL, UK" });
            entity.Contacts.Add(new Contacts { name = "Lia Pigford", phone_number = "+442032960182", address = "23 Westmorland Cl, Darwen BB3 2TQ, UK" });
            mockPhoneBookService.Setup(x => x.GetPhoneBookDetails())
                .Returns(Task.FromResult(entity));
            var controller = new PhoneBookController(mockPhoneBookService.Object);

            //Act
            var response = controller.Get();
            var okResult = response as ObjectResult;

            //Assert
            mockPhoneBookService.Verify(v => v.GetPhoneBookDetails(), Times.Once());
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.IsNotNull(response);
            Assert.IsInstanceOf<PhoneBook>(okResult.Value);
            Assert.AreSame(entity, okResult.Value);
        }
    }
}
