using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using WordpressAutomation;
using WordpressAutomation.Workflows;

namespace WordPressTests
{
    public class WordpressTests
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();

            PostCreator.Initialize();
            LoginPage.GoTo();
            LoginPage.LoginAs("dgrandfield").WithPassword("$t0rmTr00per").Login();
        }

        [TestCleanup]
        public void Cleanup()
        {
            PostCreator.Cleanup();
            Driver.Close();            
        }
    }
}
