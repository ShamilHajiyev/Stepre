namespace Stepre.Models.Entities
{
    public class Blog : BaseEntity
    {
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public string PublisherName { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
