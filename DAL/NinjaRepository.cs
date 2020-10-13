using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class NinjaRepository : RepositoryBase<Ninja>
    {
        public NinjaRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}