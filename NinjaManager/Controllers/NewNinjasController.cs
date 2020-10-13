using DAL.Data;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace NinjaManager.Controllers
{
    public class NewNinjasController : CrudMvcControllerBase<Ninja>
    {
        // ReSharper disable once SuggestBaseTypeForParameter
        public NewNinjasController(NinjaManagerContext context) : base(context)
        {
        }
    }
}
