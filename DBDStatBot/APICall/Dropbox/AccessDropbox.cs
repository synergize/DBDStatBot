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
        public async Task CreateDBoxClient()
        {

            using (var dbox = new DropboxClient(StaticDetails.DropboxToken))
            {
                using (var mem = new MemoryStream(File.ReadAllBytes(StaticDetails.BuildFilePath(StaticDetails.DataDirectoryPath, StaticDetails.DBDStatsFile))))
                {
                    try
                    {
                        var testing = dbox.Files.UploadAsync($"/{StaticDetails.DBDStatsFile}", WriteMode.Overwrite.Instance, body: mem);
                        testing.Wait();
                        //SharedLinkSettings Settings = new SharedLinkSettings();
                        //Settings.Expires.Value.Add
                        var DownloadLink = dbox.Sharing.CreateSharedLinkWithSettingsAsync($"/{StaticDetails.DBDStatsFile}", Settings);
                        var x = dbox.Sharing.ListSharedLinksAsync($"/{StaticDetails.DBDStatsFile}");
                        x.Wait();
                        
                        var t = DownloadLink.Result;
                        var url = DownloadLink.Result.Url;
                        Console.WriteLine(url);
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
