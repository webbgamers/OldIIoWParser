namespace IIoWParser
{
    class Player
    {
        int coreX;
        int coreY;
        int islandWidth;
        int islandHeight;
        int islandOffsetX;
        int islandOffsetY;
        IslandSlot[,] island = new IslandSlot[12,12];
    }
}