using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Armour : ModelBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Strength { get; set; }
        [Required]
        public int Agility { get; set; }
        [Required]
        public int Intelligence { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public ArmourEnum ArmourType { get; set; }
        
        public virtual ICollection<NinjaArmour> UsedBy { get; set; }
    }
}
