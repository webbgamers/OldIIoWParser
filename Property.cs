namespace IIoWParser
{
    public class Property
    {
        public string id { get; set; }
        public dynamic value { get; set; }
        public int layer { get; set; }

        public Property(string id, dynamic value, int layer)
        {
            this.id = id;
            this.value = value;
            this.layer = layer;
        }
    }
}