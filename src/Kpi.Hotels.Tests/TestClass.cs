using Kpi.Hotels.Tests.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Kpi.Hotels.Tests
{
    [TestFixture]
    public class TestClass
    {
        private BrowserHelper brow = new BrowserHelper();
        private string baseUri = "https://kpi-hotels-api.azurewebsites.net";
        private string clientsUri = "/gui/Clients/Index";
        private string roomsUri = "/gui/Rooms/Index";
        private string clientsEditUri = "/gui/Clients/Edit?id=";
        private string serviceClassUri = "/gui/ServiceClasses/Index";

        IWebDriver driver;

        [SetUp]
        public void start_Browser()
        {
            brow.Init_Browser();
        }

        [Test]
        public void Rooms_button_redirect_to_rooms_list()
        {
            brow.Goto(baseUri+clientsUri);
            Wait();
            driver = brow.getDriver;
            var roomsLink = driver.FindElement(By.CssSelector("body > header > nav > div > div > ul > li:nth-child(3) > a"));
            roomsLink.Click();
            Wait();
            var currenturl = driver.Url;

            Assert.AreEqual(baseUri + roomsUri, currenturl);
        }

        [Test]
        public void Edit_button_redirects_to_edit_page()
        {
            brow.Goto(baseUri + clientsUri);
            Wait();
            driver = brow.getDriver;
            var editLink = driver.FindElement(By.CssSelector("body > div > main > table > tbody > tr:nth-child(3) > td:nth-child(7) > a:nth-child(1)"));
            editLink.Click();
            Wait();
            var currenturl = driver.Url;
            var expectedUrl = baseUri + clientsEditUri;

            Assert.IsTrue(currenturl.Contains(expectedUrl));
            Assert.IsTrue(currenturl.StartsWith(expectedUrl));
            Assert.IsTrue(currenturl.Length - expectedUrl.Length == 36);
        }

        [Test]
        public void Back_button_returns_correctly()
        {
            var expectedUrl = baseUri + clientsUri;
            brow.Goto(baseUri + clientsUri);
            Wait();
            driver = brow.getDriver;
            var editLink = driver.FindElement(By.CssSelector("body > div > main > table > tbody > tr:nth-child(3) > td:nth-child(7) > a:nth-child(1)"));
            editLink.Click();
            Wait();
            var backButtonLink = driver.FindElement(By.CssSelector("body > div > main > div:nth-child(5) > a"));
            backButtonLink.Click();
            Wait();
            var actualUrl = driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [Test]
        public void ServiceClass_creates_and_deletes_normally()
        {
            var listUri = baseUri + serviceClassUri;
            var price = 9809090909090909;
            brow.Goto(listUri);
            Wait();
            driver = brow.getDriver;
            var rowsAmountBeforeCreation = driver.FindElements(By.CssSelector("body > div > main > table > tbody > tr")).Count;
            var createLink = driver.FindElement(By.CssSelector("body > div > main > p > a"));
            createLink.Click();
            var roomPrice = driver.FindElement(By.Name("RoomPrice"));
            roomPrice.SendKeys(price.ToString());
            var roomKind = driver.FindElement(By.Name("RoomKind"));
            var selectElement = new SelectElement(roomKind);
            selectElement.SelectByText("Double");
            var createButton = driver.FindElement(By.CssSelector("body > div > main > div.row > div > form > div:nth-child(3) > input"));
            createButton.Click();
            Wait();
            var rowsAmountAfterCreation = driver.FindElements(By.CssSelector("body > div > main > table > tbody > tr")).Count;
            var currentUri = driver.Url;
            Assert.AreEqual(rowsAmountBeforeCreation + 1, rowsAmountAfterCreation);
            Assert.AreEqual(listUri, currentUri);
            var deleteLink = driver.FindElement(By.CssSelector("body > div > main > table > tbody > tr:nth-child(1) > td:nth-child(3) > a:nth-child(3)"));
            deleteLink.Click();
            Wait();
            var deleteButton = driver.FindElement(By.CssSelector("body > div > main > div > form > input.btn.btn-danger"));
            deleteButton.Click();
            Wait();
            var rowsAmountAfterDeletion = driver.FindElements(By.CssSelector("body > div > main > table > tbody > tr")).Count;
            Assert.AreEqual(rowsAmountBeforeCreation, rowsAmountAfterDeletion);
        }

        [Test]
        public void ServiceClass_RoomPrice_Should_Be_A_Number()
        {
            var listUri = baseUri + serviceClassUri;
            brow.Goto(listUri);
            Wait();
            driver = brow.getDriver;
            var createLink = driver.FindElement(By.CssSelector("body > div > main > p > a"));
            createLink.Click();

            Assert.IsFalse(driver.ElementExistsById("RoomPrice-error"));
            var roomPrice = driver.FindElement(By.Name("RoomPrice"));
            roomPrice.SendKeys(Guid.NewGuid().ToString());
            var roomKind = driver.FindElement(By.Name("RoomKind"));
            var selectElement = new SelectElement(roomKind);
            selectElement.SelectByText("Double");
            var createButton = driver.FindElement(By.CssSelector("body > div > main > div.row > div > form > div:nth-child(3) > input"));
            createButton.Click();
            Wait();
            Assert.IsTrue(driver.ElementExistsById("RoomPrice-error"));
        }

        [TearDown]
        public void Close ()
        {
            brow.Close();
        }

        private void Wait()
        {
            Thread.Sleep(1000);
        }
    }
}
