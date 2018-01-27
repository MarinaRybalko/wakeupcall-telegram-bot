
using Telegram.Bot.Types;
using Telegram.Bot;

namespace telegram_wakeupcall_bot
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public abstract void ExecuteCommand(Message message,TelegramBotClient my_bot );
        public bool Contains(string command)
        {
            return command.Contains(this.Name);
        }

    }
}