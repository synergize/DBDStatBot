using System;
using System.Collections.Generic;
using System.Text;

namespace DBDStatBot.Models
{
    public class SteamUserGameInformationModel
    {
        public class Game
        {
            public int appid { get; set; }
            public int playtime_forever { get; set; }
        }

        public class Response
        {
            public int game_count { get; set; }
            public List<Game> games { get; set; }
        }

        public Response response { get; set; }

    }
}
