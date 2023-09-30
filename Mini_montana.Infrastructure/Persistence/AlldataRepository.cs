using Microsoft.EntityFrameworkCore;
using Mini_montana.Application.Services.Alldata.Common;
using Mini_montana.Domain.Entities;


namespace Mini_montana.Infrastructure.Persistence
{
    public class AlldataRepository : IAlldataRepository
    {
        private readonly BotDbContext _botDbContext;

        public AlldataRepository(BotDbContext context)
        {
            _botDbContext = context;
        }

        public async Task<List<Currency>> GetCurrencys()
        {
            return await _botDbContext.Currencies.AsNoTracking().ToListAsync();
        }


        // временная затычка
        public Task<Dictionary<string, bool>> postResponse(History history)
        {
            var result = new Dictionary<string, bool>
            {
                ["Status"] = true
            };

            return Task.FromResult(result);
        }
    }
}
