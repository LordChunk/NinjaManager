using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class RepositoryBase<TModel> : IRepositoryBase<TModel> where TModel : ModelBase
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TModel> _table;

        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<TModel>();
        }

        public void Add(IEnumerable<TModel> itemList)
        {
            _table.AddRangeAsync(itemList);
        }

        public void Add(TModel item)
        {
            _table.AddAsync(item);
        }

        public void Delete(IEnumerable<TModel> itemList)
        {
            _table.RemoveRange(itemList);
        }

        public void Delete(TModel item)
        {
            _table.Remove(item);
        }

        public IEnumerable<TModel> Get()
        {
            return _table;
        }

        public TModel Get(int id)
        {
            return _table.Find(id);
        }

        public IEnumerable<TModel> Get(IEnumerable<int> ids)
        {
            var itemList = new List<TModel>();
            foreach (var id in ids)
            {
                itemList.Add(Get(id));
            }

            return itemList;
        }

        public void Update(TModel item)
        {
            _table.Update(item);
        }

        public void Update(IEnumerable<TModel> itemList)
        {
            _table.UpdateRange(itemList);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}