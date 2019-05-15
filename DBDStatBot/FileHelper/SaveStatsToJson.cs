using DBDStatBot.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DBDStatBot.FileHelper
{
    public static class SaveStatsToJson
    {
        /// <summary>
        /// Class file designed to save our list of player's stats, steam ID and Game to a JSON file. 
        /// </summary>
        /// <param name="newEntryObj"></param>
        public static void WriteToFile(DaylightStatModel newEntryObj)
        {
            List<DaylightStatModel.Playerstats> ListOfPlayers = new List<DaylightStatModel.Playerstats>();            
            var StatsFromFile = ReadStatsFiles.ReadFile();

            if (StatsFromFile != null)
            {
                ListOfPlayers = UpdateStatsFiles.UpdateStats(StatsFromFile, newEntryObj);
            }
            else
            {
                ListOfPlayers.Add(newEntryObj.PlayerStats);
            }
            
            using (StreamWriter file = File.CreateText(StaticDetails.BuildFilePath(StaticDetails.DataDirectoryPath, StaticDetails.DBDStatsFile)))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(file, ListOfPlayers);
                
            }

        }
    }
}
