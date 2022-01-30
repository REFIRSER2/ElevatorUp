using UnityEngine;

namespace RF.Map
{
    public class Map
    {
        public int mapWidth = 3, mapHeight = 3;
        public int gridSizeX = 1, gridSizeY = 1;

        private Grid[,] grids;

        public void Setup()
        {
            grids = new Grid[mapWidth/gridSizeX-1, mapHeight/gridSizeY-1];

            Debug.Log(mapWidth/ gridSizeX);
            
            for (int i = 0; i < mapWidth / gridSizeX - 1; i++)
            {
                for (int k = 0; k < mapHeight / gridSizeY - 1; k++)
                {
                    Grid grid = new Grid();
                    // ReSharper disable once PossibleLossOfFraction
                    grid.pos = new Vector3((float)(i*gridSizeX)/2,0, (float)(k*gridSizeY)/2);
                    grids[i, k] = grid;
                }
            }    
        }

        public Grid[,] GetGrids()
        {
            return grids;
        }
    }
}
