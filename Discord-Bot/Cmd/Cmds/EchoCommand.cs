using System;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace Discord_Bot
{
    public class EchoCommand : ICommand
    {
        public async Task Execute(SocketMessage message, string[] args)
        {
            string? prefix;
            // TODO: Remove naive config checking
            if ((prefix = Environment.GetEnvironmentVariable("PREFIX")) == null)
                throw new ArgumentException("Please set the PREFIX environment variable");
            
            string text = message.Content.Substring(prefix.Length + 4);

            if (text != "")
                await message.Channel.SendMessageAsync(text);
        }
    }
}