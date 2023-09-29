using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Mini_montana.Application.Services.Alldata.Commands;
using Mini_montana.Application.Services.Alldata.Queries;
using Mini_montana.Domain.Entities;
using System.ComponentModel;

namespace Mini_montana.Interface.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IAlldataQueryService _alldataQueryService;
        private readonly IAlldataCommandService _alldataCommandService;

        public UserController(IAlldataQueryService alldataQueryService, IAlldataCommandService alldataCommandService)
        {
            _alldataQueryService = alldataQueryService;
            _alldataCommandService = alldataCommandService;
        }

        [HttpGet("GetCurrencys")]
        [Description("All currencies")]
        public async Task<ActionResult<List<Currency>>> GetAllCurrencys()
        {
            return Ok(await _alldataQueryService.GetCurrencys());
        }

        [HttpPost("DataСollected")]
        public async Task<Dictionary<string, bool>> DataСollected([FromBody] History history)
        {
            return await _alldataCommandService.postResponse(history);
        }

    }
}
