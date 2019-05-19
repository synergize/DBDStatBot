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

            if (StatFilterDictionary.DictionaryFilter.Count == 0)
            {
                StatFilterDictionary.DictionaryFilter = StatFilterDictionary.GetFilterDictionary();
            }

            for (int i = 0; i < obj.Stats.Count; i++)
            {
                string name = obj.Stats[i].Name;

                if (!StatFilterDictionary.DictionaryFilter.Keys.Contains(name))
                {
                    obj.Stats.Remove(obj.Stats[i]);
                    i--;
                }
                else
                {
                    obj.Stats[i].Name = StatFilterDictionary.DictionaryFilter[name];
                }
            }
            return obj;
        }
    }
}
