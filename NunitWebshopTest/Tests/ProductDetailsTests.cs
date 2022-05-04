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
    class ProductDetailsTests : BaseTest
    {
        [Test, Property("details", "It checks that main page item's details are the same as on the details page.")]
        public void compareProductDetails()
        {
            Item selectedItem = mainPage.getProductDetails();
            mainPage.openFirstProduct();
            productDetailsPage.PageIsLive();

            Item detailedItem = productDetailsPage.GetProductDetails();
            Assert.AreEqual(selectedItem.itemName, detailedItem.itemName, "The name is different value");
            test.Pass("Check item's name. Name in main page is " + selectedItem.itemName + " Name in details page is " + selectedItem.itemName);
          
           
            Assert.AreEqual(selectedItem.description.Trim(), detailedItem.description.Trim() + " fdas", "The description is different. Description in main page is {0} Description in details page is {1}", selectedItem.description, detailedItem.description);
            test.Pass("Check item's description");
           
            Assert.AreEqual(selectedItem.price.Trim(), detailedItem.price.Trim(), "The price is not the appropriate");
            test.Pass("Check item's price");
        }

    }
}
