using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;

namespace WordPressTests
{
    [TestClass]
    public class CreatePostTests : WordpressTests
    {        
        [TestMethod]
        public void Can_Create_A_Basic_Post()
        {
            NewPostPage.GoTo();
            NewPostPage.CreatePost("This is the test post title").WithBody("Hi, This is the body").Publish();

            NewPostPage.GoToNewPost();
            Assert.AreEqual(PostPage.Title, "This is the test post title", "Title did not match new post.");
        }        
    }
}
