using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.Models;

namespace NinjaManager.Models
{
    public class ShopViewModel
    {
        [Display(Name = "Selected ninja")]
        public Ninja SelectedNinja { get; set; }

        public IEnumerable<Armour> BuyAbleArmour { get; set; }
    }
}
