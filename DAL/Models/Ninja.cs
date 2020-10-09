using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DAL.Models
{
    public class Ninja : ModelBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Gold { get; set; }

        public virtual ICollection<NinjaArmour> EquippedArmour { get; set; }

        public void SetArmour(Armour armour)
        {
            // Dit kan nie https://github.com/avans-prg5/SuperSushi/blob/master/SuperSushi.Data/MenuRepositorySql.cs#L54
            // moet waarschijnlijk in repo voor ninja 
            
            // Finds all items that are not of the current armour type (i.e. if adding helmet it removes all helmets from the list)
            //var newArmourList = EquippedArmour.Where(currentArmour => currentArmour.Armour.ArmourType != armour.ArmourType).ToList();
            
            //newArmourList.Add(armour);

            //EquippedArmour = newArmourList;
        }
    }
}