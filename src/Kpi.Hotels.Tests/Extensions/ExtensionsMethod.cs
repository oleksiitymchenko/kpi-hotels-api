using OpenQA.Selenium;

namespace Kpi.Hotels.Tests.Extensions
{
    public static class ExtensionMethods
    {
        public static bool ElementExistsById(this IWebDriver driver, string id)
        {
            IWebElement e = null;
            try
            {
                e = driver.FindElement(By.Id(id));
            }
            catch (NoSuchElementException) { }
            return !(e == null);
        }
        public static bool Exists(this IWebElement e)
        {
            if (e == null)
                return false;
            return true;
        }
    }
}
