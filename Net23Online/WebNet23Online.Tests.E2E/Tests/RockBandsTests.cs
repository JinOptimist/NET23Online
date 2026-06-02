using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebNet23Online.Tests.E2E.Helper;
using WebNet23Online.Tests.E2E.Selectors;

namespace WebNet23Online.Tests.E2E.Tests
{
    public class RockBandsTests
    {
        private IWebDriver _webDriver;
        private WebDriverWait _waiter;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _webDriver = new ChromeDriver();
            _waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(6));
        }

        [TestCase("Iron Eclipse", "Heavy riffs and thunderous drums on every stage")]
        [TestCase("Velvet Thunder", "Classic rock energy with modern stadium anthems")]
        [TestCase("Crimson Voltage", "Electric guitars blazing through the midnight crowd")]
        public void CreateRockBand_Positive(string newBandName, string description)
        {
            _webDriver.Logout();
            _webDriver.LoginAsAdmin();

            _webDriver.Navigate().GoToUrl($"{GlobalConstants.BASE_URL}/RockBands/Index");

            _waiter.Until(d => d.FindElements(RockBandsIndexPage.NameInput).Any(e => e.Displayed));
            var nameInput = _webDriver.FindElement(RockBandsIndexPage.NameInput);
            new Actions(_webDriver)
                .ScrollToElement(nameInput)
                .Perform();

            nameInput.SendKeys(newBandName);
            nameInput.SendKeys(Keys.Tab);

            _waiter.Until(d => _webDriver.FindElement(RockBandsIndexPage.NameOkIcon).Displayed);

            _webDriver.FindElement(RockBandsIndexPage.DescriptionInput)
                .SendKeys(description);
            _webDriver.FindElement(RockBandsIndexPage.ImageUrlInput)
                .SendKeys("https://upload.wikimedia.org/wikipedia/commons/thumb/1/19/Queen_-_Montreux_2011_-_Brian_May.jpg/640px-Queen_-_Montreux_2011_-_Brian_May.jpg");

            var submitButton = _webDriver.FindElement(RockBandsIndexPage.SubmitButton);
            _waiter.Until(d => submitButton.Enabled);
            submitButton.Click();

            var allBandBlocks = _webDriver.FindElements(RockBandsIndexPage.BandBlocks);

            _waiter.Until(d => allBandBlocks.Any());

            var lastBandBlock = allBandBlocks.Last();
            var lastBandName = lastBandBlock.FindElement(RockBandsIndexPage.NameInBandBlocks).Text;
            Assert.That(newBandName == lastBandName);
        }

        [Test]
        public void CreateRockBand_GuestForbidden()
        {
            _webDriver.Logout();

            _webDriver.Navigate().GoToUrl($"{GlobalConstants.BASE_URL}/RockBands/Index");

            Assert.That(_webDriver.FindElements(RockBandsIndexPage.NameInput), Is.Empty);
        }
    }
}
