using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DBDStatBot.APICall;
using DBDStatBot.APICall.Dropbox;
using DBDStatBot.FileHelper;
using DBDStatBot.MessageBuilder;
using DBDStatBot.Models;
using Discord;
using DBDStatBot.DateTime_Helper;
using DBDStatBot.APICall.Filter;

namespace DBDStatBot.Commands
{
    public class DaylightStatsCommand : ModuleBase<SocketCommandContext>
    {
        ///< summary >
        /// Command class used for users to acquire their Dead By Daylight stats. 
        /// </ summary >
        [Command("dbdstats")]
        public async Task DBDStats(string steamId)
        {
            PullPlayerStats PullStats = new PullPlayerStats();
            SaveStatsToJson Save = new SaveStatsToJson();
            ReadStatsFiles ReadFiles = new ReadStatsFiles();
            DateTime Time = GetTime.CurrentTime();
            DaylightStatModel.Playerstats PlayerStats = ReadFiles.ReadIndividualPlayerFile(steamId);
            if (PlayerStats == null || Time.AddHours(-24) > PlayerStats.LastUpdated)
            {
                PlayerStats = PullStats.PlayerStats(steamId);
            }
            if (PlayerStats.SteamId != "1")
            {
                //File Write
                AccessDropbox LinkToStatsDownload = new AccessDropbox();
                GetCheckDirectory.CheckDirectory();
                Save.WriteToFile(PlayerStats);
                var BuildOutput = EmbedOutput.BuildDBDStats(PlayerStats, LinkToStatsDownload.SCreateDBoxClient(PlayerStats).Result);
                await Context.Channel.SendMessageAsync("", false, BuildOutput.Build());
            }
            else
            {
                await Context.Channel.SendMessageAsync("", false, EmbedOutput.DBDAPIFailure(PlayerStats.SteamId).Build());
            }
        }
    }
}
