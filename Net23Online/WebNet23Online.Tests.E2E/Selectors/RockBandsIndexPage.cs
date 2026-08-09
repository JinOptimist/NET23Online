using OpenQA.Selenium;

namespace WebNet23Online.Tests.E2E.Selectors
{
    public class RockBandsIndexPage
    {
        public static By NameInput = By.CssSelector("#band-name");
        public static By DescriptionInput = By.CssSelector("#band-description");
        public static By ImageUrlInput = By.CssSelector("#band-image");
        public static By SubmitButton = By.CssSelector(".add-band-form-fields button[type=submit]");
        public static By NameOkIcon = By.CssSelector(".add-band-form .name-block .icon.ok");

        public static By BandBlocks = By.CssSelector(".band-list .band");
        public static By NameInBandBlocks = By.CssSelector(".band-body h2");
    }
}
