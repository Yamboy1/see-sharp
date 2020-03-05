using System.Threading.Tasks;
using Discord.WebSocket;

namespace Discord_Bot
{
    public interface ICommand
    {
        public Task Execute(SocketMessage message, string[] args);
    }
}