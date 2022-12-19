using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CucumberExample
{
    [Binding]
    public class WeightConversionSteps
    {
        IWebDriver driver;

        [Given(@"The user has navigated to the website")]
        public void GivenTheUserHasNavigatedToTheWebsite()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.rapidtables.com/convert/weight/index.html");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

        }

        [Given(@"They have entered (.*) in the (.*) field")]
        public void GivenTheyHaveEnteredInTheKgField(int p0, string inputFieldId)
        {
            IWebElement inputField = driver.FindElement(By.Id(inputFieldId));
            inputField.SendKeys(p0.ToString());

        }


        [When(@"I press convert")]
        public void WhenIPressConvert()
        {
            IWebElement convertButton = driver.FindElement(By.CssSelector("tr:nth-child(2) input[type=\"button\"]"));
            convertButton.Click();
        }

        [Then(@"the result should be (.*) in the (.*) field")]
        public void ThenTheResultShouldBeInThePoundsField(Decimal p0, string resultFieldId)
        {
            IWebElement poundsField = driver.FindElement(By.Id(resultFieldId));
            Assert.That(poundsField.GetAttribute("value"), Is.EqualTo(p0.ToString()));
        }

        [After("WeightConversion")]
        public void TearDown()
        {
            driver.Dispose();
        }


    }
}
