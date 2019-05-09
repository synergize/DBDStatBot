using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DBDStatBot.APICall;
using DBDStatBot.MessageBuilder;
using DBDStatBot.Models;
using Discord;

namespace DBDStatBot.Commands
{
    public class DaylightStatsCommand : ModuleBase<SocketCommandContext>
    {
        [Command("dbdstats")]
        public async Task DBDStats(string steamId)
        {   
            var stats = PullPlayerStats.PlayerStats(steamId);

            if (stats != null)
            {
                var BuildOutput = EmbedOutput.BuildDBDStats(stats);
                await Context.Channel.SendMessageAsync("", false, BuildOutput.Build());
            }
            else
            {
                await Context.Channel.SendMessageAsync("", false, EmbedOutput.DBDAPIFailure().Build());
            }
        }
    }
}
