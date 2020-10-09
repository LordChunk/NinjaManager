using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class RepositoryBase<TModel> : IRepositoryBase<TModel> where TModel : ModelBase
    {
        private DbSet<TModel> GetTable()
        {
            return GetDbContext().Set<TModel>();
        }

        private DbContext GetDbContext()
        {
            return new NinjaManagerContext();
        }

        public void Add(IEnumerable<TModel> itemList)
        {
            GetTable().AddRangeAsync(itemList);
        }

        public void Add(TModel item)
        {
            GetTable().AddAsync(item);
        }

        public void Delete(IEnumerable<TModel> itemList)
        {
            GetTable().RemoveRange(itemList);
        }

        public void Delete(TModel item)
        {
            GetTable().Remove(item);
        }

        public async Task<IEnumerable<TModel>> Get()
        {
            return await GetTable().ToListAsync();
        }

        public async Task<TModel> Get(int id)
        {
            return await GetTable().FindAsync(id);
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
            GetTable().Update(item);
        }

        public void Update(IEnumerable<TModel> itemList)
        {
            GetTable().UpdateRange(itemList);
        }

        public async Task Save()
        {
            await GetDbContext().SaveChangesAsync();
        }
    }
}