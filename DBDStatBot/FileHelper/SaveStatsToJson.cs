using DBDStatBot.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DBDStatBot.FileHelper
{
    public class SaveStatsToJson
    {
        /// <summary>
        /// Class file designed to save our list of player's stats, steam ID and Game to a JSON file. 
        /// </summary>
        /// <param name="newEntryObj"></param>

        public void WriteToFile(DaylightStatModel.Playerstats newEntryObj)
        {
            using (StreamWriter file = File.CreateText(StaticDetails.BuildFilePath(StaticDetails.DataDirectoryPath, $"{newEntryObj.SteamId}.json")))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(file, newEntryObj);                
            }
        }
    }
}
