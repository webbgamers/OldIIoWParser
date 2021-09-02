namespace IIoWParser
{
    public class IslandSlot
    {
        Item Block { get; set; }
        Item Attachment { get; set; }
        string KeyBind { get; set; }

        public IslandSlot(Item block, Item attachment, string keyBind)
        {
            this.Block = block;
            this.Attachment = attachment;
            this.KeyBind = keyBind;
        }

        public static IslandSlot Parse(string blockString, string attachmentString, string keyBindString)
        {
            Item block = Item.Parse(blockString);
            Item attachment = Item.Parse(attachmentString);

            string keyBind = null;
            if (keyBindString != "_")
                keyBind = keyBindString;
            
            return new IslandSlot(block, attachment, keyBind);
        }
    }
}