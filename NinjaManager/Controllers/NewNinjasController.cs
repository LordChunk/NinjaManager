using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace NinjaManager.Controllers
{
    public class NewNinjasController : CrudMvcControllerBase<Ninja>
    {
        public NewNinjasController(NinjaManagerContext context) : base(context)
        {
        }

        public override IActionResult Create([Bind("Name,Gold,Id")] Ninja model) => base.Create(model);

        public override IActionResult Edit(int id, [Bind("Name,Gold,Id")] Ninja model) => base.Edit(id, model);
    }
}
