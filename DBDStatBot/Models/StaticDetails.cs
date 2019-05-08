using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace DBDStatBot.Models
{
    public static class StaticDetails
    {

        //test 3
        private static string DBDAppID = "381210";
        private static string SteamKey = "38385657BDA9CD55FF7A3647BD16FAE5";
        private static string BotKey = "NTc1NTkzODgwNDE0NTg0ODQx.XNKNmw.uUAQ9vUtAiSYCjAA41F-NkBxBLs";

        public static string AppID
        {
            get { return DBDAppID; }
        }

        public static string SteamAPIKey
        {
            get { return SteamKey; }
        }

        public static string DBDBotKey
        {
            get { return BotKey; }
        }
    }
}
