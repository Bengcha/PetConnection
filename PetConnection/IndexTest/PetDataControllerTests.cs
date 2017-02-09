using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using PetConnection;
using PetConnection.Controllers;

namespace IndexTest
{
    [TestClass]
    public class PetDataControllerTests
    {
        [TestMethod]
        public void Index()
        {
            //Arrange
            PetDataController controller = new PetDataController();

            //Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
