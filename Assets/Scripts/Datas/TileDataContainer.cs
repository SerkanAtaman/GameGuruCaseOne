using GuruCaseOne.Helpers;

namespace GuruCaseOne.Datas
{
    public class TileDataContainer
    {
        public int Row = -1;
        public int Column = -1;

        public TileType TileType;

        public TileDataContainer(int x, int y, TileType tileType)
        {
            Row = x;
            Column = y;
            TileType = tileType;
        }
    }
}