using DAL.Data;
using DAL.Models;

namespace NinjaManager.Controllers
{
    public class NinjasController : CrudMvcControllerBase<Ninja>
    {
        // ReSharper disable once SuggestBaseTypeForParameter
        public NinjasController(NinjaManagerContext context) : base(context)
        {
        }
    }
}
