namespace Stepre.Models.Entities
{
    public class FreeShippingValue : BaseEntity
    {
        public bool IsExist { get; set; }
        public decimal? MinimalAmount { get; set; }
    }
}
