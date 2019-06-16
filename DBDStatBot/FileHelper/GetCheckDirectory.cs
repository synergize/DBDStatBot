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
    public static void CheckDirectory()
        {
            
            if (!Directory.Exists(StaticDetails.DataDirectoryPath))
            {
                //If the directory for our basecode json file doesn't exist we create it along with the json file. 
                DirectoryInfo dir = Directory.CreateDirectory(StaticDetails.DataDirectoryPath);
                var CreateFile = File.Create(StaticDetails.DBDStatsFile);
                CreateFile.Close();
            }
            else if (!GetCodeExists.CodeExists())
            {
                //if the directory exists but the file doesn't, we create the file. 
                var CreateFile = File.Create(StaticDetails.BuildFilePath(StaticDetails.DataDirectoryPath, StaticDetails.DBDStatsFile));
                CreateFile.Close();
            }
        }
    }
}
