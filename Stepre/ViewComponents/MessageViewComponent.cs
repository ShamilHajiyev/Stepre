using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stepre.DAL;
using Stepre.Models.CRUDModels;
using Stepre.Models.Entities;

namespace Stepre.ViewComponents
{
    public class MessageViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbcontext;

        public MessageViewComponent(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IViewComponentResult> InvokeAsync(MessageCreateModel message)
        {
            return View(message);
        }
    }
}
