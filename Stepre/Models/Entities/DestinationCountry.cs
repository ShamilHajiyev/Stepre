namespace Stepre.Models.Entities
{
    public class DestinationCountry : BaseEntity
    {
        public string Name { get; set; }
        public List<DestinationCity> DestinationCities { get; set; }
    }
}
