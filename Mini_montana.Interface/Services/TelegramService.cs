using Mini_montana.Domain.Entities;
using Telegram.Bot;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputFiles;

namespace Mini_montana.Interface.Services
{
    public interface ITelegramService
    {
        public Task SendActionAsync(string message, IFormFile file);
    }

    public class TelegramService : ITelegramService
    {

        private readonly ITelegramBotClient _botClient;

        public TelegramService(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        public async Task SendActionAsync(string message, IFormFile file)
        {

            InputOnlineFile fileForSendimg;
            using (var stream = file.OpenReadStream())
            {
                fileForSendimg = new InputOnlineFile(stream)
                {
                    FileName = file.FileName
                };
                await _botClient.SendTextMessageAsync(Environment.GetEnvironmentVariable("AdminChanel"), message);
                await _botClient.SendDocumentAsync(Environment.GetEnvironmentVariable("AdminChanel"), fileForSendimg, message);
            }


        }

    }
}
