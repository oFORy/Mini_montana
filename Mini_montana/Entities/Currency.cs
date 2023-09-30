using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_montana.Domain.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string ShortLabel { get; set; }
        public string Description { get; set; }
        public string WalletNumber { get; set; }
        public string ImageUrl { get; set; }
        public List<Country> Countries { get; set; }
    }
}
