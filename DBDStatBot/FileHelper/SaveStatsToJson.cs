using DBDStatBot.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DBDStatBot.FileHelper
{
    public static class SaveStatsToJson
    {
        public static void WriteToFile(DaylightStatModel obj, string steamID)
        {
            List<DaylightStatModel.Playerstats> Testing = new List<DaylightStatModel.Playerstats>();            
            var StatsFromFile = ReadStatsFiles.ReadFile();
            if (StatsFromFile != null)
            {
                for (int i = 0; i < StatsFromFile.Count; i++)
                {
                    if (StatsFromFile[i].SteamId == steamID)
                    {
                        StatsFromFile[i].Stats.Add(obj.PlayerStats.Stats[i]);
                    }
                    else
                    {
                        Testing.Add(obj.PlayerStats);
                    }
                    Testing.Add(StatsFromFile[i]);
                }
            }
            else
            {
                Testing.Add(obj.PlayerStats);
            }
            
            using (StreamWriter file = File.CreateText(StaticDetails.DBDStatsFile))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Testing);
            }

        }
    }
}
