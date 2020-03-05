using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace Discord_Bot
{
    class Program
    {
        private readonly DiscordSocketClient _client;
        
        static void Main(string[] args)
        {
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public Program()
        {
            _client = new DiscordSocketClient();

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

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(SocketMessage message)
        {
            if (message.Author.IsBot)
                return;

            string? prefix;
            // TODO: Remove naive config checking
            if ((prefix = Environment.GetEnvironmentVariable("PREFIX")) == null)
                throw new ArgumentException("Please set the PREFIX environment variable");
            
            await CommandFactory.ParseAndRunCommand(prefix, message);
        }
    }
}