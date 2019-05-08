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
        public static void PlayerStats()
        {
            using (var web = new WebClient())
            {
                try
                {
                    var _url =
                    string.Format($"http://api.steampowered.com/ISteamUserStats/GetUserStatsForGame/v0002/?appid={_appID}&key={_steamKey}&steamid={_steamID}");
                    _downloadNews = web.DownloadString(_url);
                }
                catch (WebException msg)
                {
                    Console.WriteLine("Profile's Game Stats aren't public. Please pick another Steam ID or change the privacy settings in Steam.");
                }
                var result = JsonConvert.DeserializeObject<DaylightStatModel.RootObject>(_downloadNews);
                Console.WriteLine(result.playerstats.stats[0].name);

                for (int i = 0; i < result.playerstats.stats.Count; ++i)
                {
                    var output =
                        $"{result.playerstats.stats[i].name}: {result.playerstats.stats[i].value}";
                    Console.WriteLine(output);
                }
            }
        }
    }
}
