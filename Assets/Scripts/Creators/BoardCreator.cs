using GuruCaseOne.Datas;
using GuruCaseOne.Helpers;

namespace GuruCaseOne.Creators
{
    public class BoardCreator
    {
        private readonly TileCreator _tileCreator;

        private TileDataContainer[,] _tileDataContainers;

        public BoardCreator()
        {
            _tileCreator = new TileCreator();
        }

        public void CreateBoard()
        {
            int boarzSize = PlayReferences.Instance.BoardData.Size;

            SetTileData(boarzSize);
            for (int i = 0; i < boarzSize; i++)
            {
                for (int j = 0; j < boarzSize; j++)
                {
                    _tileCreator.CreateTile(_tileDataContainers[i, j]);
                }
            }
        }

        private void SetTileData(int n)
        {
            _tileDataContainers = new TileDataContainer[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    _tileDataContainers[i, j] = new TileDataContainer(i, j, TileType.Default);
                }
            }
        }
    }
}