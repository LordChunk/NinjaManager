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
        private readonly NinjaRepository ninjaRepository;
        public NinjasController(NinjaManagerContext context) : base(context)
        {
            ninjaRepository = new NinjaRepository(context);
        }

        public override IActionResult Details(int id)
        {
            var ninja = ninjaRepository.GetDetailed(id);
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
