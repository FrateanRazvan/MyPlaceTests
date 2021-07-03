using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsMyPlace
{
    class Test_MyPlace
    {
        private IWebDriver _driver;
        [SetUp]
        public void SetupDriver()
        {
            _driver = new ChromeDriver("D:\\ASP.NET\\chromedriver_win32");
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }

        [Test]
        public void MyPlaceTextFind()
        {
            _driver.Url = "http://localhost:4200/login";
            bool foundText = false;

            foreach(var h in _driver.FindElements(By.TagName("h2")))
            {
                if (h.Text == "Welcome to My Place Health Center, please login if you are a member.")
                {
                    foundText = true;
                    break;
                }
            }

            Assert.IsTrue(foundText);
        }
    }
}
