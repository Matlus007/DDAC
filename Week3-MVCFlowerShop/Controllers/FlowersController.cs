using Microsoft.AspNetCore.Mvc;

using Week3_MVCFlowerShop.Models;
using Week3_MVCFlowerShop.Data;
using Microsoft.EntityFrameworkCore;

namespace Week3_MVCFlowerShop.Controllers
{
    public class FlowersController : Controller
    {
        private readonly Week3_MVCFlowerShopContext _context;
        public FlowersController(Week3_MVCFlowerShopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Flower> flowers = await _context.FlowerTable.ToListAsync();
            return View(flowers);
        }

        public IActionResult AddData()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddData(Flower flower)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flower);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flower);
        }
    }
}
