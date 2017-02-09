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
    public class ManageControllerTests
    {
       
             [TestMethod]
        public void AddPhoneNumber()
        {
            // Arrange
            ManageController controller = new ManageController();

            // Act
            ViewResult result = controller.AddPhoneNumber() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void ChangePassword()
        {
            // Arrange
            ManageController controller = new ManageController();

            // Act
            ViewResult result = controller.ChangePassword() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void SetPassword()
        {
            // Arrange
            ManageController controller = new ManageController();

            // Act
            ViewResult result = controller.SetPassword() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
