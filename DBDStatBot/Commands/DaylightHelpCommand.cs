using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DBDStatBot.MessageBuilder;
using Discord;
using DBDStatBot.APICall.Dropbox;

namespace DBDStatBot.Commands
{
    public class DaylightHelpCommand : ModuleBase<SocketCommandContext>
    {
        [Command("dbdhelp")]
        public async Task DBDHelp()
        {
            //await Context.Channel.SendMessageAsync("", false, EmbedOutput.DBDHelpInfo().Build());
            AccessDropbox Test = new AccessDropbox();
            Test.CreateDBoxClient();
        }
    }
}
