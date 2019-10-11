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
        public async Task<string> SCreateDBoxClient(DaylightStatModel.Playerstats PlayerData)
        {

            using (var dbox = new DropboxClient(StaticDetails.DropboxToken))
            {
                using (var mem = new MemoryStream(File.ReadAllBytes(StaticDetails.BuildFilePath(StaticDetails.DataDirectoryPath, $"{PlayerData.SteamId}.json"))))
                {
                    try
                    {                                        
                        var UploadFileDbox = dbox.Files.UploadAsync($"/{PlayerData.SteamId}.json", WriteMode.Overwrite.Instance, body: mem);
                        UploadFileDbox.Wait();
                        var DboxListSharedLinks = dbox.Sharing.ListSharedLinksAsync($"/{PlayerData.SteamId}.json");
                        DboxListSharedLinks.Wait();
                        //SharedLinkSettings Settings = new SharedLinkSettings();
                        //Settings.Expires.Value.Add

                        foreach (var current in DboxListSharedLinks.Result.Links)
                        {
                            if (current.Name == $"{PlayerData.SteamId}.json")
                            {
                                return current.Url;
                            }
                        }

                        var DownloadLink = dbox.Sharing.CreateSharedLinkWithSettingsAsync($"/{PlayerData.SteamId}.json");
                        DownloadLink.Wait();
                        return DownloadLink.Result.Url;

                        }
                    
                    catch (Exception msg)
                    {
                        return "Failed to created link";
                    }
                }
            }
        }
    }
}
