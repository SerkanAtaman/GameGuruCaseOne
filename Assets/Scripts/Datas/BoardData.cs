using GuruCaseOne.Entities.Tiles;
using UnityEngine;

namespace GuruCaseOne.Datas
{
    public class BoardData
    {
        public int Size { get; private set; }

        private readonly TileMono[,] _tiles;

        public BoardData(int size)
        {
            Size = size;
            _tiles = new TileMono[Size, Size];
        }

        public TileMono GetTile(int x, int y)
        {
            if (x < 0 || x >= Size || y < 0 || y >= Size)
                return null;

            return _tiles[x, y];
        }

        public Vector3 GetTileWorldPos(int x, int y)
        {
            if (x < 0 || x >= Size || y < 0 || y >= Size)
                return Vector3.zero;

            return new Vector3(x, y, 0);
        }

        public Vector3 GetBottomLeftTilePos()
        {
            return new Vector3(0, 0, 0);
        }

        public Vector3 GetTopRightTilePos()
        {
            return new Vector3(Size - 1, Size - 1, 0);
        }

        public void UpdateTile(int x, int y, TileMono tile)
        {
            _tiles[x, y] = tile;
        }
    }
}