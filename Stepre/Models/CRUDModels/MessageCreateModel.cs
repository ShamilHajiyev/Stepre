using System.ComponentModel.DataAnnotations;

namespace Stepre.Models.CRUDModels
{
    public class MessageCreateModel
    {
        [Required, MaxLength(30)]
        public string Name { get; set; }

        [Required, MaxLength(30)]
        public string Email { get; set; }

        [Required, MaxLength(30)]
        public string Subject { get; set; }

        [Required, MaxLength(500)]
        public string Content { get; set; }
    }
}
