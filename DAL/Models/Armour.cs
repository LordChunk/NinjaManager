using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Armour
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Price { get; set; }
        public ArmourEnum ArmourType { get; set; }
    }
}
