using OpenQA.Selenium;

namespace WordpressAutomation
{
    public partial class LeftNavigation
    {
        public class MenuSelector
        {
            public static void Select(string toplevelmenuid, string submenulinktext)
            {
                Driver.Instance.FindElement(By.Id(toplevelmenuid)).Click();
                Driver.Instance.FindElement(By.LinkText(submenulinktext)).Click();
            }
        }
    }
}
