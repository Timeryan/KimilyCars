using KimilyCars.Contracts.Telegram;

namespace KimilyCars.Services;

public interface ITelegramService
{
    Task<SendResponse> Send(SendRequest request, CancellationToken cancellation); 
}