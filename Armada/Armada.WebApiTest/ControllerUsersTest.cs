using Armada.Controllers;
using Armada.Helper;
using Armada.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Armada.WebApiTest
{
    [TestClass]
    public class ControllerUsersTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Startup.SetUpAutoMapper();
        }

        [TestMethod]
        public void TestGetUsersResultOk()
        {
            //Arrange
            var usersController = new UsersController(null, new ArmadaRepositoryFake(), new IUrlHelperFake());

            //Act
            var result = usersController.GetUsers(new Pagination());

            //Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var resultEnumeration = (IEnumerable<UserWithoutMessagesDto>)((OkObjectResult)result).Value;
            Assert.AreEqual(4, resultEnumeration.ToList().Count);

        }
    }
}
