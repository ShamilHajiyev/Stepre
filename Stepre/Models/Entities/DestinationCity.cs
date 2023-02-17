namespace Stepre.Models.Entities
{
    public class DestinationCity : BaseEntity
    {
        public string Name { get; set; }
        public int DestinationCountryId { get; set; }
        public DestinationCountry DestinationCountry { get; set; }
    }
}
