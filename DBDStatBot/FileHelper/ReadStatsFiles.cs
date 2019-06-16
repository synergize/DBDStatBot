﻿using DBDStatBot.Models;
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
        
        public List<DaylightStatModel.Playerstats> ReadMainFile()
        {
            List<DaylightStatModel.Playerstats> ListOfStatsFromFile = new List<DaylightStatModel.Playerstats>();
            try
            {
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public DaylightStatModel.Playerstats ReadIndividualPlayerFile(string id)
        {
            DaylightStatModel.Playerstats obj = new DaylightStatModel.Playerstats();
            try
            {
                if (!File.Exists(StaticDetails.BuildFilePath(StaticDetails.DataDirectoryPath, $"{id}.json")))
                {
                    var SteamIDJson = File.Create(StaticDetails.BuildFilePath(StaticDetails.DataDirectoryPath, $"{id}.json"));
                    SteamIDJson.Close();
                }
                var file = File.ReadAllText(StaticDetails.BuildFilePath(StaticDetails.DataDirectoryPath, $"{id}.json"));
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
            catch (Exception msg)
            {
                Console.WriteLine(msg);
                throw;
            }
        }
    }
}
