using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CucumberExample
{
    [Binding]
    public class CalculatorSteps
    {

        private List<ThreeValuesTable> m_ThreeValuesTable;
        private List<int> m_ThreeValueAdditionResults;
        private int m_ResultOfAddingThreeValues;
        private Calculator m_Cut = new Calculator();

        List<int> numbers = new List<int>();
        private int result = 0;

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            numbers.Add(p0);
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            result = numbers.Sum();
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Assert.AreEqual(result, p0);
        }

        [Given(@"I have entered the following set of values and expected results")]
        public void GivenIHaveEnteredTheFollowingSetOfValuesAndExpectedResults(Table threeValuesTable)
        {
            m_ThreeValuesTable = threeValuesTable.CreateSet<ThreeValuesTable>().ToList();
        }

        [When(@"I add them all together")]
        public void WhenIAddThemAllTogether()
        {
            m_ThreeValueAdditionResults = new List<int>();

            foreach (var currentAddExample in m_ThreeValuesTable)
            {
                int result = m_Cut.Add(currentAddExample.Value1, currentAddExample.Value2);
                result = m_Cut.Add(result, currentAddExample.Value3);
                m_ThreeValueAdditionResults.Add(result);
            }
        }

        [Then(@"the result should be as expected")]
        public void ThenTheResultShouldBeAsExpected()
        {
            for(int i = 0; i < m_ThreeValuesTable.Count; i++)
            {
                var expectedResult = m_ThreeValuesTable[i].ExpectedResult;
                Assert.That(m_ThreeValueAdditionResults[i], Is.EqualTo(expectedResult));
            }
        }

    }
}
