using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Data;
using DAL.Models;

namespace NinjaManager.Controllers
{
    public class NinjasController : Controller
    {
        private readonly NinjaRepository _ninjaRepository;

        public NinjasController(NinjaManagerContext context)
        {
            _ninjaRepository = new NinjaRepository(context);
        }

        // GET: Ninjas
        public IActionResult Index()
        {
            return View(_ninjaRepository.Get());
        }

        // GET: Ninjas/Details/5
        public IActionResult Details(int id)
        {
            var ninja = _ninjaRepository.Get(id);
            if (ninja == null)
            {
                return NotFound();
            }

            return View(ninja);
        }

        // GET: Ninjas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ninjas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Gold,Id")] Ninja ninja)
        {
            if (ModelState.IsValid)
            {
                _ninjaRepository.Add(ninja);
                _ninjaRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(ninja);
        }

        // GET: Ninjas/Edit/5
        public IActionResult Edit(int id)
        {
            var ninja = _ninjaRepository.Get(id);
            if (ninja == null)
            {
                return NotFound();
            }
            return View(ninja);
        }

        // POST: Ninjas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,Gold,Id")] Ninja ninja)
        {
            if (id != ninja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ninjaRepository.Update(ninja);
                    _ninjaRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NinjaExists(ninja.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ninja);
        }

        // GET: Ninjas/Delete/5
        public IActionResult Delete(int id)
        {
            var ninja = _ninjaRepository.Get(id);
            if (ninja == null)
            {
                return NotFound();
            }

            return View(ninja);
        }

        // POST: Ninjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var ninja = _ninjaRepository.Get(id);
            _ninjaRepository.Delete(ninja);
            _ninjaRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool NinjaExists(int id)
        {
            return _ninjaRepository.Get(id) == null;
        }
    }
}
