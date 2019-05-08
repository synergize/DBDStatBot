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
        private static string _downloadNews = null;
        private string returnData = null;
        public static DaylightStatModel.RootObject PlayerStats(string _steamID)
        {
            using (var web = new WebClient())
            {
                try
                {
                    var _url =
                    string.Format($"http://api.steampowered.com/ISteamUserStats/GetUserStatsForGame/v0002/?appid={StaticDetails.AppID}&key={StaticDetails.SteamAPIKey}&steamid={_steamID}");
                    _downloadNews = web.DownloadString(_url);
                }
                catch (WebException msg)
                {
                    Console.WriteLine("Profile's Game Stats aren't public. Please pick another Steam ID or change the privacy settings in Steam.");
                    return null;
                }
                var result = JsonConvert.DeserializeObject<DaylightStatModel.RootObject>(_downloadNews);
                return JsonConvert.DeserializeObject<DaylightStatModel.RootObject>(_downloadNews);
                //Console.WriteLine(result.PlayerStats.Stats[0].Name);

                //for (int i = 0; i < result.PlayerStats.Stats.Count; ++i)
                //{
                //    var output =
                //        $"{result.PlayerStats.Stats[i].Name}: {result.PlayerStats.Stats[i].Value}";
                //}
            }
        }
    }
}
