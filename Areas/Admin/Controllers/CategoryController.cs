using CialMVC.Context;
using CialMVC.Helpers;
using CialMVC.Models;
using CialMVC.ViewModels.CategoryVM;
using CialMVC.ViewModels.ExpertVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CialMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CialContext _db { get; }

        public CategoryController(CialContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _db.Categories.Select(x => new CategoryListItemVM
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
            return View(data);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            Category category = new Category()
            {
                Name = vm.Name,
            };
            await _db.AddAsync(category);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || Id < 0) return BadRequest();
            var data = await _db.Categories.FindAsync(Id);
            if (data == null) return NotFound();
            _db.Categories.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
