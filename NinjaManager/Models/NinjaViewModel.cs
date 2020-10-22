using DAL.Models;
using System.Collections.Generic;

namespace NinjaManager.Models
{
    public class NinjaViewModel : Ninja
    {
        public List<Armour> AllArmour;
        public int TotalStrength;
        public int TotalAgility;
        public int TotalIntelligence;
        public int TotalArmourValue;
    }
}
