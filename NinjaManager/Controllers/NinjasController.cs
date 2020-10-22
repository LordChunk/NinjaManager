using DAL;
using DAL.Data;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NinjaManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace NinjaManager.Controllers
{
    public class NinjasController : CrudMvcControllerBase<Ninja>
    {
        // ReSharper disable once SuggestBaseTypeForParameter
        private readonly RepositoryBase<Armour> armourRepository;
        private readonly NinjaManagerContext _context;
        public NinjasController(NinjaManagerContext context) : base(context)
        {
            _context = context;
        }

        public override IActionResult Details(int id)
        {
            var ninja = _context.Ninja.Include(n => n.EquippedArmour).ThenInclude(na => na.Armour).FirstOrDefault(n => n.Id == id);
            var AllArmour = ninja.EquippedArmour.Select(na => na.Armour).ToList();

            var ninjaModel = new NinjaViewModel
            {
                Name = ninja.Name,
                Id = ninja.Id,
                AllArmour = AllArmour,

                TotalStrength = AllArmour.Sum(armour => armour.Strength),
                TotalAgility = AllArmour.Sum(armour => armour.Agility),
                TotalIntelligence = AllArmour.Sum(armour => armour.Intelligence),
                TotalArmourValue = AllArmour.Sum(armour => armour.Price),
            };

            return View(ninjaModel);
        }
    }
}
