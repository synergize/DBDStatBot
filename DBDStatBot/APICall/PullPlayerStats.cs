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
        public static DaylightStatModel PlayerStats(string _steamID)
        {
            //List<DaylightStatModel.Stat> StatsList = new List<DaylightStatModel.Stat>();

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
                    Console.WriteLine(msg);
                    return null;
                }

                //Store downloaded stats into memory. 
                var DownloadedStats = JsonConvert.DeserializeObject<DaylightStatModel>(_downloadNews);
                try
                {
                    
 

                        //DownloadedStats.PlayerStats.Stats.Add(x);
                        ///< summary >
                        /// Loop through < see cref = "StatFilterEnum" /> in order to remove unncessary stats from the list. 
                        /// </ summary >
                        foreach (StatFilterEnum StatFilter in (StatFilterEnum[]) Enum.GetValues(typeof(StatFilterEnum)))
                        {
                            for (int i = 0; i < DownloadedStats.PlayerStats.Stats.Count; i++)
                            {
                                if (DownloadedStats.PlayerStats.Stats[i].Name == StatFilter.ToString())
                                {
                                    DownloadedStats.PlayerStats.Stats.Remove(DownloadedStats.PlayerStats.Stats[i]);
                                    break;
                                }
                            }
                        }



                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                //Loop through the stats and add them into a List so that we can modify if necessary. 
                return DownloadedStats;
            }
        }
    }
}
