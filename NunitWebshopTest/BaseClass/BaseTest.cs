using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NunitWebshopTest.Pages;
using NunitWebshopTest.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NunitWebshopTest.BaseClass
{
    class BaseTest
    {
        public IWebDriver driver;
        public static ExtentTest test;
        //  private readonly string BASE_URL = "http://automationpractice.com/index.php";
        private readonly string BASE_URL = TestContext.Parameters.Get("pageurl");
        private readonly string Browser = TestContext.Parameters.Get("browser");

        public MainPage mainPage;
        public ProductDetailsPage productDetailsPage;

        [SetUp]
        public void initialize()
        {

            switch (Browser)
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

              
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(BASE_URL);
            test = ExtentSetupClass.extent.CreateTest(TestContext.CurrentContext.Test.ClassName.Replace("NunitWebshopTest.Tests.", "") + " - " + TestContext.CurrentContext.Test.Name, TestContext.CurrentContext.Test.Properties.Get("details").ToString());
            mainPage = new MainPage(driver);
            productDetailsPage = new ProductDetailsPage(driver);
           
        }

        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            var errorMessage = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message)
            ? "" : string.Format("{0}", TestContext.CurrentContext.Result.Message);

            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
            ? "" : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);


            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    string currentTime = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");
                    String fileName = TestContext.CurrentContext.Test.Name + "_" + currentTime;
                    String screenShotPath = Capture(driver, fileName);
                    test.Log(Status.Fail, "Test failed");
                    test.Log(Status.Fail, errorMessage);
                    test.Log(Status.Fail, stacktrace);
                    test.AddScreenCaptureFromPath(screenShotPath);
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
            test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            driver.Quit();
        }
        public static string Capture(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            
            string  screenshotPath = ExtentSetupClass.reportDirectory + @"\Screenshots\";
            Directory.CreateDirectory(screenshotPath);
            var savedFilePath = screenshotPath + screenShotName + ".png";
            screenshot.SaveAsFile(savedFilePath);
            return savedFilePath;

        }          
    }
}
