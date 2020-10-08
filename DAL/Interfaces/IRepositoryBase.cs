using System.Collections.Generic;
using System.Threading.Tasks;
using ModelLayer;

namespace DAL.Interfaces
{
    public interface IRepositoryBase<TModel> where TModel : ModelBase
    {
        public void Add(IEnumerable<TModel> itemList);
        public void Add(TModel item);
        public Task<IEnumerable<TModel>> Get();
        public Task<TModel> Get(int id);
        public Task<IEnumerable<TModel>> Get(IEnumerable<int> ids);
        public void Update(IEnumerable<TModel> itemList);
        public void Update(TModel item);
        public void Delete(IEnumerable<TModel> itemList);
        public void Delete(TModel item);
    }
}