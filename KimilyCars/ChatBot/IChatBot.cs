using KimilyCars.Contracts.Telegram;

namespace KimilyCars.Services;

public interface IChatBot
{
    Task<SendResponse> Send(SendRequest request, CancellationToken cancellationToken);
}