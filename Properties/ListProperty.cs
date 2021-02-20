using System.Collections.Generic;

namespace IIoWParser
{
    public class ListProperty<T> : Property
    {
        List<T> value { get; set; }

        public ListProperty(string id, List<T> value, int layer)
        {
            this.id = id;
            this.value = value;
            this.layer = layer;
        }
    }
}