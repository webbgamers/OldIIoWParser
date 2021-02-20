namespace IIoWParser
{
    public class IntProperty : Property
    {
        public int value { get; set; }

        public IntProperty(string id, int value, int layer)
        {
            this.id = id;
            this.value = value;
            this.layer = layer;
        }
    }
}