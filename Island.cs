using System;
using System.Collections.Generic;

namespace IIoWParser
{
    class Island
    {
        public int CoreX;
        public int CoreY;
        public int IslandWidth;
        public int IslandHeight;
        public int IslandOffsetX;
        public int IslandOffsetY;
        public readonly IslandSlot[,] IslandArray;
    
        public Island(int coreX, int coreY, int islandWidth, int islandHeight, int islandOffsetX, int islandOffsetY, IslandSlot[,] islandArray)
        {
            this.CoreX = coreX;
            this.CoreY = coreY;
            this.IslandWidth = islandWidth;
            this.IslandHeight = islandHeight;
            this.IslandOffsetX = islandOffsetX;
            this.IslandOffsetY = islandOffsetY;
            this.IslandArray = islandArray;
        }

        public Island(IslandSlot[,] islandArray)
        {
            // TODO calculate values

            this.IslandArray = islandArray;
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
                    island[(currentSlot % 12), (currentSlot / 12)] = islandSlot;
                    Console.WriteLine("test");

                    currentSlot++;
                    i += 3;
                }
            }

            return new Island(island);
        }
    }
}