using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordpressAutomation
{
    public class PostPage
    {
        
        public static string Title
        {
            get
            {
                Driver.Instance.SwitchTo().Window(Driver.Instance.WindowHandles.Last());
                var title = Driver.Instance.FindElement(By.ClassName("entry-title"),2);
                if (title != null)
                    return title.Text;
                return string.Empty;
            }           
        }
        
    }
}
