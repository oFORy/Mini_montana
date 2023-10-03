using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Mini_montana.Interface.bot
{
    public class HandlerService
    {
        private readonly ITelegramBotClient _botClient;
        private readonly ILogger<HandlerService> _logger;


        public HandlerService(ITelegramBotClient botClient, ILogger<HandlerService> logger)
        {
            _botClient = botClient;
            _logger = logger;
        }

        public async Task EchoAsync(Update update)
        {
            try
            {
                _logger.LogInformation(update.Type.ToString());
                switch (update.Type)
                {
                    case UpdateType.Message:
                        await BotOnMessageReceived(update.Message!);
                        break;
                    default:
                        await BotOnMessageReceived(update.Message!);
                        break;
                };
            }
            catch (Exception exception)
            {
                await HandleErrorAsync(exception);
            }
        }

        private async Task BotOnMessageReceived(Message message)
        {
            _logger.LogInformation($"Receive message type: {message.Type}");
            if (message.Type != MessageType.Text)
                return;

            Message sentMessage = new Message();

            switch (message.Text!.Split(' ')[0])
            {
                case "/start":
                    sentMessage = await SendFirstMessage(message);
                    break;
                default:
                    sentMessage = await SendFirstMessage(message);
                    break;
            }

            _logger.LogInformation($"The message was sent with id: {sentMessage.MessageId}");
        }





        private async Task<Message> SendFirstMessage(Message message)
        {
            string usage = "Привет" + (message?.From?.FirstName != null ? ", " + message?.From?.FirstName + "! " : "! ") +
                           "Добро пожаловать! Наш сервис к твоим услугам!\n\n";

            return await _botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                                         text: usage,
                                                         replyMarkup: new ReplyKeyboardRemove());
        }







        public Task HandleErrorAsync(Exception exception)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            _logger.LogInformation("HandleError: {ErrorMessage} | StackTrace: {StackTrace}", ErrorMessage, exception.StackTrace);
            return Task.CompletedTask;
        }
    }
}
