namespace Stepre.Models.Entities
{
    public class Worker : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Profession { get; set; }
        public string ImgUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public decimal Salary { get; set; }
    }
}
