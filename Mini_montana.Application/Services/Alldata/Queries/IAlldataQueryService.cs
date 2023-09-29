using Mini_montana.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_montana.Application.Services.Alldata.Queries
{
    public interface IAlldataQueryService
    {
        Task<List<Currency>> GetCurrencys();
    }
}
