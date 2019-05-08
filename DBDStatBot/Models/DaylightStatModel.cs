using System;
using System.Collections.Generic;
using System.Text;

namespace DBDStatBot.Models
{
    public class DaylightStatModel
    {
        public class Stat
        {
            public string Name { get; set; }
            public double Value { get; set; }
        }

        public class Achievement
        {
            public string Name { get; set; }
            public int Achieved { get; set; }
        }

        public class Playerstats
        {
            public string SteamId { get; set; }
            public string GameName { get; set; }
            public List<Stat> Stats { get; set; }
            public List<Achievement> Achievements { get; set; }
        }

        public class RootObject
        {
            public Playerstats PlayerStats { get; set; }
        }
    }
}
