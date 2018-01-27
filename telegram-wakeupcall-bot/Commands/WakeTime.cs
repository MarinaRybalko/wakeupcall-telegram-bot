using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Threading;

namespace telegram_wakeupcall_bot
{
    class WakeTime : Command
    {
        public override string Name =>"/waketime";

        public override  void ExecuteCommand(Message message, TelegramBotClient my_bot)
        {
            try
            {
                
                    int[] time = (message.Text).Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToArray();
                var messageTime = DateTime.Now;

             
                    DateTime wakeuptime = new DateTime(time[0], time[1], time[2], time[3], time[4], time[5]);
                for(int i=0;i<time.Length;i++)
                Console.WriteLine(time[i]);
                    var timeTosleep = wakeuptime - messageTime;
                Console.WriteLine(timeTosleep);
                Console.WriteLine(messageTime);
                    if (messageTime < wakeuptime)
                    {
                   my_bot.SendTextMessageAsync(message.Chat.Id, "I'll wake you up at " + wakeuptime.Hour +" : "+wakeuptime.Minute+" : "+wakeuptime.Second);
                    Task.Delay(timeTosleep).Wait();
                       my_bot.SendTextMessageAsync(message.Chat.Id, "Wake up, my fluffy cat ^_^");
                    }
                    else
                    {
                       my_bot.SendTextMessageAsync(message.Chat.Id, "Uncorrect data, this date has already passed");
                    }
            
            }
         catch(Exception)
            {
                 my_bot.SendTextMessageAsync(message.Chat.Id, "Uncorrect data, please enter again /waketime and define wake up time again");
                
            }
           
        }
    }
}
