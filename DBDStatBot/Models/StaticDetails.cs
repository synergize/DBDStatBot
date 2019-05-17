using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Text;

namespace DBDStatBot.Models
{
    public static class StaticDetails
    {

        ///< summary >
        /// Static class that houses critical token and pathing details that the whole program may need to use.  
        /// </ summary >
        private static string DBDAppID = "381210";
        private static string SteamKey = "38385657BDA9CD55FF7A3647BD16FAE5";
        private static string BotKey = "NTc1NTkzODgwNDE0NTg0ODQx.XNKNmw.uUAQ9vUtAiSYCjAA41F-NkBxBLs";
        private static string DataDirectory = Path.Combine(Path.GetFullPath(Directory.GetCurrentDirectory()), "Data");
        private static string DBDStats = @"DBDStats.json";
        private static string DboxToken = "HzH-CiskL7gAAAAAAAACm3BOniHcP8YtthEvEgQ3jN9ZX54fm9qqDA37k4NzxLYz";
        private static string DboxAppkey = "vq2h4kiom4plzsi";
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
        public static int ErrorCode
        {
            get { return Error; }
            set { Error = value; }
        }
        public static string BuildFilePath(string path, string file)
        {
            return Path.Combine(path, file);
        }
    }
}
