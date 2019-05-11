using DBDStatBot.Models;
using Discord.Commands;
using System;
using Discord;
using System.Threading.Tasks;
using System.Collections.Generic;
using DBDStatBot.APICall.Filter;

namespace DBDStatBot.MessageBuilder
{
    public class EmbedOutput : ModuleBase<SocketCommandContext>
    {
        ///< summary >
        /// Class built to house any output the bot may need to distribute. We do this by using the EmbedBuilder from Discord. 
        /// </ summary >
        public static EmbedBuilder BuildDBDStats(List<DaylightStatModel> obj)  
        {
            RemoveFilteredItems.RemoveUselessStats(obj);

            EmbedBuilder DBDStatsOutput = new EmbedBuilder();
            DBDStatsOutput.Title = "Your Stats!!!";
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
            DBDHelp.AddField("Stats: ", "!dbdstats <SteamID>", true);
            DBDHelp.AddField("Steam ID Lookup: ", "https://steamid.io/", true);
            return DBDHelp;
        }
        public static EmbedBuilder DBDAPIFailure()
        {
            EmbedBuilder DBDFail = new EmbedBuilder();
            DBDFail.Title = "Stat Lookup Failed.";
            DBDFail.WithColor(16580608);
            DBDFail.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");
            DBDFail.AddField("Profile Settings: ", "Make sure \"My Profile\" and \"Game Details\" are set to Public within Steam's privacy settings.", true);
            DBDFail.AddField("Time To Update: ", "Steam can take time to update your privacy settings. Give 10-15 minutes before trying again.", true);

            return DBDFail;
        }
    }
}
