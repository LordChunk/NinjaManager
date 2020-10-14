using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Ninja : ModelBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Gold { get; set; }

        public virtual ICollection<NinjaArmour> EquippedArmour { get; set; }

    }
}