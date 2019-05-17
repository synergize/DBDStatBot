using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DBDStatBot.Models
{
    class TokenModels
    {
        public class Tokens
        {
            public string SteamKey { get; set; }
            public string DiscordBotKey { get; set; }
            public string DropBoxToken { get; set; }
            public string DropBoxAppKey { get; set; }
        }
        public Tokens ReadFile()
        {
            Tokens TokenData = new Tokens();
            var file = File.ReadAllText(StaticDetails.BuildFilePath(StaticDetails.DataDirectoryPath, StaticDetails.TokenKeyFile));
            if (file != "")
            {
                JsonConvert.PopulateObject(file, TokenData);
                return TokenData;

            }
            else
            {
                return null;
            }
        }

    }
}
