using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stepre.DAL;

namespace Stepre.Areas.Admin.Controllers
{
    public class BlogController : BaseAdminController
    {
        private readonly AppDbContext _dbContext;

        public BlogController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var blogs = _dbContext.Blogs.Include(x => x.Tag).ToList();
            return View(blogs);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var blog = _dbContext.Blogs.Include(x => x.Tag).SingleOrDefault(x => x.Id == id);

            if (blog == null)
                return NotFound();

            return View(blog);
        }
    }
}
