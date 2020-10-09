using System.Collections;

namespace DAL.Models
{
    public class Ninja : ModelBase
    {
        public string Name { get; set; }
        public int Gold { get; set; }
        public Armour Head { get; set; }
        public Armour Necklace { get; set; }
        public Armour Hand { get; set; }
        public Armour Chest { get; set; }
        public Armour Ring { get; set; }
        public Armour Feet { get; set; }

        public void SetArmour(Armour armour)
        {
            switch (armour.ArmourType)
            {
                case ArmourEnum.Head:
                    this.Head = armour;
                    break;
                case ArmourEnum.Chest:
                    this.Chest = armour;
                    break;
                case ArmourEnum.Feet:
                    this.Feet = armour;
                    break;
                case ArmourEnum.Hands:
                    this.Hand = armour;
                    break;
                case ArmourEnum.Necklace:
                    this.Necklace = armour;
                    break;
                case ArmourEnum.Ring:
                    this.Ring = armour;
                    break;
            }
        }
    }
}