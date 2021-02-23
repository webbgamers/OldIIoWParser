using System;
using System.Collections.Generic;

namespace IIoWParser
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Property> propertyList = new List<Property>();
            propertyList.Add(new Property<int>("value", 195, 0));
            propertyList.Add(new Property<int>("mass", 240, 0));
            propertyList.Add(new Property<int>("warpmassuse", 8, 0));
            propertyList.Add(new Property<float>("critchance", 0.2f, 0));
            propertyList.Add(new Property<List<int>>("damage", new List<int>() { 190, 24 }, 0));
            propertyList.Add(new Property<int>("range", 500, 1));
            propertyList.Add(new Property<int>("damagepenetration", 5, 1));
            propertyList.Add(new Property<int>("damagepenetration", 3, 2));
            Item item = new Item("crystacle", 147, 450, 240, 2, false, propertyList);
            Island island = Island.Parse("41 |§0|0|14.46|28.93|1|0|·18:16|·19:24|·20:9| _ _ 11 |§2|0|0|14.64|0|0| _ _ |§0|0|14.46|28.93|1|0|·18:16|·19:24|·20:9| _ _ 10 |§3|0|0|16.32|0|0| |§46|0|0|100|0|0| _ |§2|0|14.64|29.28|1|0|·18:16|·19:30|·20:13| |§110|0|15|30|1|0|·18:17|·21:7|·65:0.15|·66:¬24?| 1 |§0|0|14.46|28.93|1|0|·18:16|·19:24|·20:9| _ _ 9 |§3|0|0|16.32|0|0| |§47|0|15|30|1|0|·18:17|·26:0.07|·46:576| W |§2|0|14.64|29.28|1|0|·18:16|·19:30|·20:13| |§54|0|15|30|1|0|·18:17|·26:0.07|·47:216| AD |§0|0|14.46|28.93|1|0|·18:16|·19:24|·20:9| _ _ 9 |§2|0|0|14.64|0|0| |§110|0|15|30|1|0|·18:17|·21:7|·65:0.15|·66:¬24?| 1 |§0|0|14.46|28.93|1|0|·18:16|·19:24|·20:9| _ _ 10 |§0|0|14.46|28.93|1|0|·18:16|·19:24|·20:9| _ _ 42 ");
            Console.WriteLine("Press any key to exit.");
            for (int y = 0; y < 12; y++)
            {
                string printString = "";
                for (int x = 0; x < 12; x++)
                {
                    if (island.island[y,x] == null)
                        printString += " ";
                    else
                        printString += "X";
                }
                Console.WriteLine(printString);
            }
            Console.ReadLine();
        }
    }
}
