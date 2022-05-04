using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;
using System.IO;


namespace NunitWebshopTest.Tests
{
    [SetUpFixture]
    public class ExtentSetupClass
    {
        public static ExtentReports extent;
        public static readonly string baseDirectory = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug\net5.0", "");
        public static readonly string reportDirectory = baseDirectory + @"\Test_Execution_Report\" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");
        
        [OneTimeSetUp]
        protected void Setup()
        {
            extent = new ExtentReports();           
            DirectoryInfo di = Directory.CreateDirectory(reportDirectory);
            var htmlReporter = new ExtentHtmlReporter(reportDirectory + @"\Automation_Report.html");
            extent.AddSystemInfo("Environment", TestContext.Parameters.Get("browser"));
            extent.AddSystemInfo("User Name", "Neha");
            extent.AttachReporter(htmlReporter);
        }
        [OneTimeTearDown]
        protected void TearDown()
        {
            extent.Flush();          
        }
    }
}
