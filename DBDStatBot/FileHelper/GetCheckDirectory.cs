using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DBDStatBot.Models;

namespace DBDStatBot.FileHelper
{
    public static class GetCheckDirectory
    {
        /// <summary>
        /// Checks if our Data Directory exists. If it doesn't, we create it.
        /// We also check to see if the JSON file exists. If it doesn't, we create it.
        /// </summary>
        /// <param name="file"></param>
    public static void CheckDirectory(string file)
        {
            
            if (!Directory.Exists(file))
            {
                //If the directory for our basecode json file doesn't exist we create it along with the json file. 
                DirectoryInfo dir = Directory.CreateDirectory(file);
                var CreateFile = File.Create(StaticDetails.DBDStatsFile);
                CreateFile.Close();
            }
            else if (!GetCodeExists.CodeExists())
            {
                //if the directory exists but the file doesn't, we create the file. 
                var CreateFile = File.Create(StaticDetails.DBDStatsFile);
                CreateFile.Close();
            }
        }
    }
}
