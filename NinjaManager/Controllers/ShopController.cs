using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Data;
using DAL.Models;
using NinjaManager.Models;

namespace NinjaManager.Controllers
{
    public class ShopController : Controller
    {
        private readonly NinjaArmourRepository _ninjaArmourRepository;
        private readonly NinjaRepository _ninjaRepository;
        private readonly RepositoryBase<Armour> _armourRepository;
        private ShopViewModel shopViewModel;

        public ShopController(NinjaManagerContext context)
        {
            _ninjaArmourRepository = new NinjaArmourRepository(context);
            _ninjaRepository = new NinjaRepository(context);
            _armourRepository = new RepositoryBase<Armour>(context);
            shopViewModel = new ShopViewModel();
        }

        [HttpGet]
        public IActionResult Index(int ninjaId)
        {
            shopViewModel.SelectedNinja = _ninjaRepository.GetDetailed(ninjaId);
            shopViewModel.BuyAbleArmour = _armourRepository.Get();

            var equippedArmour = shopViewModel.SelectedNinja.EquippedArmour.Select(na => na.Armour);

            shopViewModel.BuyAbleArmour = shopViewModel.BuyAbleArmour.Where(a => !equippedArmour.Contains(a));
            return View(shopViewModel);
        }

        [HttpPost]
        public IActionResult BuyArmour(int ninjaId, int armourId)
        {

            return View("Index",shopViewModel);
        }
    }
}
