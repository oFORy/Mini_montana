using Mini_montana.Domain.Entities;
using Mini_montana.Application.Services.Alldata.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_montana.Application.Services.Alldata.Queries
{
    public class AlldataQueryService : IAlldataQueryService
    {
        private readonly IAlldataRepository _alldataRepository;
        public AlldataQueryService(IAlldataRepository alldataRepository)
        {
            _alldataRepository = alldataRepository;
        }

        public async Task<List<Currency>> GetCurrencys()
        {
            return await _alldataRepository.GetCurrencys();
        }
    }
}
