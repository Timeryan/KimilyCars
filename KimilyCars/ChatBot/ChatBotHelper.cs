using System.Text;
using KimilyCars.Contracts.Telegram;

namespace KimilyCars.Services.Helpers;

public static class ChatBotHelper
{
    private static readonly Dictionary<string, string> _messengers
        = new Dictionary<string, string>
        {
            { "telegram", "Telegram" },
            { "whatsapp", "WhatsApp" }
        };
    
    public static string GenerateRequestMessage(SendRequest request)
    {
        var requestMessage = new StringBuilder();

        requestMessage.AppendLine($"\U0001F647 Имя: {request.Name}");
        
        if (!string.IsNullOrEmpty(request.Phone))
        {
            requestMessage.AppendLine($"\U0001F4DE Телефон: {request.Phone}");
            if (request.Messengers != null)
            {
                StringBuilder messengers = new StringBuilder();
                
                foreach (var m in request.Messengers)
                {
                    if (_messengers.ContainsKey(m))
                        messengers.Append($"{_messengers[m]},");
                }

                if (messengers.Length > 0)
                {
                    requestMessage.AppendLine($"\U0001F4F1 Мессенджеры: {messengers.ToString().TrimEnd(',')}");
                }
            }
        }

        if (!string.IsNullOrEmpty(request.Email))
        {
            requestMessage.AppendLine($"\U0001F4E7 Почта: {request.Email}");
        }
        
        requestMessage.AppendLine($"\U0001F4DD Описание: {request.Description}");

        return requestMessage.ToString();
    }
}