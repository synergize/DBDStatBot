using System;
using System.Collections.Generic;
using System.Text;

namespace DBDStatBot.Models
{
    class SteamUserDataModel
    {
        public class Player
        {
            public string SteamId { get; set; }
            public int Communityvisibilitystate { get; set; }
            public int Profilestate { get; set; }
            public string Personaname { get; set; }
            public int Lastlogoff { get; set; }
            public int Commentpermission { get; set; }
            public string Profileurl { get; set; }
            public string Avatar { get; set; }
            public string Avatarmedium { get; set; }
            public string Avatarfull { get; set; }
            public int Personastate { get; set; }
            public string Primaryclanid { get; set; }
            public int Timecreated { get; set; }
            public int Tersonastateflags { get; set; }
        }
        public class Response
        {
            public List<Player> players { get; set; }
        }
        public Response response { get; set; }
    }
}
