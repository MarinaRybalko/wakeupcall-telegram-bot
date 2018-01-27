using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace telegram_wakeupcall_bot
{
    public class WakeUpMessage : Command
    {
       
        
        public override string Name => "/wakeup";


        public override async void ExecuteCommand(Message message, TelegramBotClient my_bot)
        {
         
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            await my_bot.SendTextMessageAsync(chatId, "Please enter command /waketime and enter time when you want to be woken up using this format 2018 01 26 17 12 12 {yyy mm dd hh mm ss}");
        
          
        }
    }
}