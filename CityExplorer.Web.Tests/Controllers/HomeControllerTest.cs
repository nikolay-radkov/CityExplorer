namespace CityExplorer.Web.Tests.Controllers
{
    using CityExplorer.Data;
    using CityExplorer.Web.Controllers;
    using CityExplorer.Web.ViewModels;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Web.Mvc;

    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(new CityExplorerData(new CityExplorerDbContext()));

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Countries()
        {
            // Arrange
            HomeController controller = new HomeController(new CityExplorerData(new CityExplorerDbContext()));

            // Act
            ViewResult result = controller.Countries(1) as ViewResult;

            var countriesNumberFromEurope = result.Model as IEnumerable<CountryViewModel>;

                // Assert
            Assert.AreEqual(countriesNumberFromEurope, 2);
        }
    }
}
