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
        public async Task<string> SCreateDBoxClient(DaylightStatModel PlayerData)
        {

            using (var dbox = new DropboxClient(StaticDetails.DropboxToken))
            {
                using (var mem = new MemoryStream(File.ReadAllBytes(StaticDetails.BuildFilePath(StaticDetails.DataDirectoryPath, $"{PlayerData.PlayerStats.SteamId}.json"))))
                {
                    try
                    {                                        
                        var UploadFileDbox = dbox.Files.UploadAsync($"/{PlayerData.PlayerStats.SteamId}.json", WriteMode.Overwrite.Instance, body: mem);
                        UploadFileDbox.Wait();
                        var DboxListSharedLinks = dbox.Sharing.ListSharedLinksAsync($"/{PlayerData.PlayerStats.SteamId}.json");
                        DboxListSharedLinks.Wait();
                        //SharedLinkSettings Settings = new SharedLinkSettings();
                        //Settings.Expires.Value.Add

                        foreach (var current in DboxListSharedLinks.Result.Links)
                        {
                            if (current.Name == $"{PlayerData.PlayerStats.SteamId}.json")
                            {
                                return current.Url;
                            }
                        }
                        var DownloadLink = dbox.Sharing.CreateSharedLinkWithSettingsAsync($"/{PlayerData.PlayerStats.SteamId}.json");
                        DownloadLink.Wait();
                        return DownloadLink.Result.Url;
                        }
                    
                    catch (Exception msg)
                    {
                        StaticDetails.ErrorCode = 2;
                        Console.WriteLine(msg);
                        throw;
                    }
                }
            }
        }
    }
}
