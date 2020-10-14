using DAL.Data;
using DAL.Models;

namespace NinjaManager.Controllers
{
    public class ArmourController : CrudMvcControllerBase<Armour>
    {

        // ReSharper disable once SuggestBaseTypeForParameter
        public ArmourController(NinjaManagerContext context) : base(context)
        {
        }
    }
}
