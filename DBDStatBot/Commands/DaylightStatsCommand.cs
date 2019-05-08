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
        [Command("stats")]
        public async Task DBDStats(string steamId)
        {   
            List<DaylightStatModel.RootObject> PlayerStats = new List<DaylightStatModel.RootObject>();
            var stats = PullPlayerStats.PlayerStats(steamId);
            if (stats != null)
            {
                await Context.Channel.SendMessageAsync("", false, EmbedOutput.BuildDBDStats(stats).Build());
            }
            else
            {
                await Context.Channel.SendMessageAsync("Profile not public.");
            }
        }
    }
}
