using System;
using System.Collections.Generic;
using System.Text;

namespace DBDStatBot.DateTime_Helper
{
    static class GetTime
    {
        public static DateTime CurrentTime()
        {
            return DateTime.UtcNow;
        }
    }
}
