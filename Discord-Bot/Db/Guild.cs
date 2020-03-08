using System;
using System.Collections.Generic;

namespace Discord_Bot.Db
{
    public partial class Guild
    {
        public ulong GuildId { get; set; }
        public ulong AnnouncementChannel { get; set; }
        
        public List<UserGuild> UserGuilds { get; set; }
    }
}
