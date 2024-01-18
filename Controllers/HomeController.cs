using CialMVC.Context;
using CialMVC.ViewModels.ExpertVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CialMVC.Controllers
{
    public class HomeController : Controller
    {
        CialContext _db { get; }

        public HomeController(CialContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _db.Experts.Select(x => new ExpertListItemVM
            {
                Id = x.Id,
                Name = x.Name,
                Category=x.Categories,
                Image=x.Image
            }).ToListAsync();
            return View(data);
        }
    }
}
