namespace Stepre.Models.Entities
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; }
        public int ContactTypeId { get; set; }
        public ContactType ContactType { get; set; }
    }
}
