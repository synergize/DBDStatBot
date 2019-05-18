using DBDStatBot.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DBDStatBot.APICall
{
    class PullPlayerStats
    {
        private string _downloadNews = null;
        //private static List<DaylightStatModel> ListOfPlayers = new List<DaylightStatModel>(); //Uncomment to maintain list between classes. Doesn't re-up when being accessed. 
        private List<DaylightStatModel> ListOfPlayers = new List<DaylightStatModel>();
        ///< summary >
        /// API Call to Steam's API and storing the call within the < see cref = "DaylightStatModel" /> data model.
        /// </ summary >
        /// 
        public DaylightStatModel PlayerStats(string _steamID)
        {
            using (var web = new WebClient())
            {
                try
                {
                    var _url =
                    string.Format($"http://api.steampowered.com/ISteamUserStats/GetUserStatsForGame/v0002/?appid={StaticDetails.AppID}&key={StaticDetails.SteamAPIKey}&steamid={_steamID}&format=json");
                    _downloadNews = web.DownloadString(_url);
                }
                catch (WebException msg)
                {
                    StaticDetails.ErrorCode = 1;
                    Console.WriteLine(msg);
                    return null;
                }

                //Store downloaded stats into memory. 
                var DownloadedStats = JsonConvert.DeserializeObject<DaylightStatModel>(_downloadNews);
                //ListOfPlayers.Add(DownloadedStats);                
                DownloadedStats.PlayerStats.LastUpdated = DateTime.UtcNow;

                return DownloadedStats;
            }
        }
    }
}
