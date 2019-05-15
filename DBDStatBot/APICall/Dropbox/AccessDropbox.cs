using DBDStatBot.Models;
using Dropbox.Api;
using Dropbox.Api.Files;
using Dropbox.Api.Sharing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DBDStatBot.APICall.Dropbox
{
    public class AccessDropbox
    {
        public async Task<string> SCreateDBoxClient(List<DaylightStatModel> PlayerData)
        {

            using (var dbox = new DropboxClient(StaticDetails.DropboxToken))
            {
                using (var mem = new MemoryStream(File.ReadAllBytes(StaticDetails.BuildFilePath(StaticDetails.DataDirectoryPath, StaticDetails.DBDStatsFile))))
                {
                    try
                    {

                        var UploadFileDbox = dbox.Files.UploadAsync($"/{PlayerData[0].PlayerStats.SteamId}.json", WriteMode.Overwrite.Instance, body: mem);
                        var DboxListSharedLinks = dbox.Sharing.ListSharedLinksAsync($"/{PlayerData[0].PlayerStats.SteamId}.json");

                        UploadFileDbox.Wait();
                        //SharedLinkSettings Settings = new SharedLinkSettings();
                        //Settings.Expires.Value.Add
                        DboxListSharedLinks.Wait();

                        foreach (var current in DboxListSharedLinks.Result.Links)
                        {
                            if (current.Name == $"{PlayerData[0].PlayerStats.SteamId}.json")
                            {
                                return current.Url;
                            }
                        }
                        var DownloadLink = dbox.Sharing.CreateSharedLinkWithSettingsAsync($"/{PlayerData[0].PlayerStats.SteamId}.json");
                        DownloadLink.Wait();
                        return DownloadLink.Result.Url;

                    }
                    catch (Exception msg)
                    {
                        Console.WriteLine(msg);
                        throw;
                    }
                }
            }
        }
    }
}
