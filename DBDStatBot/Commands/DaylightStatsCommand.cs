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
            var stats = PullPlayerStats.PlayerStats(steamId);

            if (stats != null)
            {
                //File Write
                GetCheckDirectory.CheckDirectory(StaticDetails.DataDirectoryPath);
                SaveStatsToJson.WriteToFile(stats[0]);

                AccessDropbox LinkToStatsDownload = new AccessDropbox();
                var BuildOutput = EmbedOutput.BuildDBDStats(stats, LinkToStatsDownload.SCreateDBoxClient(stats).Result);
                await Context.Channel.SendMessageAsync("", false, BuildOutput.Build());
            }
            else
            {
                await Context.Channel.SendMessageAsync("", false, EmbedOutput.DBDAPIFailure().Build());
            }
        }
    }
}
