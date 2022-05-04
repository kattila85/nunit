using AventStack.ExtentReports;
using NUnit.Framework;
using NunitWebshopTest.BaseClass;
using NunitWebshopTest.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NunitWebshopTest.Tests
{
    class ShoppingCarTests : BaseTest
    {
        [Test, Property("details", "It checks the displayed item number in cart in case of 1 item is added. TC02175")]
        public void AddOneItemToCart()
        {
           
            test.Info("Open first product on the page");
            mainPage.openFirstProduct();
            productDetailsPage.PageIsLive();         
            productDetailsPage.addtoChart();
            Assert.AreEqual(1, mainPage.getShoppingCartItemNumber(), "Displayed cart number is not the expected");
            test.Pass("Checking item number is cart");
        }

        [Test, Property("details", "It checks the displayed item number in cart in case of more than 1 item is added.TC02175")]
        public void AddMoreFromOneItemToCart()
        {
          
            test.Log(Status.Info, "Open first product on the page");
            mainPage.openFirstProduct();
            productDetailsPage.PageIsLive();

            int expectedQuantity = 5;

            productDetailsPage.increaseQuantityWithIconTo(expectedQuantity);
            productDetailsPage.addtoChart();

            int numberOfItmesInShoppingCart = mainPage.getShoppingCartItemNumber();

            Assert.AreEqual(6, numberOfItmesInShoppingCart, "Displayed cart number is not the expected");       
            test.Log(Status.Pass, "Checking item number is cart");                   
        }
    }
}
