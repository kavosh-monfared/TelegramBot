using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace BasicTelegramMassagingBot
{
    class Program
    {
        //insert your telegram API key
        static readonly TelegramBotClient Bot = new TelegramBotClient("-----API key-----");
        static ReplyKeyboardMarkup markup = new ReplyKeyboardMarkup();
        static void Main(string[] args)
        {



            Bot.OnMessage += Bot_OnMessage;
            Bot.OnMessageEdited += Bot_OnMessage;


            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();
        }


        private static void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {

                var msg = e.Message.Text;
                var cid = e.Message.Chat.Id;
                var name = e.Message.From.FirstName +" " + e.Message.From.LastName;
                var uid = e.Message.From.Id;
                var mid = e.Message.MessageId;

            //Anyone who sends a "Hi" message will receive a greeting with their name
            if (e.Message.Type == MessageType.TextMessage)
            {
                    if (msg == "hi" )
                        Bot.SendTextMessageAsync(cid, "Hello " + name);
                    else if (msg == "Hello" )
                        Bot.SendTextMessageAsync(cid, "Hi " + name );

            }

            //Anyone who sends a sticker message will be deleted
            if (e.Message.Type == MessageType.StickerMessage)
            {
                Bot.DeleteMessageAsync(cid, mid);
            }




        }
    }
}
