using DBDStatBot.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DBDStatBot.FileHelper
{
    public class ReadStatsFiles
    {
        /// <summary>
        /// Class file that reads the json file from disk. If the file isn't empty we return it's contents.
        /// Otherwise we return null.
        /// </summary>
        /// <returns></returns>
        public List<DaylightStatModel.Playerstats> ReadFile()
        {
            List<DaylightStatModel.Playerstats> ListOfStatsFromFile = new List<DaylightStatModel.Playerstats>();

            var file = File.ReadAllText(StaticDetails.BuildFilePath(StaticDetails.DataDirectoryPath, StaticDetails.DBDStatsFile));
            if (file != "")
            {
                JsonConvert.PopulateObject(file, ListOfStatsFromFile);
                return ListOfStatsFromFile;                
            }
            else
            {
                return null;
            }
        }
    }
}
