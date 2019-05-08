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
            DBDStatsOutput.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");
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

        public static EmbedBuilder DBDHelpInfo()
        {
            EmbedBuilder DBDHelp = new EmbedBuilder();
            DBDHelp.Title = "Useful Information";
            DBDHelp.WithColor(4124426);
            DBDHelp.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");
            DBDHelp.WithDescription("This bot allows for users to look up their stats in Dead by Daylight. Steam ID must be steamID64. ");
            DBDHelp.AddField("Stats: ", "!stats <SteamID>", true);
            DBDHelp.AddField("Steam ID Lookup: ", "https://steamid.io/", true);

            return DBDHelp;
        }
    }
}
