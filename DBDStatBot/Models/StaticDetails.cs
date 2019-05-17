using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DBDStatBot.Models
{
    public static class StaticDetails
    {

        ///< summary >
        /// Static class that houses critical token and pathing details that the whole program may need to use.  
        /// </ summary >
        private static string DBDAppID = "381210";
        private static string SteamKey;
        private static string BotKey;
        private static string DataDirectory = Path.Combine(Path.GetFullPath(Directory.GetCurrentDirectory()), "Data");
        private static string DBDStats = @"DBDStats.json";
        private static string TokenFile = @"APITokens.json";
        private static string DboxToken;
        private static string DboxAppkey;
        private static int Error = 0;

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

        public static string DataDirectoryPath
        {
            get { return DataDirectory; }
        }

        public static string DBDStatsFile
        {
            get { return DBDStats; }
        }
        public static string DropboxToken
        {
            get { return DboxToken; }
        }
        public static string DropBoxAppKey
        {
            get { return DboxAppkey; }
        }
        public static string TokenKeyFile
        {
            get { return TokenFile; }
        }
        public static int ErrorCode
        {
            get { return Error; }
            set { Error = value; }
        }
        public static string BuildFilePath(string path, string file)
        {
            return Path.Combine(path, file);
        }
        public static void PopulateKeys()
        {
            TokenModels GetKeys = new TokenModels();
            var Keys = GetKeys.ReadFile();
            SteamKey = Keys.SteamKey;
            BotKey = Keys.DiscordBotKey;
            DboxToken = Keys.DropBoxToken;
            DboxAppkey = Keys.DropBoxAppKey;
        }
    }
}
