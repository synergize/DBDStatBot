using DBDStatBot.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DBDStatBot.FileHelper
{
    public static class SaveStatsToJson
    {
        public static void WriteToFile(DaylightStatModel obj)
        {
            List<DaylightStatModel> Testing = new List<DaylightStatModel>();
            var StatsFromFile = ReadStatsFiles.ReadFile();
            if (StatsFromFile != null)
            {
                foreach (var x in StatsFromFile.PlayerStats.Stats)
                {
                    if (!StatsFromFile.PlayerStats.Stats.Contains(x))
                    {
                        obj.PlayerStats.Stats.Add(x);
                    }                    
                }
            }
            using (StreamWriter file = File.CreateText(StaticDetails.DBDStatsFile))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, obj);
            }

        }
    }
}
