using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow.Assist;

namespace CucumberExample
{
    [Binding]
    public class SpeakingClockSteps
    {
        private DateTime dateTime;
        private SpeakingClock speakingClock;
        private string actualTimeAsText;


        private List<TimeTable> timeTables;


        [Given(@"the time is (.*) hours and (.*) minutes")]
        public void GivenTheTimeIsHoursAndMinutes(int hours, int minutes)
        {
            dateTime = new DateTime(2016,10,27,hours,minutes,0);
            speakingClock = new SpeakingClock();
        }
        
        [When(@"I request the time")]
        public void WhenIRequestTheTime()
        {
            
            actualTimeAsText = speakingClock.GetTimeAsText(dateTime);
        }
        
        [Then(@"the result should be a time of (.*)")]
        public void ThenTheResultShouldBeTimeAsText(string expectedTimeAsText)
        {
            Assert.AreEqual(expectedTimeAsText, actualTimeAsText);
        }


        [Given(@"I have been provided this set of times and expected results")]
        public void GivenIHaveBeenProvidedThisSetOfTimesAndExpectedResults(Table tableOfTimes)
        {

            timeTables = tableOfTimes.CreateSet<TimeTable>().ToList();
            
        }

        [When(@"I request all the times as text")]
        public void WhenIRequestAllTheTimesAsText()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"all the text should match")]
        public void ThenAllTheTextShouldMatch()
        {
            speakingClock = new SpeakingClock();
            foreach (var currentTimeExample in timeTables)
            {
                DateTime time = new DateTime(2016,10,28,currentTimeExample.Hours, currentTimeExample.Minutes,0);
                Assert.AreEqual(currentTimeExample.ExpectedText,speakingClock.GetTimeAsText(time));  
            }
        }
    }
}
