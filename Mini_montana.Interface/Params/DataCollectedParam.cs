using Mini_montana.Domain.Entities;
using Mini_montana.Domain.ModelObject;

namespace Mini_montana.Interface.Params
{
    public class DataCollectedParam
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserLogin { get; set; }
        public string CurrencyName { get; set; }
        public string? SelectedDateTime { get; set; }
        public string ActionTypeName { get; set; }
        public ActionTypes ActionType { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public IFormFile Files { get; set; }
    }
}
