using DBDStatBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discord;

namespace DBDStatBot.APICall.Filter
{
   public class RemoveFilteredItems
    {
        public DaylightStatModel.Playerstats RemoveUselessStats(DaylightStatModel.Playerstats obj)
        {
            ///< summary >
            /// Loop through < see cref="aryFilter"/> in order to remove unncessary stats stats from <see cref="DaylightStatModel"/> object.
            /// </ summary >
            /// 
                DaylightStatModel.Playerstats newobj = new DaylightStatModel.Playerstats();
                newobj.Stats = new List<DaylightStatModel.Stat>();
                if (StatFilterDictionary.DictionaryFilter.Count == 0)
                {
                    StatFilterDictionary.DictionaryFilter = StatFilterDictionary.GetFilterDictionary();
                }
                newobj.GameName = obj.GameName;
                newobj.LastUpdated = obj.LastUpdated;
                newobj.SteamId = obj.SteamId;
                foreach (var item in StatFilterDictionary.DictionaryFilter)
                {
                    var current = obj.Stats.Find(x => x.Name == item.Key);
                    if (current == null) break;
                    current.Name = StatFilterDictionary.DictionaryFilter[current.Name];
                    newobj.Stats.Add(current);
                }
                return newobj;
            }
            
        }
    }
}
