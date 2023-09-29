using Mini_montana.Domain.ModelObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_montana.Domain.Entities
{
    public class History
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserLogin { get; set; }
        public int IdCurrency { get; set; }
        public DateTime DateTime { get; set; }
        public ActionTypes ActionType { get; set; }
        public int IdCountry { get; set; }
    }
}
