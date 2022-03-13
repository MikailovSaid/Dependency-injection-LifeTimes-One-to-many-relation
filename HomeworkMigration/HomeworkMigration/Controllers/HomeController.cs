using HomeworkMigration.Data;
using HomeworkMigration.Models;
using HomeworkMigration.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HomeworkMigration.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.ToListAsync();

            ValentineContent valentineContent = await _context.ValentineContents.FirstOrDefaultAsync();

            HomeVM homeVM = new HomeVM()
            {
                Sliders = sliders,
                ValentineContent = valentineContent
            };
            
            return View(homeVM);
        }

        
    }
}
