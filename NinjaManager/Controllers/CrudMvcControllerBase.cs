using DAL;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NinjaManager.Controllers
{
    public abstract class CrudMvcControllerBase<TModel> : ControllerBase, ICrudMvcControllerBase<TModel> where TModel : ModelBase
    {
        private readonly RepositoryBase<TModel> _repository;

        protected CrudMvcControllerBase(DbContext context) => _repository = new RepositoryBase<TModel>(context);

        public IActionResult Index() => View(_repository.Get());

        public IActionResult Details(int id)
        {
            var model = _repository.Get(id);

            if (model == null) return NotFound();

            return View(model);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual IActionResult Create([FromForm] TModel model)
        {
            if (!ModelState.IsValid) return View(model);

            _repository.Add(model);
            _repository.Save();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            var model = _repository.Get(id);
            if (model == null) return NotFound();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual IActionResult Edit(int id, [FromForm] TModel model)
        {
            if (id != model.Id) return NotFound();
            if (!ModelState.IsValid) return View(model);

            try
            {
                _repository.Update(model);
                _repository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExists(model.Id)) return NotFound();

                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var model = _repository.Get(id);
            if (model == null) return NotFound();

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var model = _repository.Get(id);
            _repository.Delete(model);
            _repository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelExists(int id) => _repository.Get(id) == null;
    }
}
