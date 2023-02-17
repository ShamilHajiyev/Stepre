using Stepre.Models.Entities;

namespace Stepre.Models.ViewModels
{
    public class ShopViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
