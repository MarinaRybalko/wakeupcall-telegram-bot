using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace telegram_wakeupcall_bot
{
    class Program
    {

       
        static void Main(string[] args)
        {

            TelegramBotClient bot = new TelegramBotClient("505079072:AAHjzsdNQllfq8SpMcjKRxdad639Mu5f8Jo");
            Telegram. Execute(bot);
            Console.ReadKey();
        }
      
    }
}
