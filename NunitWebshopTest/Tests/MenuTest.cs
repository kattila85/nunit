using AventStack.ExtentReports;
using NUnit.Framework;
using NunitWebshopTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NunitWebshopTest.Tests
{
   
    class MenuTest : BaseTest
    {
        [Test, Property("details","It checks the main menu elements. TC02145")]
        public void TestMainMenuElements()
        {
            test.Info("Check menu items");
       
            List<string> expectedMainMenuElementNames = new List<string>() { "WOMEN", "DRESSES", "T-SHIRTS" };
            List<string> getMainMenuElementNames = mainPage.getMainMenuElements();
            
            Assert.AreEqual(expectedMainMenuElementNames, getMainMenuElementNames, "The main menu elements are not the expected");
            test.Log(Status.Pass, "Checking main menu elements");
        }

      
    }
}
