using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class NinjaArmourRepository<TModel> where TModel : NinjaArmour
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TModel> _table;

        public NinjaArmourRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<TModel>();
        }

        public void Add(IEnumerable<TModel> itemList) => _table.AddRangeAsync(itemList);

        public void Add(TModel item) => _table.AddAsync(item);

        public void Delete(IEnumerable<TModel> itemList) => _table.RemoveRange(itemList);

        public void Delete(TModel item) => _table.Remove(item);

        public IEnumerable<TModel> Get() => _table;

        //public TModel Get(int ninjaId, int armourId)
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

        public void Update(TModel item) => _table.Update(item);

        public void Update(IEnumerable<TModel> itemList) => _table.UpdateRange(itemList);

        public void Save() => _dbContext.SaveChanges();
    }
}