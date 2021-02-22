namespace IIoWParser
{
    public class IslandSlot
    {
        Item block { get; set; }
        Item attachment { get; set; }
        string keybind { get; set; }

        public IslandSlot(Item block, Item attachment, string keybind)
        {
            this.block = block;
            this.attachment = attachment;
            this.keybind = keybind;
        }

        public IslandSlot(Item block, Item attachment)
        {
            this.block = block;
            this.attachment = attachment;
        }

        public IslandSlot(Item block)
        {
            this.block = block;
        }

        public IslandSlot(){}
    }
}