using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class NinjaManagerContext : DbContext
    {
        public NinjaManagerContext(DbContextOptions<NinjaManagerContext> options) : base(options)
        {

        }

        // DbSet
    }
}