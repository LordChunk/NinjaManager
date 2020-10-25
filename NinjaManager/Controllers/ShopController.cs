using System.Linq;
using DAL;
using Microsoft.AspNetCore.Mvc;
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

        public ShopController(NinjaManagerContext context)
        {
            _ninjaArmourRepository = new NinjaArmourRepository(context);
            _ninjaRepository = new NinjaRepository(context);
            _armourRepository = new RepositoryBase<Armour>(context);
        }

        [HttpGet]
        public IActionResult Index(int ninjaId, int ?selectedArmour)
        {
            var shopViewModel = new ShopViewModel
            {
                SelectedNinja = _ninjaRepository.GetDetailed(ninjaId),
                BuyAbleArmour = _armourRepository.Get()
            };

            if (selectedArmour != null)
            {
                shopViewModel.SelectedArmour = selectedArmour switch
                {
                    0 => ArmourEnum.Head,
                    1 => ArmourEnum.Necklace,
                    2 => ArmourEnum.Hands,
                    3 => ArmourEnum.Chest,
                    4 => ArmourEnum.Feet,
                    5 => ArmourEnum.Ring,
                    _ => shopViewModel.SelectedArmour
                };
            }

            var equippedArmour = shopViewModel.SelectedNinja.EquippedArmour.Select(na => na.Armour);

            shopViewModel.BuyAbleArmour = shopViewModel.BuyAbleArmour.Where(a => !equippedArmour.Contains(a));

            if (selectedArmour != null) shopViewModel.BuyAbleArmour = shopViewModel.BuyAbleArmour.Where(a => a.ArmourType == shopViewModel.SelectedArmour);

            return View(shopViewModel);
        }

        public IActionResult BuyArmour([FromRoute]int id, int ninjaId)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var selectedNinja = _ninjaRepository.GetDetailed(ninjaId);

            var justBoughtArmour = _armourRepository.Get(id);

            var equippedArmour = selectedNinja.EquippedArmour.Select(na => na.Armour);

            foreach (var armour in equippedArmour)
            {
                if (armour.ArmourType == justBoughtArmour.ArmourType)
                {
                    selectedNinja.Gold += armour.Price;
                    _ninjaRepository.Update(selectedNinja);
                    _ninjaArmourRepository.Delete(new NinjaArmour
                    {
                        ArmourId = armour.Id,
                        NinjaId = ninjaId,
                        Ninja = selectedNinja,
                        Armour = armour,
                    });
                    _ninjaArmourRepository.Save();
                    _ninjaRepository.Save();
                    break;
                }
            }

            _ninjaArmourRepository.Add(new NinjaArmour
            {
                ArmourId = justBoughtArmour.Id,
                NinjaId = selectedNinja.Id
            });

            selectedNinja.Gold = selectedNinja.Gold - justBoughtArmour.Price;
            _ninjaRepository.Update(selectedNinja);

            _ninjaArmourRepository.Save();
            _ninjaRepository.Save();
            return RedirectToAction(nameof(Index), new { ninjaId = ninjaId });
        }

        public IActionResult SellArmour([FromRoute] int id, int ninjaId)
        {
            DeleteNinjaArmour(ninjaId, id);

            return RedirectToAction(nameof(Index), new { ninjaId = ninjaId });
        }

        private void DeleteNinjaArmour(int ninjaId, int armourId)
        {
            _ninjaArmourRepository.Delete(new NinjaArmour
            {
                ArmourId = armourId,
                NinjaId = ninjaId,
            });
            _ninjaArmourRepository.Save();

            var ninja = _ninjaRepository.Get(ninjaId);
            ninja.Gold += _armourRepository.Get(armourId).Price;

            _ninjaRepository.Update(ninja);
            _ninjaRepository.Save();
        }
    }
}
