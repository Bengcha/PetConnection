using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using PetConnection;
using PetConnection.Controllers;


namespace UnitTest
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public void Index()
        {
            //Arrange
            CustomersController controller = new CustomersController();

            //Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
    
