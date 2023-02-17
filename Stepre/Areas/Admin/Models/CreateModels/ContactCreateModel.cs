using Microsoft.AspNetCore.Mvc.Rendering;
using Stepre.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Stepre.Areas.Admin.Models.CreateModels
{
    public class ContactCreateModel
    {
        public string Name { get; set; }

        public string ContactType { get; set; }
    }
}
