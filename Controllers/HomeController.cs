using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Wafi_Solution_Project.Data;
using Wafi_Solution_Project.Models;

namespace Wafi_Solution_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("SavePublicHoliday")]
        public async Task<IActionResult> SavePublicHoliday(HolidayModel holiday)
        {
            if (ModelState.IsValid) 
            {
                var isExist = await _context.holidayD.Where(x => x.Name == holiday.Name && x.Countrys == holiday.Countrys && x.Date == holiday.Date).ToListAsync();
                if (isExist.Count == 0)
                {
                    await _context.holidayD.AddAsync(holiday);
                    await _context.SaveChangesAsync();
                }
            }

            return NoContent();
        }

    }
}