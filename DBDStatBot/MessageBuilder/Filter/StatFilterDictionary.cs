using System;
using System.Collections.Generic;
using System.Text;

namespace DBDStatBot.APICall.Filter
{
    static class StatFilterDictionary
    {
        public static Dictionary<string, string> DictionaryFilter = new Dictionary<string, string>();
        public static Dictionary<string, string> GetFilterDictionary()
        {            
            DictionaryFilter.Add("DBD_SkillCheckSuccess", "Successful Skill Checks");
            DictionaryFilter.Add("DBD_Escape", "Successful Escapes");
            DictionaryFilter.Add("DBD_BloodwebPoints", "Total Bloodweb Points");
            DictionaryFilter.Add("DBD_EscapeThroughHatch", "Successful Hatch Escapes");
            DictionaryFilter.Add("DBD_HitNearHook", "Times Hit Near Hooks");
            DictionaryFilter.Add("DBD_HookedAndEscape", "Self Unhooks");

            return DictionaryFilter;
        }

    }
}
