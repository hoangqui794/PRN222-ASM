using EyewearShop.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EyewearShop.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly Prn222EyewearshopContext _context;

        public ProductController(Prn222EyewearshopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var products = _context.ProductTriChes
                .Include(p => p.Category)
                .Include(p => p.ProductImageTriChes)
                .Include(p => p.ProductColorTriChes)
                .Where(p => p.Status == 1);

            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.ProductName.Contains(searchString)
                                            || s.Description.Contains(searchString)
                                            || s.ProductColorTriChes.Any(c => c.ColorName.Contains(searchString)));
            }

            ViewBag.CurrentFilter = searchString;

            return View(await products.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var product = await _context.ProductTriChes
                .Include(p => p.Category)
                .Include(p => p.ProductImageTriChes)
                .Include(p => p.ProductColorTriChes) 
                .FirstOrDefaultAsync(m => m.ProductId == id);

            if (product == null) return NotFound();

            return View(product);
        }

        public IActionResult Index1()
        {
            return View();
        }

    }
}
