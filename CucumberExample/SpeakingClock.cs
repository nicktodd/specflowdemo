using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CucumberExample
{
    public class SpeakingClock : ISpeakingClock
    {
        public string GetTimeAsText(DateTime dateTime)
        {
            if (dateTime.Hour == 0 && dateTime.Minute == 0)
            {
                return "midnight";
            }
            else if (dateTime.Hour == 12 && dateTime.Minute == 0)
            {
                return "midday";
            }
            else return null;
        }
    }
}
