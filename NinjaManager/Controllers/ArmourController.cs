using DAL;
using DAL.Data;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace NinjaManager.Controllers
{
    public class ArmourController : CrudMvcControllerBase<Armour>
    {
        private readonly NinjaRepository _ninjaRepository;
        private readonly NinjaArmourRepository _ninjaArmourRepository;
        private readonly RepositoryBase<Armour> _armourRepository;
        // ReSharper disable once SuggestBaseTypeForParameter
        public ArmourController(NinjaManagerContext context) : base(context)
        {
            _ninjaRepository = new NinjaRepository(context);
            _ninjaArmourRepository = new NinjaArmourRepository(context);
            _armourRepository = new RepositoryBase<Armour>(context);
        }


        public override IActionResult DeleteConfirmed(int id)
        {
            var ninjaHasArmour = _ninjaArmourRepository.GetNinjaFromArmour(id);
            var armourValue = _armourRepository.Get(id).Price;

            foreach (var ninja in ninjaHasArmour)
            {
                ninja.Gold += armourValue;
                _ninjaRepository.Update(ninja);
            }
            _ninjaRepository.Save();

            return base.DeleteConfirmed(id);
        }
    }
}
