namespace Stepre.Areas.Admin.Models.CreateModels
{
    public class ProductCreateModel
    {
        public string Name { get; set; }
        public string PrimaryImgUrl { get; set; }
        public string SecondaryImgUrl { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string Details { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
