using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace IIoWParser
{
    public class Property
    {
        public static string[] itemPropNameArray = JsonSerializer.Deserialize<string[]>(File.ReadAllText("./names/item_properties.json"));
        public static string[] projPropNameArray = JsonSerializer.Deserialize<string[]>(File.ReadAllText("./names/projectile_properties.json"));
        internal Property() { }
        public static Property Parse(string propertyString)
        {
            int seperatorIndex = propertyString.IndexOf(':');

            // Property ID and layer
            string id = null;
            int layer = 0;

            // Top layer int ID
            if (propertyString[0] == '·')
            {
                id = Property.itemPropNameArray[int.Parse(propertyString.Substring(1, seperatorIndex - 1))];
                layer = 0;
            }
            // Top layer string ID
            else if (propertyString[0] == '°')
            {
                id = propertyString.Substring(1, seperatorIndex - 1);
                layer = 0;
            }
            // Sub layer int ID
            else if (propertyString[0] == '¤')
            {

                for (int i = 1; i < propertyString.Length; i++)
                {
                    if (propertyString[i] != '¤')
                    {
                        id = Property.projPropNameArray[int.Parse(propertyString.Substring(i, seperatorIndex - i))];
                        layer = i - 1;
                        break;
                    }
                }
            }
            // Sub layer string ID
            else
            {
                for (int i = 1; i < propertyString.Length; i++)
                {
                    if (propertyString[i] != 'º')
                    {
                        id = propertyString.Substring(i, seperatorIndex - i);
                        layer = i - 1;
                        break;
                    }
                }
            }

            // Property value
            string stringValue = propertyString.Substring(seperatorIndex + 1);

            // List value
            if (stringValue[0] == '¬')
            {
                List<string> stringValueList = new List<string>(stringValue.Substring(1).Split('ǁ', StringSplitOptions.RemoveEmptyEntries));
                List<float> floatValueList = new List<float>();

                for (int i = 0; i < stringValueList.Count; i++)
                {
                    if (float.TryParse(stringValueList[i], out float floatValue))
                    {
                        floatValueList.Add(floatValue);
                    }
                    else
                    {
                        return new Property<List<string>>(id, stringValueList, layer);
                    }
                }

                return new Property<List<float>>(id, floatValueList, layer);
            }
            // Float value
            else if (float.TryParse(stringValue, out float floatValue))
            {
                return new Property<float>(id, floatValue, layer);
            }
            // String value
            else
            {
                return new Property<string>(id, stringValue, layer);
            }
        }
    }
    public class Property<T> : Property
    {
        public string id { get; set; }
        public T value { get; set; }
        public int layer { get; set; }

        public Property(string id, T value, int layer)
        {
            this.id = id;
            this.value = value;
            this.layer = layer;
        }
    }
}