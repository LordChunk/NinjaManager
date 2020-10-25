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
            var returnValue = _dbContext.Ninja.Include(n => n.EquippedArmour).ThenInclude(na => na.Armour).FirstOrDefault(n => n.Id == id);

            // Set state to detached to prevent issues when updating related tables 
            if (returnValue != null)
                _dbContext.Entry(returnValue).State = EntityState.Detached;

            return returnValue;
        }
    }
}
