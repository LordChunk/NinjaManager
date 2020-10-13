using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace DAL.Interfaces
{
    public interface ICrudMvcControllerBase<TModel> where TModel : ModelBase
    {
        public IActionResult Index();
        public IActionResult Details(int id);
        public IActionResult Create();
        public IActionResult Create(TModel model);
        public IActionResult Edit(int id);
        public IActionResult Edit(int id, TModel model);
        public IActionResult Delete(int id);
        public IActionResult DeleteConfirmed(int id);
    }
}