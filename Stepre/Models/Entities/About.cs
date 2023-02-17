namespace Stepre.Models.Entities
{
    public class About : BaseEntity
    {
        public string Header { get; set; }
        public string TopContent { get; set; }
        public string BottomContent { get; set; }
        public string Quote { get; set; }
        public string ImgUrl { get; set; }
    }
}
