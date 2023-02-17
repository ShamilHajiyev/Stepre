using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.ContentModel;
using Stepre.DAL;
using Stepre.Models;
using Stepre.Models.Entities;
using Stepre.Models.ViewModels;
using System.Diagnostics;

namespace Stepre.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var freeShippingValue = _dbContext.FreeShippingValues.SingleOrDefault();
            var phoneNumber = _dbContext.Contacts.Include(x => x.ContactType)
                .Where(x => x.ContactType.Name.ToLower() == "phone")
                .FirstOrDefault();
            var categories = _dbContext.Categories.Include(x => x.Products).ToList();
            var products = _dbContext.Products.Include(x => x.Category).ToList();
            var tags = _dbContext.Tags.ToList();
            var blogs = _dbContext.Blogs.Include(x => x.Tag).ToList();

            var homeViewModel = new HomeViewModel
            {
                FreeShippingValue = freeShippingValue,
                PhoneNumber = phoneNumber,
                Categories = categories,
                Products = products,
                Tags = tags,
                Blogs = blogs
            };

            return View(homeViewModel);
        }

        public async Task<IActionResult> Cart()
        {
            var cartJson = Request.Cookies["cart"];

            if (cartJson == null) return BadRequest();

            var cartViewModels = JsonConvert.DeserializeObject<List<CartViewModel>>(cartJson);

            return View(cartViewModels);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            var product = await _dbContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == id);

            if (product == null)
                return NotFound();

            var cartJson = Request.Cookies["cart"];

            List<CartViewModel> existCartViewModels = null;

            if (cartJson != null)
                existCartViewModels = JsonConvert.DeserializeObject<List<CartViewModel>>(cartJson);

            if (existCartViewModels != null)
            {
                var existCartViewModel = existCartViewModels.Where(x => x.Id == product.Id).SingleOrDefault();

                if (existCartViewModel != null)
                {
                    existCartViewModel.Count++;
                }
                else
                {
                    existCartViewModels.Add(new CartViewModel
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        PrimaryImageUrl = product.PrimaryImageUrl,
                        TotalCount = product.Count,
                        Category = product.Category.Name,
                        Count = 1
                    });
                    
                }
            }
            else
            {
                existCartViewModels = new List<CartViewModel>
                {
                    new CartViewModel
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        PrimaryImageUrl = product.PrimaryImageUrl,
                        TotalCount = product.Count,
                        Category = product.Category.Name,
                        Count = 1
                    }
                };
            }

            var cartViewModelJson = JsonConvert.SerializeObject(existCartViewModels, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            Response.Cookies.Append("cart", cartViewModelJson);
            return NoContent();
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var product = await _dbContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == id);

            if (product == null)
                return NotFound();

            var cartJson = Request.Cookies["cart"];

            List<CartViewModel> existCartViewModels = null;

            if (cartJson != null)
                existCartViewModels = JsonConvert.DeserializeObject<List<CartViewModel>>(cartJson);

            if (existCartViewModels != null)
            {
                existCartViewModels.RemoveAll(x => x.Id == product.Id);
            }

            var cartViewModelJson = JsonConvert.SerializeObject(existCartViewModels, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            Response.Cookies.Append("cart", cartViewModelJson);
            return NoContent();
        }
    }
}