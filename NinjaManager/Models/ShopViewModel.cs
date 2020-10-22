using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NinjaManager.Models
{
    public class ShopViewModel
    {
        [Display(Name = "Selected ninja")]
        public Ninja SelectedNinja { get; set; }

        public IEnumerable<Armour> BuyAbleArmour { get; set; }
    }
}
