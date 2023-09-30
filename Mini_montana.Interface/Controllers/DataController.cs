using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Mini_montana.Application.Services.Alldata.Commands;
using Mini_montana.Application.Services.Alldata.Queries;
using Mini_montana.Domain.Entities;
using Mini_montana.Interface.Params;
using System.ComponentModel;

namespace Mini_montana.Interface.Controllers
{
    [EnableCors("enablecorspolicy")]
    public class DataController : Controller
    {
        private readonly IAlldataQueryService _alldataQueryService;
        private readonly IAlldataCommandService _alldataCommandService;

        public DataController(IAlldataQueryService alldataQueryService, IAlldataCommandService alldataCommandService)
        {
            _alldataQueryService = alldataQueryService;
            _alldataCommandService = alldataCommandService;
        }

        [HttpGet("Api/Data/GetCurrencys")]
        [Description("All currencies")]
        public async Task<ActionResult<List<Currency>>> GetAllCurrencys()
        {
            return Ok(await _alldataQueryService.GetCurrencys());
        }

        [HttpPost("Api/Data/DataCollected")]
        public async Task<Dictionary<string, bool>> DataCollected([FromForm] DataCollectedParam param)
        {
            var newHistory = new History();
            return await _alldataCommandService.postResponse(newHistory);
        }

    }
}
