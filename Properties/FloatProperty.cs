namespace IIoWParser
{
    public class FloatProperty : Property
    {
        public float value { get; set; }

        public FloatProperty(string id, float value, int layer)
        {
            this.id = id;
            this.value = value;
            this.layer = layer;
        }
    }
}