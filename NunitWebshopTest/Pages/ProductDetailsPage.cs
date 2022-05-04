using AventStack.ExtentReports;
using NunitWebshopTest.BaseClass;
using NunitWebshopTest.Classes;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NunitWebshopTest.Pages
{
    public class ProductDetailsPage : BasePage
    {
        private By productName = By.XPath("//h1[@itemprop='name']");           
        private By productDescription = By.XPath("//div[@id='short_description_content']/p");
        private By productPrice = By.Id("our_price_display");

        private By addToChartButton = By.Name("Submit");
        private By increaseQuantity = By.XPath("//a[@class='btn btn-default button-plus product_quantity_up']");
    
        private By closeablak = By.XPath("//span[@title='Close window']");
        private By shoppingChartItemNumber = By.XPath("//div[@class='shopping_cart']//a//span[1]");
        private By shoppingChartPrice = By.XPath("//div[@class='shopping_cart']//a//span[4]");


        public ProductDetailsPage(IWebDriver driver) : base(driver)
        {      
        }

        public void PageIsLive()
        {
            waitUntilElementIsVisble(addToChartButton);
        }

        public void increaseQuantityWithIconTo(int repeatClick)
        {
            for (int i = 0; i < repeatClick-1; i++)
            {
                click(increaseQuantity);
            }
        }

        public void addtoChart()
        {
            waitUntilElementIsVisble(addToChartButton);
            click(addToChartButton);
            Thread.Sleep(8000);      
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;          
            js.ExecuteScript("arguments[0].click();", find(closeablak));
            BaseTest.test.Info("Item is added to the cart");
        }

        public string getItemNumberFromShoppingCar()
        {
            return find(shoppingChartItemNumber).GetAttribute("innerHTML");
        }

        public string getPriceFromShoppingCar()
        {
            return find(shoppingChartPrice).GetAttribute("innerHTML");
        }

        public Item GetProductDetails()
        {
            Item detailedItem = new Item();
            detailedItem.itemName = find(productName).Text;
            detailedItem.description = find(productDescription).GetAttribute("innerHTML");
            detailedItem.price = find(productPrice).GetAttribute("innerHTML");

            return detailedItem;           
        }
    }
}
