namespace IIoWParser
{
    public class Property
    {
        public string id { get; set; }
        public object value { get; set; }
        public int layer { get; set; }

        public Property(string id, object value, int layer)
        {
            this.id = id;
            this.value = value;
            this.layer = layer;
        }
    }
}