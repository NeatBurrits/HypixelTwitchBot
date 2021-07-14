using System;

namespace Hypixel_Twitch_Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            Bot ChatBot = new Bot();
            ChatBot.Connect();

            Console.ReadLine();

            ChatBot.Disconnect();
        }
    }
}
