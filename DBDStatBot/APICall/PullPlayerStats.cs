using DBDStatBot.DateTime_Helper;
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
        ///< summary >
        /// API Call to Steam's API and storing the call within the < see cref = "DaylightStatModel" /> data model.
        /// </ summary >
        /// 
        public DaylightStatModel.Playerstats PlayerStats(string _steamID)
        {
            DaylightStatModel.Playerstats obj = new DaylightStatModel.Playerstats();
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
                    obj.SteamId = "1";
                    return obj;
                }
                //Store downloaded stats into memory. 
                var DownloadedStats = JsonConvert.DeserializeObject<DaylightStatModel>(_downloadNews);
                obj = DownloadedStats.PlayerStats;     
                obj.LastUpdated = GetTime.CurrentTime();

                return obj;
            }
        }
    }
}
