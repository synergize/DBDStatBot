using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DBDStatBot.MessageBuilder;
using Discord;

namespace DBDStatBot.Commands
{
    public class DaylightHelpCommand : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task DBDHelp()
        {
            await Context.Channel.SendMessageAsync("", false, EmbedOutput.DBDHelpInfo().Build());
        }
    }
}
