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
        public DaylightStatModel RemoveUselessStats(DaylightStatModel obj)
        {
            ///< summary >
            /// Loop through < see cref="aryFilter"/> in order to remove unncessary stats stats from <see cref="DaylightStatModel"/> object.
            /// </ summary >

            if (StatFilterDictionary.DictionaryFilter.Count == 0)
            {
                StatFilterDictionary.DictionaryFilter = StatFilterDictionary.GetFilterDictionary();
            }

            for (int i = 0; i < obj.PlayerStats.Stats.Count; i++)
            {
                string name = obj.PlayerStats.Stats[i].Name;

                if (!StatFilterDictionary.DictionaryFilter.Keys.Contains(name))
                {
                    obj.PlayerStats.Stats.Remove(obj.PlayerStats.Stats[i]);
                    i--;
                }
                else
                {
                    obj.PlayerStats.Stats[i].Name = StatFilterDictionary.DictionaryFilter[name];
                }
            }
            return obj;
        }
    }
}
