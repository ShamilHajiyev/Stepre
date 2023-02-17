using Stepre.Models.Entities;

namespace Stepre.Models.ViewModels
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public string PrimaryImageUrl { get; set; }
        public decimal Price { get; set; }
        public int TotalCount { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
    }
}
