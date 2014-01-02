using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cAlarm
{
    [Serializable]
    public class alarm
    {
            public string hour;
            public string minute;
            public bool once;
            public bool active;
            public bool activated = false;
            public int[] repeat;
            public alarm(string Hour, string Minute)
            {
                minute = Minute;
                hour = Hour;
                active = true;
            }
            public alarm(string Hour, string Minute, int[] Repeat)
            {
                minute = Minute;
                hour = Hour;
                repeat = Repeat;
                active = true;
            }
    }
}
