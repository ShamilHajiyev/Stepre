﻿namespace Stepre.Models.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string PrimaryImageUrl { get; set; }
        public string SecondaryImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string Details { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
