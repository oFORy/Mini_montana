using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Mini_montana.Application.Services.Alldata.Commands;
using Mini_montana.Application.Services.Alldata.Queries;
using Mini_montana.Domain.Entities;
using Mini_montana.Interface.Params;
using Mini_montana.Interface.Services;
using System.ComponentModel;
using Telegram.Bot.Types;

namespace Mini_montana.Interface.Controllers
{
    [ApiController]
    [EnableCors("enablecorspolicy")]
    public class DataController : ControllerBase
    {
        private readonly IAlldataQueryService _alldataQueryService;
        private readonly IAlldataCommandService _alldataCommandService;
        private readonly ITelegramService _telegramService;

        public DataController(IAlldataQueryService alldataQueryService, IAlldataCommandService alldataCommandService, ITelegramService telegramService)
        {
            _alldataQueryService = alldataQueryService;
            _alldataCommandService = alldataCommandService;
            _telegramService = telegramService;
        }

        [HttpGet("Api/Data/GetCurrencys")]
        [Description("All currencies")]
        public async Task<ActionResult<List<Currency>>> GetAllCurrencys()
        {
            return Ok(await _alldataQueryService.GetCurrencys());
        }

        [HttpPost("Api/Data/DataCollected")]
        public async Task<ActionResult> DataCollected([FromForm] DataCollectedParam param)
        {
            var message = $"Имя: {param.UserName}\n" +
              $"Id: {param.UserId}\n" +
              $"Логин: {param.UserLogin}\n" +
              $"Страна: {param.CountryName}\n" +
              $"Валюта: {param.CurrencyName}\n" +
              $"Действие: {param.ActionTypeName}\n" +
              $"Время: {param.SelectedDateTime}\n";

            await _telegramService.SendActionAsync(message, param.Files);
            return Ok();
            //return await _alldataCommandService.postResponse(newHistory);
        }

    }
}
