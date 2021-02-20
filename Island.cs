namespace IIoWParser
{
    class Island
    {
        int coreX;
        int coreY;
        int islandWidth;
        int islandHeight;
        int islandOffsetX;
        int islandOffsetY;
        IslandSlot[,] island = new IslandSlot[12,12];
    
        public Island(string importString)
        {
            this.Import(importString);
        }

        public void Import(string importString)
        {
            
        }
    }
}