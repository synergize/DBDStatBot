using DBDStatBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBDStatBot.FileHelper
{
    public class UpdateStatsFiles
    {
        ///< summary >
        /// This class is designed to update the json storeage file. If the new entry already exists we overwrite the entry instead of add a new one. 
        /// If the new entry doesn't exist in the json file we add the new entry and return it.
        /// </ summary >
        
        public List<DaylightStatModel.Playerstats> UpdateStats(List<DaylightStatModel.Playerstats> StatsFromFileList, DaylightStatModel NewEntryObj)
        {
            for (int i = 0; i < StatsFromFileList.Count; i++)
            {
                if (StatsFromFileList[i].SteamId == NewEntryObj.PlayerStats.SteamId)
                {
                    StatsFromFileList[i].Stats.Add(NewEntryObj.PlayerStats.Stats[i]);
                    return StatsFromFileList;
                }
            }
            StatsFromFileList.Add(NewEntryObj.PlayerStats);
            return StatsFromFileList;
        }
    }
}
