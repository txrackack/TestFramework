using OpenQA.Selenium;
using System;
using System.Linq;

namespace WordpressAutomation
{
    public class LoginPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress + "wp-login.php");            
        }

        public static LoginCommand LoginAs(string username)
        {
            return new LoginCommand(username);
        }        
    }

    public class LoginCommand
    {
        private readonly string username;
        private string password;

        public LoginCommand(string username)
        {
            this.username = username;
        }
        public LoginCommand WithPassword(string password)
        {
            this.password = password;
            return this;
        }

        public void Login()
        {
            var loginInput = Driver.Instance.FindElement(By.Id("user_login"));
            loginInput.SendKeys(username);

            var passwordInput = Driver.Instance.FindElement(By.Id("user_pass"));
            passwordInput.SendKeys(password);

            var loginButton = Driver.Instance.FindElement(By.Id("wp-submit"));
            loginButton.Click();
        }
    }
}
