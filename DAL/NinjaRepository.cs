using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL
{
    public class NinjaRepository : RepositoryBase<Ninja>
    {
        private readonly NinjaManagerContext _dbcontext;

        public NinjaRepository(NinjaManagerContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public Ninja GetDetailed(int id)
        {
            return _dbcontext.Ninja.Include(n => n.EquippedArmour).ThenInclude(na => na.Armour).FirstOrDefault(n => n.Id == id);
        }
    }
}
