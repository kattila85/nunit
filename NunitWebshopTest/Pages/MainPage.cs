using NunitWebshopTest.BaseClass;
using NunitWebshopTest.Classes;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitWebshopTest.Pages
{
    public class MainPage : BasePage
    {
        private By mainMenuElements = By.XPath("//ul[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']/li/a");
       
        private By firstProductName = By.XPath("//a[@class='product-name'][1]");
        private By firstProductDescription = By.XPath("//p[@class='product-desc'][1]");
        private By firstProductPrice = By.XPath("//span[@class='price product-price'][1]");

        private By shoppingCartItemNumber = By.XPath("//div[@class='shopping_cart']//span[1]");
        private By shoppingCartPrice = By.XPath("//div[@class='shopping_cart']//span[4]");


        public MainPage(IWebDriver driver) : base(driver)
        {

        }

        public List<string> getMainMenuElements()
        {
            List<string> mainMenuElementNames = new List<string>();

            IList<IWebElement> menuElements = finds(mainMenuElements);
            foreach (IWebElement item in menuElements)
            {
                mainMenuElementNames.Add(item.Text);
            }

            return mainMenuElementNames;
        }

        public Item getProductDetails()
        {
            waitUntilElementIsVisble(firstProductName);      
            Item firstItem = new Item();
            firstItem.itemName = find(firstProductName).Text;
            firstItem.description = find(firstProductDescription).GetAttribute("innerHTML");
            firstItem.price = find(firstProductPrice).GetAttribute("innerHTML");
           
            return firstItem;
        }

        public void openFirstProduct()
        {
            waitUntilElementIsVisble(firstProductName);
            click(firstProductName);         
        }

        public int getShoppingCartItemNumber()
        {
           return int.Parse(find(shoppingCartItemNumber).GetAttribute("innerHTML"));
        }

        public string getShoppingCartTotalPrice()
        {
            return find(shoppingCartPrice).GetAttribute("innerHTML");
        }
    }
}
