using System;
using System.Collections.Generic;

namespace IIoWParser
{
    class Island
    {
        public int coreX;
        public int coreY;
        public int islandWidth;
        public int islandHeight;
        public int islandOffsetX;
        public int islandOffsetY;
        public IslandSlot[,] island = new IslandSlot[12,12];
    
        public Island(int coreX, int coreY, int islandWidth, int islandHeight, int islandOffsetX, int islandOffsetY, IslandSlot[,] island)
        {
            this.coreX = coreX;
            this.coreY = coreY;
            this.islandWidth = islandWidth;
            this.islandHeight = islandHeight;
            this.islandOffsetX = islandOffsetX;
            this.islandOffsetY = islandOffsetY;
            this.island = island;
        }

        public Island(IslandSlot[,] island)
        {
            // TODO calculate values

            this.island = island;
        }

        public static Island Parse(string inputString)
        {
            List<string> inputList = new List<string>(inputString.Split(' ', StringSplitOptions.RemoveEmptyEntries));

            IslandSlot[,] island = new IslandSlot[12,12];

            int currentSlot = 0;
            int i = 0;
            while (i < inputList.Count)
            {
                // Skip empty slots
                if (int.TryParse(inputList[i], out int skipAmount))
                {
                    currentSlot += skipAmount;
                    i++;
                }
                // Parse and populate filled slots
                else
                {
                    IslandSlot islandSlot = IslandSlot.Parse(inputList[i], inputList[i+1], inputList[i+2]);
                    island[(currentSlot / 12), (currentSlot % 12)] = islandSlot;
                    Console.WriteLine("test");
                    i += 3;
                }
            }

            return new Island(island);
        }
    }
}