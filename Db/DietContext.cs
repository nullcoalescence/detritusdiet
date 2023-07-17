using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;

namespace detritusdiet.Db
{
    public class DietContext : DbContext
    {
        public DietContext(DbContextOptions<DietContext> options) : base(options)
        {

        }
    }
}
