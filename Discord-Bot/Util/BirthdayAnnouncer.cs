using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord_Bot.Db;
using Microsoft.EntityFrameworkCore;

namespace Discord_Bot.Util
{
    public class BirthdayAnnouncer
    {
        private readonly DiscordSocketClient _client;
        private readonly BdayBotContext _db;

        public BirthdayAnnouncer(DiscordSocketClient client, BdayBotContext db)
        {
            _client = client;
            _db = db;
        }

        public async Task Announce(DateTime date)
        {
            List<User> users = _db.User
                .Include(u => u.UserGuilds)
                .ThenInclude(ug => ug.Guild)
                .Where(user => user.Birthday == date)
                .ToList();

            foreach (User user in users)
            {
                await ReloadUserGuilds(user);

                IEnumerable<Guild> guilds = user.UserGuilds
                    .Select(userGuild => userGuild.Guild);
                
                foreach (Guild guild in guilds)
                {
                    if (!(_client.GetChannel(guild.AnnouncementChannel) is IMessageChannel channel)) continue;

                    var footer = new EmbedFooterBuilder()
                        .WithText("Service provided by Bday-Bot")
                        .WithIconUrl(_client.CurrentUser.GetDefaultAvatarUrl());

                    var embed = new EmbedBuilder()
                        .WithTitle("Happy Birthday")
                        .WithDescription($"It's <@{user.UserId}>'s birthday today. Wish them well on this special day!")
                        .WithColor(new Color(0xFFA4FF))
                        .WithFooter(footer)
                        .WithCurrentTimestamp()
                        .Build();

                    await channel.SendMessageAsync(null, false, embed);
                }
            }
        }

        private async Task ReloadUserGuilds(User user)
        {
            IEnumerable<ulong> guildIds =
                _client.Guilds
                    .Where(guild => guild.Users.Any(u => u.Id == user.UserId))
                    .Select(guild => guild.Id)
                    .Intersect(_db.Guild.Select(g => g.GuildId))
                    .Except(user.UserGuilds.Select(ug => ug.GuildId));

            foreach (ulong guildId in guildIds)
            {
                user.UserGuilds.Add(new UserGuild
                {
                    GuildId = guildId,
                    UserId = user.UserId
                });
            }

            await _db.SaveChangesAsync();
        }
    }
}