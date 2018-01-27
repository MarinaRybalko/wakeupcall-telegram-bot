using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using telegram_wakeupcall_bot.Commands;
namespace telegram_wakeupcall_bot
{
    public static class Telegram
    {
       static List<Command> commands= new List< Command>();
        static List<string> phrases = new List<string>();
        static int  offset = 0;
    
        async  static public void Execute(TelegramBotClient my_bot)
        {
          
            commands.Add(new WakeUpMessage());
            commands.Add(new HelloCommand());
            await my_bot.SetWebhookAsync("");
            bool flag = false;
            while (true)
            {

               
                var updates = await my_bot.GetUpdatesAsync(offset);

                foreach (var update in updates)
                {
                    Console.WriteLine(update.ToString());
                    var message = update.Message;
                    Console.WriteLine( message);
                    if (message?.Type == MessageType.TextMessage && message.Text !="" )
                    {
                        foreach(var command in commands)
                        {
                            Console.WriteLine(command.Name);
                            if (message.Text=="/waketime")
                            {

                                Update [] settimeUpdate;
                                do
                                { settimeUpdate = await my_bot.GetUpdatesAsync(offset);
                                    Thread.Sleep(1000);
                                } while ((settimeUpdate.Last()).Message.Text == "/waketime");
                                flag = true;
                                Console.WriteLine((settimeUpdate.Last()).Message.Text );
                                

                                    await Task.Run(() => new WakeTime().ExecuteCommand((settimeUpdate.Last()).Message,my_bot));
                                    break;
                                   
                               

                            }
                            else if (command.Contains(message.Text) )
                            {
                               
                                flag = true;
                               await Task.Run( ()=>command.ExecuteCommand(message,my_bot));
                                break;
                            }                     
                            else if(!flag)
                            {
                                Console.WriteLine(phrases.Contains((updates.Last().Message.Text)));
                                Console.WriteLine(updates.Last().Message.Text);
                                await my_bot.SendTextMessageAsync(message.Chat.Id, "Sorry, I don't know this command. Please choose another command");
                            

                            }
                        }
                        
                    }

                    offset = update.Id + 1;
                }
               
            }
        }
    }
}
