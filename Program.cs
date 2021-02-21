using System;
using System.Collections.Generic;

namespace IIoWParser
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Property> propertyList = new List<Property>();
            propertyList.Add(new Property("value", 195, 0));
            propertyList.Add(new Property("mass", 240, 0));
            propertyList.Add(new Property("warpmassuse", 8, 0));
            propertyList.Add(new Property("critchance", 0.2f, 0));
            propertyList.Add(new Property("damage", new List<int>() { 190, 24 }, 0));
            propertyList.Add(new Property("range", 500, 1));
            propertyList.Add(new Property("damagepenetration", 5, 1));
            propertyList.Add(new Property("damagepenetration", 3, 2));
            Item item = new Item("crystacle", 147, 450, 240, 2, false, propertyList);
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}
