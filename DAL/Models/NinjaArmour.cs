namespace DAL.Models
{
    public class NinjaArmour
    {
        public int NinjaId { get; set; }
        public int ArmourId { get; set; }
        public Ninja Ninja { get; set; }
        public Armour Armour { get; set; } }
}