using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using ModelLayer;

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

        public async void Add(IEnumerable<TModel> itemList)
        {
            await _table.AddRangeAsync(itemList);
        }

        public async void Add(TModel item)
        {
            await _table.AddAsync(item);
        }

        public void Delete(IEnumerable<TModel> itemList)
        {
            _table.RemoveRange(itemList);
        }

        public void Delete(TModel item)
        {
            _table.Remove(item);
        }

        public async Task<IEnumerable<TModel>> Get()
        {
            return await _table.ToListAsync();
        }

        public async Task<TModel> Get(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<IEnumerable<TModel>> Get(IEnumerable<int> ids)
        {
            var itemList = new List<TModel>();
            foreach (var id in ids)
            {
                itemList.Add(await Get(id));
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

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}