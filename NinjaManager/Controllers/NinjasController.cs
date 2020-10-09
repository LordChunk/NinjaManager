using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Data;
using DAL.Models;

namespace NinjaManager.Controllers
{
    public class NinjasController : Controller
    {
        private readonly NinjaManagerContext _context;

        public NinjasController(NinjaManagerContext context)
        {
            _context = context;
        }

        // GET: Ninjas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ninja.ToListAsync());
        }

        // GET: Ninjas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ninja = await _context.Ninja
                .FirstOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Create([Bind("Name,Gold,Id")] Ninja ninja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ninja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ninja);
        }

        // GET: Ninjas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ninja = await _context.Ninja.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Name,Gold,Id")] Ninja ninja)
        {
            if (id != ninja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ninja);
                    await _context.SaveChangesAsync();
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ninja = await _context.Ninja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ninja == null)
            {
                return NotFound();
            }

            return View(ninja);
        }

        // POST: Ninjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ninja = await _context.Ninja.FindAsync(id);
            _context.Ninja.Remove(ninja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NinjaExists(int id)
        {
            return _context.Ninja.Any(e => e.Id == id);
        }
    }
}
