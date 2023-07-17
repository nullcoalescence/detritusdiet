using detritusdiet.Models;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;

namespace detritusdiet.Db
{
    public class DietContext : DbContext
    {
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Food> Foods { get; set; }

        public DietContext(DbContextOptions<DietContext> options) : base(options)
        {

        }
    }
}
