using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Drawing;


namespace telegram_wakeupcall_bot.Commands
{
    class HelloCommand : Command
    {
        public override string Name => "/hello";
        readonly FileToSend[] hellostikers = new FileToSend[]
        {
            new FileToSend (@"https://ae01.alicdn.com/kf/HTB11aHvIVXXXXchXXXXq6xXFXXXJ/Removable-Wall-Sticker-For-Kids-Rooms-Mini-Size-Cartoon-Hello-Dog-Mirror-Wall-Stickers-Switch-Stickers.jpg_640x640.jpg"),
            new FileToSend (@"https://ae01.alicdn.com/kf/HTB1vJdaQFXXXXc1apXXq6xXFXXXB/3pc-lot-Lovely-Kitten-Say-Hello-Cat-Switch-Stickers-Home-Decoration-Wall-Vinyl-Decals-Living-Room.jpg"),
            new FileToSend (@"https://ae01.alicdn.com/kf/HTB1Lg4uMFXXXXXoaXXXq6xXFXXX8/Funny-Cute-Cartoon-Animal-Hello-Doggy-Dog-Pet-light-Switch-Sticker-Vinyl-Decal-for-Living-Room.jpg_640x640.jpg"),
            new FileToSend (@"http://hk1.image4.pushauction.com/0/0/ccc9b43a-1cb4-440a-88ad-b23e2cdf6e16/15f0e875-b678-47f6-89a6-98e834eea4ca.jpg"),
            new FileToSend (@"http://hk1.image4.pushauction.com/0/0/ccc9b43a-1cb4-440a-88ad-b23e2cdf6e16/cd4a8a5f-af5e-4dd0-826f-a282e75fdbaf.jpg"),
            new FileToSend (@"https://ae01.alicdn.com/kf/HTB1fZtBQFXXXXXUaXXXq6xXFXXXv/Say-Hello-cute-animal-wall-switch-sticker-home-decoration-light-remind-vinyl-stickers-kids-bedroom-decorations.jpg"),
            new FileToSend (@"https://ae01.alicdn.com/kf/HTB1heSLQFXXXXcoXpXXq6xXFXXXF.jpg")
        };
        Random rn = new Random();
       
        public override async void ExecuteCommand(Message message, TelegramBotClient my_bot)
        {
            await my_bot.SendTextMessageAsync(message.Chat.Id, "Hello! Catch greeting pictures from me)" );
            await my_bot.SendStickerAsync(message.Chat.Id, hellostikers[rn.Next(0,5)]);
        }
    }
}
