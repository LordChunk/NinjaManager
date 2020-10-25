using DAL;
using DAL.Data;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using NinjaManager.Models;
using System.Linq;

namespace NinjaManager.Controllers
{
    public class NinjasController : CrudMvcControllerBase<Ninja>
    {
        private readonly NinjaRepository _ninjaRepository;
        public NinjasController(NinjaManagerContext context) : base(context)
        {
            _ninjaRepository = new NinjaRepository(context);
        }

        public override IActionResult Details(int id)
        {
            var ninja = _ninjaRepository.GetDetailed(id);
            var allArmour = ninja.EquippedArmour.Select(na => na.Armour).ToList();

            var ninjaModel = new NinjaViewModel
            {
                Name = ninja.Name,
                Id = ninja.Id,
                AllArmour = allArmour,
                Gold = ninja.Gold,

                TotalStrength = allArmour.Sum(armour => armour.Strength),
                TotalAgility = allArmour.Sum(armour => armour.Agility),
                TotalIntelligence = allArmour.Sum(armour => armour.Intelligence),
                TotalArmourValue = allArmour.Sum(armour => armour.Price),
            };

            return View(ninjaModel);
        }
    }
}
