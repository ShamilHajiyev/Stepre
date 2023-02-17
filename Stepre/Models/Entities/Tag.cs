namespace Stepre.Models.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
