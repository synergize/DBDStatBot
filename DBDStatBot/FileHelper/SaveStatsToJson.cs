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
            using (StreamWriter file = File.AppendText(StaticDetails.DBDStatsFile))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, obj);
            }
        }
    }
}
