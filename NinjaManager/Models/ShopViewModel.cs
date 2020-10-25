using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL;
using DAL.Models;

namespace NinjaManager.Models
{
    public class ShopViewModel
    {
        [Display(Name = "Selected ninja")]
        public Ninja SelectedNinja { get; set; }

        public ArmourEnum SelectedArmour { get; set; }

        public IEnumerable<Armour> BuyAbleArmour { get; set; }
    }
}
