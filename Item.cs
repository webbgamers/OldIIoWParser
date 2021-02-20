using System.Collections.Generic;

namespace IIoWParser
{
    public class Item
    {
        public string id { get; set; }
        public int xp { get; set; }
        public int xpTotal { get; set; }
        public int xpNext { get; set; }
        public int tier { get; set; }
        public bool damaged { get; set; }
        public List<Property> properties { get; set; }

        public Item(string itemId, int itemXp, int itemXpTotal, int itemXpNext, int itemTier, bool itemDamaged, List<Property> itemProperties)
        {
            id = itemId;
            xp = itemXp;
            xpTotal = itemXpTotal;
            xpNext = itemXpNext;
            tier = itemTier;
            damaged = itemDamaged;
            properties = itemProperties;
        }
    }
}