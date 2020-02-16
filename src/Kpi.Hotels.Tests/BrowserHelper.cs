using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Kpi.Hotels.Tests
{
    public class BrowserHelper
    {
        private const string driverDir = "C:/Program Files (x86)/Google/Chrome/Application";
        IWebDriver webDriver;
        public void Init_Browser()
        {
            webDriver = new ChromeDriver(driverDir);
            webDriver.Manage().Window.Maximize();
        }
        public string Title
        {
            get { return webDriver.Title; }
        }
        public void Goto(string url)
        {
            webDriver.Url = url;
        }
        public void Close()
        {
            webDriver.Quit();
        }
        public IWebDriver getDriver
        {
            get { return webDriver; }
        }
    }
}
