using Microsoft.AspNetCore.Mvc;
using Mini_montana.Interface.bot;
using Telegram.Bot.Types;

namespace Mini_montana.Interface.Controllers
{
    public class WebhookController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromServices] HandlerService handleUpdateService,
                                      [FromBody] Update update)
        {
            await handleUpdateService.EchoAsync(update);
            return Ok();
        }
    }
}
