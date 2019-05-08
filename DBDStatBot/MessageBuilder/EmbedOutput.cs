using DBDStatBot.Models;
using Discord.Commands;
using System;
using Discord;
using System.Threading.Tasks;

namespace DBDStatBot.MessageBuilder
{
    public class EmbedOutput : ModuleBase<SocketCommandContext>
    {
        public static EmbedBuilder BuildDBDStats(DaylightStatModel.RootObject obj)
        {
            EmbedBuilder DBDStatsOutput = new EmbedBuilder();
            DBDStatsOutput.Title = "Your Stats!";
            //DBDStatsOutput.WithAuthor("Stats", Context.User.GetAvatarUrl());
            DBDStatsOutput.WithFooter("Contact Coaction#5994 for any issues");
            DBDStatsOutput.WithDescription(
                $"Place holder description. \n [This is a hyperlink](https://discordapp.com/developers)");
            DBDStatsOutput.WithColor(4124426);
            foreach (var x in obj.PlayerStats.Stats)
            {
                if (DBDStatsOutput.Fields.Count >= 25)
                {
                    break;
                }
                DBDStatsOutput.AddField(x.Name.ToString(), x.Value, false);
            }
            return DBDStatsOutput;
        }
    }
}
