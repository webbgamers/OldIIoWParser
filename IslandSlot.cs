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

        public static IslandSlot Parse(string blockString, string attachmentString, string keybindString)
        {
            Item block = Item.Parse(blockString);
            Item attachment = Item.Parse(attachmentString);
            
            return new IslandSlot(block, attachment, keybindString);
        }
    }
}