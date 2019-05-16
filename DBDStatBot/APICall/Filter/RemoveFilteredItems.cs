using DBDStatBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discord;

namespace DBDStatBot.APICall.Filter
{
   public static class RemoveFilteredItems
    {
        public static List<DaylightStatModel> RemoveUselessStats(List<DaylightStatModel> obj)
        {
            ///< summary >
            /// Loop through < see cref="aryFilter"/> in order to remove unncessary stats stats from <see cref="DaylightStatModel"/> object.
            /// </ summary >

            Dictionary<string, string> DictionaryFilter = new Dictionary<string, string>();
            DictionaryFilter.Add("DBD_SkillCheckSuccess", "Successful Skill Checks");
            DictionaryFilter.Add("DBD_Escape", "Successful Escapes");
            DictionaryFilter.Add("DBD_BloodwebPoints", "Total Bloodweb Points");
            DictionaryFilter.Add("DBD_EscapeThroughHatch", "Successful Hatch Escapes");
            DictionaryFilter.Add("DBD_HitNearHook", "Times Hit Near Hooks");
            DictionaryFilter.Add("DBD_HookedAndEscape", "Self Unhooks");

            for (int i = 0; i < obj[0].PlayerStats.Stats.Count; i++)
            {
                string name = obj[0].PlayerStats.Stats[i].Name;

                if (!DictionaryFilter.Keys.Contains(name))
                {
                    obj[0].PlayerStats.Stats.Remove(obj[0].PlayerStats.Stats[i]);
                    i--;
                }
                else
                {
                    obj[0].PlayerStats.Stats[i].Name = DictionaryFilter[name];
                }
            }
            return obj;
        }
    }
}
