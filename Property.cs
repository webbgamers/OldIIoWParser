using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace IIoWParser
{
    public class Property
    {
        public static readonly string[] ItemPropNameArray = JsonSerializer.Deserialize<string[]>(File.ReadAllText("./names/item_properties.json"));
        public static readonly string[] ProjPropNameArray = JsonSerializer.Deserialize<string[]>(File.ReadAllText("./names/projectile_properties.json"));
        internal Property() { }
        public static Property Parse(string propertyString)
        {
            int separatorIndex = propertyString.IndexOf(':');

            // Property ID and layer
            string id = null;
            int layer = 0;

            switch (propertyString[0])
            {
                // Top layer int ID
                case '·':
                    id = Property.ItemPropNameArray[int.Parse(propertyString.Substring(1, separatorIndex - 1))];
                    layer = 0;
                    break;
                // Top layer string ID
                case '°':
                    id = propertyString.Substring(1, separatorIndex - 1);
                    layer = 0;
                    break;
                // Sub layer int ID
                case '¤':
                {
                    for (int i = 1; i < propertyString.Length; i++)
                    {
                        if (propertyString[i] == '¤') continue;
                        id = Property.ProjPropNameArray[int.Parse(propertyString.Substring(i, separatorIndex - i))];
                        layer = i - 1;
                        break;
                    }

                    break;
                }
                // Sub layer string ID
                default:
                {
                    for (int i = 1; i < propertyString.Length; i++)
                    {
                        if (propertyString[i] == 'º') continue;
                        id = propertyString.Substring(i, separatorIndex - i);
                        layer = i - 1;
                        break;
                    }

                    break;
                }
            }

            // Property value
            string stringValue = propertyString.Substring(separatorIndex + 1);

            // List value
            if (stringValue[0] == '¬')
            {
                List<string> stringValueList = new List<string>(stringValue.Substring(1).Split('ǁ', StringSplitOptions.RemoveEmptyEntries));
                List<float> floatValueList = new List<float>();

                foreach (string s in stringValueList)
                {
                    if (float.TryParse(s, out float floatValue))
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
        public string Id { get; set; }
        public T Value { get; set; }
        public int Layer { get; set; }

        public Property(string id, T value, int layer)
        {
            this.Id = id;
            this.Value = value;
            this.Layer = layer;
        }
    }
}