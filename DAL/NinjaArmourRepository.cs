using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class NinjaArmourRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<NinjaArmour> _table;

        public NinjaArmourRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<NinjaArmour>();
        }

        public void Add(IEnumerable<NinjaArmour> itemList) => _table.AddRangeAsync(itemList);

        public void Add(NinjaArmour item) => _table.AddAsync(item);

        public void Delete(IEnumerable<NinjaArmour> itemList) => _table.RemoveRange(itemList);

        public void Delete(NinjaArmour item) => _table.Remove(item);

        public IEnumerable<NinjaArmour> Get() => _table.Include(n => n.Armour).Include(n => n.Ninja);

        //public NinjaArmour Get(int ninjaId, int armourId)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<Armour> GetArmourFromNinja(Ninja ninja)
        {
            return _table.Where(na => na.NinjaId == ninja.Id).Select(na => na.Armour);
        }

        public IEnumerable<Ninja> GetNinjaFromArmour(Armour armour)
        {
            return _table.Where(na => na.ArmourId == armour.Id).Select(na => na.Ninja);
        }

        public void Update(NinjaArmour item) => _table.Update(item);

        public void Update(IEnumerable<NinjaArmour> itemList) => _table.UpdateRange(itemList);

        public void Save() => _dbContext.SaveChanges();
    }
}