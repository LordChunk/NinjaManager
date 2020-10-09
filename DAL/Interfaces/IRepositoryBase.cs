using DAL.Models;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRepositoryBase<TModel> where TModel : ModelBase
    {
        public void Add(IEnumerable<TModel> itemList);
        public void Add(TModel item);
        public IEnumerable<TModel> Get();
        public TModel Get(int id);
        public IEnumerable<TModel> Get(IEnumerable<int> ids);
        public void Update(IEnumerable<TModel> itemList);
        public void Update(TModel item);
        public void Delete(IEnumerable<TModel> itemList);
        public void Delete(TModel item);
    }
}