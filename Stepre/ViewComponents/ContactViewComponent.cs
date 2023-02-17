using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stepre.DAL;

namespace Stepre.ViewComponents
{
    public class ContactViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbcontext;

        public ContactViewComponent(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var contacts = await _dbcontext.Contacts.Include(x => x.ContactType).ToListAsync();
            return View(contacts);
        }
    }
}
