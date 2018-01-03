﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordpressAutomation
{
    public class NewPostPage
    {
        public static void GoTo()
        {
            LeftNavigation.Posts.AddNew.Select();            
        }

        public static CreatePostCommand CreatePost(string title)
        {
            return new CreatePostCommand(title);
        }

        public static void GoToNewPost()
        {
            var message = Driver.Instance.FindElement(By.Id("sample-permalink"),4);
            var newPostLink = message.FindElements(By.TagName("a"))[0];
            Driver.Wait(1);
            newPostLink.Click();
        }

        public static bool IsInEditMode()
        {
            var heading = Driver.Instance.FindElement(By.ClassName("wp-heading-inline"));
            if (heading.Text == "Edit Page")
                return true;
            return false;
        }

        public static string Title
        {
            get
            {
                var title = Driver.Instance.FindElement(By.Id("title"));
                if (title != null)
                    return title.GetAttribute("value");
                return string.Empty;
            }
        }
    }

    public class CreatePostCommand
    {
        private readonly string title;
        private string body;

        public CreatePostCommand(string title)
        {
            this.title = title;        
        }

        public CreatePostCommand WithBody(string body)
        {
            this.body = body;
            return this;
        }
        public void Publish()
        {
            Driver.Instance.FindElement(By.Id("title")).SendKeys(title);

            Driver.Instance.SwitchTo().Frame("content_ifr");
            Driver.Instance.SwitchTo().ActiveElement().SendKeys(body);
            Driver.Instance.SwitchTo().DefaultContent();

            Driver.Wait(1);

            Driver.Instance.FindElement(By.Id("publish")).Click();
        }

    }
}
