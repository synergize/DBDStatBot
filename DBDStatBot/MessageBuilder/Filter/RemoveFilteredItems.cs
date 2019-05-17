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
        public List<DaylightStatModel> RemoveUselessStats(List<DaylightStatModel> obj)
        {
            ///< summary >
            /// Loop through < see cref="aryFilter"/> in order to remove unncessary stats stats from <see cref="DaylightStatModel"/> object.
            /// </ summary >

            if (StatFilterDictionary.DictionaryFilter.Count == 0)
            {
                StatFilterDictionary.DictionaryFilter = StatFilterDictionary.GetFilterDictionary();
            }

            for (int i = 0; i < obj[0].PlayerStats.Stats.Count; i++)
            {
                string name = obj[0].PlayerStats.Stats[i].Name;

                if (!StatFilterDictionary.DictionaryFilter.Keys.Contains(name))
                {
                    obj[0].PlayerStats.Stats.Remove(obj[0].PlayerStats.Stats[i]);
                    i--;
                }
                else
                {
                    obj[0].PlayerStats.Stats[i].Name = StatFilterDictionary.DictionaryFilter[name];
                }
            }
            return obj;
        }
    }
}
