using System;
using System.Collections.Generic;

namespace Discord_Bot.Db
{
    public partial class User
    {
        public ulong UserId { get; set; }
        public DateTime Birthday { get; set; }
        
        public List<UserGuild> UserGuilds { get; set; }
    }
}
