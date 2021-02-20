namespace IIoWParser
{
    public class StringProperty : Property
    {
        public string value { get; set; }

        public StringProperty(string id, string value, int layer)
        {
            this.id = id;
            this.value = value;
            this.layer = layer;
        }
    }
}