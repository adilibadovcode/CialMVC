using CialMVC.Context;
using CialMVC.Helpers;
using CialMVC.Models;
using CialMVC.ViewModels.ExpertVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CialMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class ExpertController : Controller
    {
        CialContext _db { get; }

        public ExpertController(CialContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Categories = _db.Categories;

            var data = await _db.Experts.Select(x => new ExpertListItemVM
            {
                Id = x.Id,
                Image = x.Image,
                Name = x.Name,
                Category = x.Categories,
            }).ToListAsync();
            return View(data);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = _db.Categories;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ExpertCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _db.Categories;

                return View(vm);
            }
            Expert expert = new Expert()
            {
                Name = vm.Name,
                Image = await vm.Image.SaveAsync(PathConstants.Expert),
                CategoryId = vm.CategoryId,
            };
            await _db.AddAsync(expert);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || Id < 0) return BadRequest();
            var data = await _db.Experts.FindAsync(Id);
            if (data == null) return NotFound();
            _db.Experts.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Update(int? Id)
        {
            if (Id == null || Id < 0) return BadRequest();
            var data = await _db.Experts.FindAsync(Id);
            if (data == null) return NotFound();
            ViewBag.Categories = _db.Categories;
            return View(new ExpertUpdateVM
            {
                Name = data.Name,
                CategoryId=data.CategoryId,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? Id, ExpertUpdateVM vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _db.Categories;

                return View(vm);
            }
            ViewBag.Categories = _db.Categories;
            if (Id == null || Id < 0) return BadRequest();
            var data = await _db.Experts.FindAsync(Id);
            if (data == null) return NotFound();
            data.Image = await vm.Image.SaveAsync(PathConstants.Expert);
            data.Name = vm.Name;
            data.CategoryId = vm.CategoryId;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
