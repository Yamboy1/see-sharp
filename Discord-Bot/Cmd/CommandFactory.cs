using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace Discord_Bot
{
    public static class CommandFactory
    {
        public static ICommand? GetCommand(string name)
        {
            return name switch
            {
                "ping" => new PingCommand(),
                "echo" => new EchoCommand(),
                _ => null
            };
        }

    public static string[]? ParseArgs(string prefix, string content)
        {
            if (!content.StartsWith(prefix))
                return null;

            string[] args = Regex.Split(content.Substring(prefix.Length), @" +");
            string[] filtered = Array.FindAll(args, str => str != "");

            return filtered.Length > 0 ? filtered : null;
        }

        public static async Task ParseAndRunCommand(string prefix, SocketMessage message)
        {
            string[]? args = ParseArgs(prefix, message.Content);
            if (args == null) return;

            ICommand? command = GetCommand(args[0]);
            if (command == null) return;

            await command.Execute(message, args);
        }
    }
}