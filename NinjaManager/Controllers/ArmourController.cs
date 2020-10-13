using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Data;
using DAL.Models;

namespace NinjaManager.Controllers
{
    public class ArmourController : Controller
    {
        private readonly NinjaManagerContext _context;

        public ArmourController(NinjaManagerContext context)
        {
            _context = context;
        }

        // GET: Armour
        public IActionResult Index()
        {
            return View(_context.Armour.ToList());
        }

        // GET: Armour/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armour = _context.Armour
                .FirstOrDefault(m => m.Id == id);
            if (armour == null)
            {
                return NotFound();
            }

            return View(armour);
        }

        // GET: Armour/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Armour/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Strength,Agility,Intelligence,Price,ArmourType,Id")] Armour armour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(armour);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(armour);
        }

        // GET: Armour/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armour =_context.Armour.Find(id);
            if (armour == null)
            {
                return NotFound();
            }
            return View(armour);
        }

        // POST: Armour/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,Strength,Agility,Intelligence,Price,ArmourType,Id")] Armour armour)
        {
            if (id != armour.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(armour);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArmourExists(armour.Id))
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
            return View(armour);
        }

        // GET: Armour/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armour = _context.Armour
                .FirstOrDefault(m => m.Id == id);
            if (armour == null)
            {
                return NotFound();
            }

            return View(armour);
        }

        // POST: Armour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var armour = _context.Armour.Find(id);
            _context.Armour.Remove(armour);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ArmourExists(int id)
        {
            return _context.Armour.Any(e => e.Id == id);
        }
    }
}
