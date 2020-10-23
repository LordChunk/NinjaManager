using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL
{
    public class NinjaRepository : RepositoryBase<Ninja>
    {
        private readonly NinjaManagerContext _dbContext;

        public NinjaRepository(NinjaManagerContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Ninja GetDetailed(int id)
        {
            return _dbContext.Ninja.Include(n => n.EquippedArmour).ThenInclude(na => na.Armour).FirstOrDefault(n => n.Id == id);
        }
    }
}
