using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DBDStatBot.Models;

namespace DBDStatBot.FileHelper
{
    public static class GetCodeExists
    {
        public static bool CodeExists()
        {
            return File.Exists(StaticDetails.DBDStatsFile);
        }
    }
}
