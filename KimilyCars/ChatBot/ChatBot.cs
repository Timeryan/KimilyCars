using KimilyCars.Contracts.Telegram;
using KimilyCars.Services;
using KimilyCars.Services.Helpers;
using Telegram.Bot;

namespace KimilyCars.ChatBot;

public class ChatBot : IChatBot
{
    private readonly TelegramBotClient _botClient;
    private readonly string[] _receivers;

    public ChatBot(IConfiguration configuration)
    {
        var botOptions = configuration.GetSection("BotOptions");
        _botClient = new TelegramBotClient(botOptions.GetSection("Token").Value);
        _receivers = botOptions.GetSection("Receivers").Get<string[]>();
    }
    
    public async Task<SendResponse> Send(SendRequest request, CancellationToken cancellation)
    {
        foreach (var receiver in _receivers)
        {
            await _botClient.SendTextMessageAsync(
                chatId: receiver,
                text: ChatBotHelper.GenerateRequestMessage(request),
                cancellationToken: cancellation);
            try
            {
                if (!string.IsNullOrEmpty(request.Phone) && request.Messengers != null &&
                    request.Messengers.Contains("telegram"))
                {
                    await _botClient.SendContactAsync(chatId: receiver,
                        phoneNumber: request.Phone,
                        firstName: request.Name,
                        cancellationToken: cancellation);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }
        return new SendResponse();
    }
}