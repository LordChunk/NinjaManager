using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using DAL.Data;

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

        public IEnumerable<TModel> Get()
        {
            return GetTable();
        }

        public TModel Get(int id)
        {
            return GetTable().Find(id);
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
            GetTable().Update(item);
        }

        public void Update(IEnumerable<TModel> itemList)
        {
            GetTable().UpdateRange(itemList);
        }

        public void Save()
        {
            GetDbContext().SaveChanges();
        }
    }
}