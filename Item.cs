using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace IIoWParser
{
    public class Item
    {
        public static readonly string[] ItemNameArray = JsonSerializer.Deserialize<string[]>(File.ReadAllText("./names/items.json"));
        public string Id { get; set; }
        public float Xp { get; set; }
        public float XpTotal { get; set; }
        public float XpNext { get; set; }
        public int Tier { get; set; }
        public bool Damaged { get; set; }
        public List<Property> Properties { get; set; }

        public Item(string id, float xp, float xpTotal, float xpNext, int tier, bool damaged, List<Property> properties)
        {
            this.Id = id;
            this.Xp = xp;
            this.XpTotal = xpTotal;
            this.XpNext = xpNext;
            this.Tier = tier;
            this.Damaged = damaged;
            this.Properties = properties;
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
                id = Item.ItemNameArray[int.Parse(inputList[0].Substring(1))];
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
            bool damaged = inputList[5] == "1";

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