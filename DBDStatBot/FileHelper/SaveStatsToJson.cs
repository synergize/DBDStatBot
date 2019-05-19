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
            List<DaylightStatModel.Playerstats> ListOfPlayers = new List<DaylightStatModel.Playerstats>();
            ReadStatsFiles ReadStats = new ReadStatsFiles();
            UpdateStatsFiles Update = new UpdateStatsFiles();            
            var StatsFromFile = ReadStats.ReadMainFile();

            if (StatsFromFile != null)
            {
                ListOfPlayers = Update.UpdateStats(StatsFromFile, newEntryObj);
            }
            else
            {
                ListOfPlayers.Add(newEntryObj);
            }
            SplitPlayerStats(ListOfPlayers);
            using (StreamWriter file = File.CreateText(StaticDetails.BuildFilePath(StaticDetails.DataDirectoryPath, StaticDetails.DBDStatsFile)))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(file, ListOfPlayers);
                
            }

        }
        private void SplitPlayerStats(List<DaylightStatModel.Playerstats> ListOfPlayers)
        {
            foreach (var item in ListOfPlayers)
            {
                using (StreamWriter file = File.CreateText(StaticDetails.BuildFilePath(StaticDetails.DataDirectoryPath, $"{item.SteamId}.json")))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(file, item);

                }
            }
        }
    }
}
