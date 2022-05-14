using Microsoft.EntityFrameworkCore;
using Wafi_Solution_Project.Models;

namespace Wafi_Solution_Project.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<HolidayModel> holidayD { get; set; }
        public DbSet<Countries> countriesD { get; set; }
    }
}
