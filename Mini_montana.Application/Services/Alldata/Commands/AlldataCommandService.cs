using Mini_montana.Application.Services.Alldata.Common;
using Mini_montana.Application.Services.Alldata.Queries;
using Mini_montana.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_montana.Application.Services.Alldata.Commands
{
    public class AlldataCommandService : IAlldataCommandService
    {
        private readonly IAlldataRepository _alldataRepository;
        public AlldataCommandService(IAlldataRepository alldataRepository)
        {
            _alldataRepository = alldataRepository;
        }

        public async Task<Dictionary<string, bool>> postResponse(History history)
        {
            return await _alldataRepository.postResponse(history);
        }
    }
}
