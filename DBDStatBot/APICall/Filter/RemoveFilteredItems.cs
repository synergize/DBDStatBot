using DBDStatBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBDStatBot.APICall.Filter
{
   public static class RemoveFilteredItems
    {
        public static DaylightStatModel RemoveUselessStats(List<DaylightStatModel> obj)
        {
            ///< summary >
            /// Loop through < see cref = "StatFilterEnum" /> in order to remove unncessary stats stats from <see cref="DaylightStatModel"/> object.
            /// </ summary >
            foreach (StatFilterEnum StatFilter in (StatFilterEnum[])Enum.GetValues(typeof(StatFilterEnum)))
            {
                for (int i = 0; i < obj[0].PlayerStats.Stats.Count; i++)
                {
                    if (obj.PlayerStats.Stats[i].Name == StatFilter.ToString())
                    {
                        obj.PlayerStats.Stats.Remove(obj.PlayerStats.Stats[i]);
                        break;
                    }
                }
            }
            return obj;
        }
    }
}
