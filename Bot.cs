using System;
using TwitchLib.Api.V5;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Events;

using WindowsInput;
using WindowsInput.Native;

namespace Hypixel_Twitch_Bot
{
    internal class Bot
    {
        ConnectionCredentials credentials = new ConnectionCredentials("ponnic_", "");
        TwitchClient client;

        InputSimulator VirtualInput = new InputSimulator();

        internal void Connect()
        {
            client.Initialize(credentials, "ponnic_");

            client.OnLog += Log;

            client.OnChatCommandReceived += On_Command_Received;
            client.AddChatCommandIdentifier('$');
            client.Connect();
        }

        internal void Disconnect()
        {
            client.Disconnect();
        }

        private void On_Command_Received(object sender, OnChatCommandReceivedArgs command)
        {
            switch (command.Command.CommandText.ToLower())
            {
                case "moveleft":
                    Console.WriteLine("Move Left Ponnic");
                    //VirtualInput.Keyboard.KeyDown(VirtualKeyCode.VK_A);
                    VirtualInput.Keyboard.KeyPress(VirtualKeyCode.VK_A);
                    break;

                case "moveright":
                    Console.WriteLine("Move Right Ponnic");
                    VirtualInput.Keyboard.KeyDown(VirtualKeyCode.VK_D);
                    break;

                case "moveforward":
                    Console.WriteLine("Move Forward Ponnic");
                    VirtualInput.Keyboard.KeyDown(VirtualKeyCode.VK_W);
                    break;

                case "movebackwards":
                    Console.WriteLine("Move Backwards Ponnic");
                    VirtualInput.Keyboard.KeyDown(VirtualKeyCode.VK_S);
                    break;

                case "jump":
                    Console.WriteLine("Jump");
                    VirtualInput.Keyboard.KeyDown(VirtualKeyCode.SPACE);
                    break;

                case "attack":
                    Console.WriteLine("ATTACK");
                    VirtualInput.Mouse.LeftButtonClick();
                    break;

                case "throw":
                    Console.WriteLine("Throw Item");
                    VirtualInput.Keyboard.KeyDown(VirtualKeyCode.VK_Q);
                    break;

                case "sprint":
                    Console.WriteLine("Sprint");
                    VirtualInput.Keyboard.KeyDown(VirtualKeyCode.CONTROL);
                    break;

                case "crouch":
                    Console.WriteLine("Crouch");
                    VirtualInput.Keyboard.KeyDown(VirtualKeyCode.SHIFT);
                    break;

                case "interact":
                    Console.WriteLine("Place Block or fire fireball or whatever");
                    VirtualInput.Mouse.RightButtonClick();
                    break;

                default:
                    client.SendMessage("Ponnic_", "Unkown Command");
                    break;
            }
        }

        private void Log(object sender, OnLogArgs Log)
        {
            Console.WriteLine(Log.Data);
        }
    }
}