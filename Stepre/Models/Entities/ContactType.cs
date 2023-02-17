namespace Stepre.Models.Entities
{
    public class ContactType : BaseEntity
    {
        public string Name { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
