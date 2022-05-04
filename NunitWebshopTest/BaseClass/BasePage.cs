using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitWebshopTest.BaseClass
{
    public abstract class BasePage
    {

        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected IWebElement find(By locator)
        {
            return driver.FindElement(locator);
        }

        protected IList<IWebElement> finds(By locator)
        {
            return driver.FindElements(locator);
        }

        protected void type(By locator, string text)
        {
            find(locator).Clear();
            find(locator).SendKeys(text);
        }

        protected void click(By locator)
        {
            find(locator).Click();
        }

        protected void setComboBoxByText(By element, string value)
        {
            new SelectElement(find(element)).SelectByText(value);
        }

        protected string getTextFromTextBox(By element)
        {
            return find(element).GetAttribute("value");
        }

        protected string getSelectedTextFromComboBox(By element)
        {
            return new SelectElement(find(element)).SelectedOption.Text;
        }


        protected Boolean isDisplayed(By locator)
        {
            try
            {
                return find(locator).Displayed;
            }
            catch (NoSuchElementException exc)
            {
                return false;
            }
        }

        protected void waitUntilElementIsVisble(By element)
        {
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            w.Until(ExpectedConditions.ElementIsVisible(element));
        }

    }
}
