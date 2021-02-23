using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace IIoWParser
{
    public class Item
    {
        public static string[] itemNameArray = JsonSerializer.Deserialize<string[]>(File.ReadAllText("./names/items.json"));
        public string id { get; set; }
        public float xp { get; set; }
        public float xpTotal { get; set; }
        public float xpNext { get; set; }
        public int tier { get; set; }
        public bool damaged { get; set; }
        public List<Property> properties { get; set; }

        public Item(string id, float xp, float xpTotal, float xpNext, int tier, bool damaged, List<Property> properties)
        {
            this.id = id;
            this.xp = xp;
            this.xpTotal = xpTotal;
            this.xpNext = xpNext;
            this.tier = tier;
            this.damaged = damaged;
            this.properties = properties;
        }

        public static Item Parse(string itemString)
        {
            // Null '_' checking
            if (itemString == "_")
                return null;

            List<string> inputList = new List<string>(itemString.Split('|', System.StringSplitOptions.RemoveEmptyEntries));
            
            // ID parsing
            string id;
            if (inputList[0][0] == '§')
                id = Item.itemNameArray[int.Parse(inputList[0].Substring(1))];
            else
                id = inputList[0].Substring(1);

            // XP parsing
            float xp = float.Parse(inputList[1]);

            // XP Total parsing
            float xpTotal = float.Parse(inputList[2]);
            
            // XP Next parsing
            float xpNext = float.Parse(inputList[3]);

            // Tier parsing
            int tier = int.Parse(inputList[4]);

            // Damaged parsing
            bool damaged = false;
            if (inputList[5] == "1")
                damaged = true;
            
            // Property parsing
            List<Property> properties = new List<Property>();
            for (int i = 6; i < inputList.Count; i++)
            {
                properties.Add(Property.Parse(inputList[i]));
            }

            return new Item(id, xp, xpTotal, xpNext, tier, damaged, properties);
        }
    }
}