using SimpleSecureChatAPI.Client;
using System;

namespace SimpleSecureChatClient
{
    public class Client
    {
        private CallbackClient _client;

        private static readonly string _configPath = "config.json";
        public static Config Config { get; private set; }

        static void Main(string[] args)
        {
            Config = Config.Load(_configPath);
        }
    }
}
