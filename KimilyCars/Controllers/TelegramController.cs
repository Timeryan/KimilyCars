using System.Net;
using KimilyCars.Contracts.Telegram;
using KimilyCars.Services;
using Microsoft.AspNetCore.Mvc;

namespace KimilyCars.Controllers;

[ApiController]
[Route("api/telegram")]
public class TelegramController: ControllerBase
{
    private ITelegramService _telegramService;
    
    public TelegramController(ITelegramService telegramService)
    {
        _telegramService = telegramService;
    }
    
    [HttpPost("send")]
    [ProducesResponseType(typeof(SendResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Send(SendRequest request, CancellationToken cancellation)
    {
        return Ok(await _telegramService.Send(request, cancellation));
    }
}