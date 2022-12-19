using System;

namespace CucumberExample
{
    public interface ISpeakingClock
    {
        string GetTimeAsText(DateTime dateTime);
    }
}