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

        public Item(string id, int xp, int xpTotal, int xpNext, int tier, bool damaged, List<Property> properties)
        {
            this.id = id;
            this.xp = xp;
            this.xpTotal = xpTotal;
            this.xpNext = xpNext;
            this.tier = tier;
            this.damaged = damaged;
            this.properties = properties;
        }
    }
}