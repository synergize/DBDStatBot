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
        public static EmbedBuilder BuildDBDStats(DaylightStatModel.Playerstats obj, string url)  
        {
            RemoveFilteredItems FilterItems = new RemoveFilteredItems();
            FilterItems.RemoveUselessStats(obj);

            EmbedBuilder DBDStatsOutput = new EmbedBuilder();
            DBDStatsOutput.Title = "Interesting DBD Stats.";
            DBDStatsOutput.WithFooter($"Stats last updated {obj.LastUpdated} UTC");
            DBDStatsOutput.WithDescription(
                $"Download the rest of your stats [HERE]({url})!");
            DBDStatsOutput.WithColor(4124426);
            foreach (var x in obj.Stats)
            {
                DBDStatsOutput.AddField(x.Name, String.Format("{0:n0}", x.Value), true);
            }
            return DBDStatsOutput;
        }

        public static EmbedBuilder DBDHelpInfo()
        {
            EmbedBuilder DBDHelp = new EmbedBuilder();
            DBDHelp.Title = "Useful Information";
            DBDHelp.WithColor(4124426);
            DBDHelp.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");
            DBDHelp.WithDescription("This bot allows for users to look up their stats in Dead by Daylight. Steam ID must be steamID64.");
            DBDHelp.AddField("Stats: ", "!dbdstats <SteamID>", true);
            DBDHelp.AddField("Steam ID Lookup: ", "https://steamid.io/", true);
            return DBDHelp;
        }
        public static EmbedBuilder DBDAPIFailure(int num)
        {
            switch (num)
            {
                case 1:
                    return DBDSteamAPIFail();
                case 2:
                    return DBDLinkCreationFail();
            }
            return GenericError();
        }
        private static EmbedBuilder DBDSteamAPIFail()
        {
            EmbedBuilder DBDSteamAPIFail = new EmbedBuilder();
            DBDSteamAPIFail.Title = "Stat Lookup Failed.";
            DBDSteamAPIFail.WithColor(16580608);
            DBDSteamAPIFail.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");
            DBDSteamAPIFail.AddField("Profile Settings: ", "Make sure \"My Profile\" and \"Game Details\" are set to Public within Steam's privacy settings.", true);
            DBDSteamAPIFail.AddField("Time To Update: ", "Steam can take time to update your privacy settings. Give 10-15 minutes before trying again.", true);

            return DBDSteamAPIFail;
        }

        private static EmbedBuilder DBDLinkCreationFail()
        {
            EmbedBuilder DBDLinkCreationFail = new EmbedBuilder();
            DBDLinkCreationFail.Title = "Stat Lookup Failed.";
            DBDLinkCreationFail.WithColor(16580608);
            DBDLinkCreationFail.WithFooter("URL Failure");
            DBDLinkCreationFail.AddField("Connection Failed: ", "Connection to download stats file failed. Please try again.");

            return DBDLinkCreationFail;
        }
        private static EmbedBuilder GenericError()
        {
            EmbedBuilder GenericError = new EmbedBuilder();
            GenericError.Title = "Stat Lookup Failed.";
            GenericError.WithColor(16580608);
            GenericError.AddField("Error", "An error has occured. Please contact Coaction");

            return GenericError;
        }

    }
}
