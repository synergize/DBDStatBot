using System;
using System.Collections.Generic;
using System.Text;

namespace DBDStatBot.Models
{
    class SteamUserDataModel
    {
        public class Player
        {
            public string Personaname { get; set; }
        }
        public class Response
        {
            public List<Player> players { get; set; }
        }
        public Response response { get; set; }
        public SteamUserGameInformationModel.Game Game { get; set; }
    }
}
