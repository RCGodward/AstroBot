using Discord;
using Discord.WebSocket;

namespace AstroBot
{

    internal class Program
    {
        private static DiscordSocketClient _client = new DiscordSocketClient(new DiscordSocketConfig
        {
            GatewayIntents = GatewayIntents.MessageContent | GatewayIntents.AllUnprivileged
        });

        private static readonly PhraseMatcher _phraseMatcher = new PhraseMatcher();

        static async Task Main(string[] args)
        {
            if(args.Length < 1)
            {
                Console.WriteLine("Syntax: AstroBot <DiscordToken>");
                return;
            }

            _client.Log += Log;
            _client.MessageReceived += MessageReceived;
            _client.Ready += _client_Ready;

            var token = args[0];

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private static Task _client_Ready()
        {
            Console.WriteLine("Client ready.");
            return Task.CompletedTask;
        }

        private static async Task MessageReceived(SocketMessage message)
        {
            if (message.Source == MessageSource.User)
            {
                if (_phraseMatcher.IsMatch(message.Content))
                {
                    await message.AddReactionAsync(new Emoji("🖕"));
                    await message.Channel.SendMessageAsync($"Around these parts they're called the Assholes, {message.Author}.");
                }
            }
        }

        private static Task Log(LogMessage message)
        {
            Console.WriteLine(message.ToString());
            return Task.CompletedTask;
        }
    }
}
