using DBDStatBot.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DBDStatBot.APICall
{
    class PullSteamUserData
    {
        private string _downloadNews = null;

        ///< summary >
        /// API Call to Steam's API and storing the call within the < see cref = "SteamAPIStatsModel" /> data model.
        /// </ summary >
        /// 
        public SteamUserDataModel UserSummary(string _steamID)
        {
            SteamUserDataModel PlayerSummary = new SteamUserDataModel();
            using (var web = new WebClient())
            {
                try
                {
                    var _url =
                    string.Format($"http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key={StaticDetails.SteamAPIKey}&steamids={_steamID}&format=json");
                    _downloadNews = web.DownloadString(_url);
                }
                catch (WebException msg)
                {
                    Console.WriteLine(msg);
                    return null;
                }

                //Store downloaded summary into memory. 
                PlayerSummary = JsonConvert.DeserializeObject<SteamUserDataModel>(_downloadNews);
                return PlayerSummary;
            }
        }
    }
}
