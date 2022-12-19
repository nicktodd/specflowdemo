using System;
using TechTalk.SpecFlow;

namespace CucumberExample
{
    [Binding]
    public class TestGoogleChromeSteps
    {
        [Given(@"I search for Java")]
        public void GivenISearchForJava()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press the search button")]
        public void WhenIPressTheSearchButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the title should be Java in the browser")]
        public void ThenTheTitleShouldBeJavaInTheBrowser()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
