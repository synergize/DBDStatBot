using System;
using System.Collections.Generic;
using System.Text;

namespace DBDStatBot.Models
{
    public class DaylightStatModel
    {
        ///< summary >
        /// Data model used to pull in Dead by Daylight stats from Steam API.
        /// </ summary >

        public class Stat
        {
            public string Name { get; set; }
            public double Value { get; set; }
        }

        public class Playerstats
        {
            public string SteamId { get; set; }
            public string GameName { get; set; }
            public List<Stat> Stats { get; set; }
        }
        //DaylightStatModel
        public Playerstats PlayerStats { get; set; }
    }
}
