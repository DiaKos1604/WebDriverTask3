using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebDriverManager.DriverConfigs.Impl;

namespace WebDriverTask3
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
        }

        [Test]
        public void CalculatorTests()
        {
            driver.Url = "https://cloud.google.com/products/calculator/?hl=en";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            IWebElement addToEstimate = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Add to estimate']")));
            addToEstimate.Click();

            IWebElement selectComputerEngine = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//h2[(text()='Compute Engine')]")));
            selectComputerEngine.Click();

            IWebElement numberOfInstance = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("c13")));
            numberOfInstance.SendKeys("4");

            IWebElement cookieNotification = wait.Until(driver => driver.FindElement(By.Id("glue-cookie-notification-bar-1")));
            IWebElement closeButton = cookieNotification.FindElement(By.CssSelector("button"));
            closeButton.Click();
            wait.Until(driver => !cookieNotification.Displayed);

            IWebElement operatingSystemDropdown = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("")));
            operatingSystemDropdown.Click();
            



            IWebElement provisioningModelDropdown = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//label[text()='Regular']")));
            Actions actions = new Actions(driver);
            actions.MoveToElement(provisioningModelDropdown).Click().Perform();

            IWebElement addToEstimateButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'Add to Estimate')]")));
            addToEstimateButton.Click();

            IWebElement emailEstimateButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'Email Estimate')]")));
            emailEstimateButton.Click();

            string costSummaryText = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//md-list-item[@ng-repeat='item in estimateCtrl.EmailedEstimate.MachineSpecs']"))).Text;
            Assert.IsTrue(costSummaryText.Contains("n1-standard-8"), "Machine type does not match.");
            Assert.IsTrue(costSummaryText.Contains("4"), "Number of instances does not match.");
            Assert.IsTrue(costSummaryText.Contains("Free: Debian"), "Operating System does not match.");
            Assert.IsTrue(costSummaryText.Contains("Regular"), "Provisioning model does not match.");
            Assert.IsTrue(costSummaryText.Contains("NVIDIA Tesla V100"), "GPU type does not match.");
            Assert.IsTrue(costSummaryText.Contains("2x375 GB"), "Local SSD does not match.");
            Assert.IsTrue(costSummaryText.Contains("europe-west4"), "Region does not match.");

        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}