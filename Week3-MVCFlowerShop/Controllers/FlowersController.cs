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

        public async Task<IActionResult> EditData(int? FlowerID)
        {
            if (FlowerID == null)
            {
                return NotFound();
            }
            var flower = await _context.FlowerTable.FindAsync(FlowerID);
            if (flower == null)
            {
                return BadRequest(FlowerID + " is not found in the table!");
            }
            return View(flower);
        }

        //delete data from the page
        public async Task<IActionResult> DeleteData(int? FlowerID)
        {
            if (FlowerID == null)
            {
                return NotFound();
            }
            var flower = await _context.FlowerTable.FindAsync(FlowerID);
            if (flower == null)
            {
                return BadRequest(FlowerID + " is not found in the list!");
            }
            _context.FlowerTable.Remove(flower);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Flowers");
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateData(Flower flower)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.FlowerTable.Update(flower);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Flowers");
                }
                return View("EditData", flower);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }
    }
}
