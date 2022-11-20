namespace WoWItems.API.Models.ItemToSlotType.Weapon
{
    public class WeaponDto
    {
        public WeaponType weaponType { get; set; }
        public int maxDmg { get; set; }
        public int minDmg { get; set; }
        public int dmgPreSecond { get; set; }
    }
}
