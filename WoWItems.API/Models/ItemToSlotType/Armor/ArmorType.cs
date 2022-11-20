namespace WoWItems.API.Models.ItemToSlotType.Armor
{
    public enum ArmorType
    {
        Cloth, //head,shoulders,chest,wrists,hands,waist,boots (all other types has same slots)
        Leather,
        Mail,
        Plate,
        Miscellaneous, //neck,finger,trinket,back(normaly counted as cloth)
        Shield,
        OffHand
    }
}