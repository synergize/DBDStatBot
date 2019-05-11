using DBDStatBot.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DBDStatBot.FileHelper
{
    public static class ReadStatsFiles
    {
        public static List<DaylightStatModel.Playerstats> ReadFile()
        {
            List<DaylightStatModel.Playerstats> obj = new List<DaylightStatModel.Playerstats>();

            var file = File.ReadAllText(StaticDetails.DBDStatsFile);
            if (file != "")
            {
                JsonConvert.PopulateObject(file, obj);
                return obj;                
            }
            else
            {
                return null;
            }
        }
    }
}
