using System.Linq;
using System.Threading.Tasks;
using DEMOCRUD.Models.db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DEMOCRUD.Controllers {
    public class CategoriesController : Controller {
        private readonly NorthwindContext _context;
        public CategoriesController (NorthwindContext context) {
            _context = context;
        }
        public async Task<IActionResult> Index () {
            var northwindContext = _context.Categories;
            return View (await northwindContext.ToListAsync ());
        }
        public IActionResult Create () {
            return View ();
        }
        public IActionResult Contact () {
            return View ();
        }
        public IActionResult Error () {
            return View ();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory ([Bind ("CategoryId,CategoryName,Description,Picture")] Categories categories) {
            if (ModelState.IsValid) {
                _context.Add (categories);
                await _context.SaveChangesAsync ();
                return RedirectToAction (nameof (Index));
            }

            return View (categories);
        }
        public async Task<IActionResult> Details (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var categories = await _context.Categories
                .FirstOrDefaultAsync (m => m.CategoryId == id);
            if (categories == null) {
                return NotFound ();
            }

            return View (categories);
        }
        public async Task<IActionResult> Edit (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var products = await _context.Categories.FindAsync (id);
            if (products == null) {
                return NotFound ();
            }
            return View (products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, [Bind ("CategoryId,CategoryName,Description,Picture")] Categories categories) {
            if (id != categories.CategoryId) {
                return NotFound ();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update (categories);
                    await _context.SaveChangesAsync ();
                } catch (DbUpdateConcurrencyException) {
                    if (!CategoriesExists (categories.CategoryId)) {
                        return NotFound ();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction (nameof (Index));
            }
            return View (categories);
        }
        private bool CategoriesExists (int id) {
            return _context.Categories.Any (e => e.CategoryId == id);
        }
    }
}