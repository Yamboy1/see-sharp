namespace Discord_Bot.Db
{
    public class UserGuild
    {
        public ulong UserId { get; set; }
        public User User { get; set; }
        
        public ulong GuildId { get; set; }
        public Guild Guild { get; set; }
    }
}