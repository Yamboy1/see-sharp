using System;
using System.Globalization;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord_Bot.Db;
using Discord_Bot.Util;

namespace Discord_Bot
{
    class Program
    {
        private readonly DiscordSocketClient _client;
        private readonly BdayBotContext _db;
        
        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        public Program()
        {
            _client = new DiscordSocketClient();
            _db = new BdayBotContext();

            _client.Log += LogAsync;
            _client.Ready += ReadyAsync;
            _client.MessageReceived += MessageReceivedAsync;
        }

        public async Task MainAsync()
        {
            
            string? token;
            // TODO: Remove naive config checking
            if ((token = Environment.GetEnvironmentVariable("TOKEN")) == null)
                throw new ArgumentException("Please set the TOKEN environment variable");
            
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            
            return Task.CompletedTask;
        }

        private Task ReadyAsync()
        {
            Console.WriteLine($"Logged in as {_client.CurrentUser}");

            var announcer = new BirthdayAnnouncer(_client, _db);

            Task.Run(async () =>
            {
                while (true)
                {
                    DateTime tomorrow = DateTime.UtcNow.Date.AddDays(1);
                    TimeSpan span = tomorrow - DateTime.UtcNow;
                    Console.WriteLine(span);
                    if (span.TotalMilliseconds >= 0)
                    {
                        await Task.Delay(span);

                        await announcer.Announce(tomorrow);
                    }
                }
            });

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(SocketMessage message)
        {
            if (message.Author.IsBot)
                return;

            foreach (User user in _db.User)
            {
                Console.WriteLine(user.UserId + ": " + user.Birthday);
            }
            
            string? prefix;
            // TODO: Remove naive config checking
            if ((prefix = Environment.GetEnvironmentVariable("PREFIX")) == null)
                throw new ArgumentException("Please set the PREFIX environment variable");
            
            await CommandFactory.ParseAndRunCommand(prefix, message);
        }
    }
}