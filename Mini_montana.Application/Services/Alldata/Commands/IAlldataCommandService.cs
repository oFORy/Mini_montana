using Mini_montana.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_montana.Application.Services.Alldata.Commands
{
    public interface IAlldataCommandService
    {
        Task<Dictionary<string, bool>> postResponse(History history);
    }
}
