using System;
using System.Data;
using System.Linq;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Data;
using DAL.Models;

namespace NinjaManager.Controllers
{
    public class ShopController : Controller
    {
        private readonly NinjaArmourRepository _ninjaArmourRepository;
        private readonly RepositoryBase<Ninja> _ninjaRepository;
        private readonly RepositoryBase<Armour> _armourRepository;

        public ShopController(NinjaManagerContext context)
        {
            _ninjaArmourRepository = new NinjaArmourRepository(context);
            _ninjaRepository = new RepositoryBase<Ninja>(context);
            _armourRepository = new RepositoryBase<Armour>(context);
        }

        // GET: Shop
        public IActionResult Index() => View(_ninjaArmourRepository.Get());

        // GET: Shop/Details/5
        public IActionResult Details(int? id)
        {
            throw new NotImplementedException();

            if (id == null)
            {
                return NotFound();
            }

            //var ninjaArmour = _context.NinjaArmour
            //    .Include(n => n.Armour)
            //    .Include(n => n.Ninja)
            //    .FirstOrDefault(m => m.NinjaId == id);
            //if (ninjaArmour == null)
            //{
            //    return NotFound();
            //}

            //return View(ninjaArmour);
        }

        // GET: Shop/Create
        public IActionResult Create()
        {
            ViewData["ArmourId"] = new SelectList(_armourRepository.Get(), "Id", "Name");
            ViewData["NinjaId"] = new SelectList(_ninjaRepository.Get(), "Id", "Name");
            return View();
        }

        // POST: Shop/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("NinjaId,ArmourId")] NinjaArmour ninjaArmour)
        {
            if (ModelState.IsValid)
            {
                _ninjaArmourRepository.Add(ninjaArmour);
                _ninjaArmourRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArmourId"] = new SelectList(_armourRepository.Get(), "Id", "Name", ninjaArmour.ArmourId);
            ViewData["NinjaId"] = new SelectList(_ninjaRepository.Get(), "Id", "Name", ninjaArmour.NinjaId);
            return View(ninjaArmour);
        }

        // GET: Shop/Edit/5
        public IActionResult Edit(int? id)
        {
            throw new NotImplementedException();
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var ninjaArmour = _context.NinjaArmour.Find(id);
            //if (ninjaArmour == null)
            //{
            //    return NotFound();
            //}
            //ViewData["ArmourId"] = new SelectList(_context.Armour, "Id", "Name", ninjaArmour.ArmourId);
            //ViewData["NinjaId"] = new SelectList(_context.Ninja, "Id", "Name", ninjaArmour.NinjaId);
            //return View(ninjaArmour);
        }

        // POST: Shop/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("NinjaId,ArmourId")] NinjaArmour ninjaArmour)
        {
            throw new NotImplementedException();

            //if (id != ninjaArmour.NinjaId)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(ninjaArmour);
            //        _context.SaveChanges();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!NinjaArmourExists(ninjaArmour.NinjaId))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["ArmourId"] = new SelectList(_context.Armour, "Id", "Name", ninjaArmour.ArmourId);
            //ViewData["NinjaId"] = new SelectList(_context.Ninja, "Id", "Name", ninjaArmour.NinjaId);
            //return View(ninjaArmour);
        }

        // GET: Shop/Delete/5
        public IActionResult Delete(int? id)
        {
            throw new NotImplementedException();

            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var ninjaArmour =  _context.NinjaArmour
            //    .Include(n => n.Armour)
            //    .Include(n => n.Ninja)
            //    .FirstOrDefault(m => m.NinjaId == id);
            //if (ninjaArmour == null)
            //{
            //    return NotFound();
            //}

            //return View(ninjaArmour);
        }

        // POST: Shop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            throw new NotImplementedException();

            //var ninjaArmour = _context.NinjaArmour.Find(id);
            //_context.NinjaArmour.Remove(ninjaArmour);
            //_context.SaveChanges();
            //return RedirectToAction(nameof(Index));
        }

        //private bool NinjaArmourExists(int id)
        //{
        //    return _context.NinjaArmour.Any(e => e.NinjaId == id);
        //}
    }
}
