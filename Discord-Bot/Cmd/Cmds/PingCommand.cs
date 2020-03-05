using System.Threading.Tasks;
using Discord.WebSocket;

namespace Discord_Bot
{
    public class PingCommand : ICommand
    {
        public async Task Execute(SocketMessage message, string[] args)
        {
            await message.Channel.SendMessageAsync("Pong!");
        }
    }
}