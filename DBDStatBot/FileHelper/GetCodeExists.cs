using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DBDStatBot.Models;

namespace DBDStatBot.FileHelper
{
    public static class GetCodeExists
    {
        /// <summary>
        /// Checks if our JSON file exists. 
        /// </summary>
        /// <returns></returns>
        public static bool CodeExists()
        {
            return File.Exists(StaticDetails.BuildFilePath(StaticDetails.DataDirectoryPath, StaticDetails.DBDStatsFile));
        }
    }
}
