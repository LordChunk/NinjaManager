using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Armour
    {
        public int Strength { get; set; }
        private int Agility { get; set; }
        private int Intelligence { get; set; }
        private ArmourEnum ArmourType { get; set; }
    }
}
