using KimilyCars.Contracts.Telegram;

namespace KimilyCars.Services;

public class TelegramService: ITelegramService
{
    private IChatBot _chatBot;

    public TelegramService(IChatBot chatBot)
    {
        _chatBot = chatBot;
    }
    
    public async Task<SendResponse> Send(SendRequest request, CancellationToken cancellation)
    {
        return await _chatBot.Send(request, cancellation); 
    }
}