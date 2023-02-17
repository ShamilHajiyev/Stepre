using Stepre.Models.Entities;

namespace Stepre.Models.ViewModels
{
    public class HomeViewModel
    {
        public FreeShippingValue FreeShippingValue { get; set; }
        public Contact PhoneNumber { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
