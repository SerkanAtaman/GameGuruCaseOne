using GuruCaseOne.Helpers;
using GuruCaseOne.Entities.Base;

namespace GuruCaseOne.Entities.Classes
{
    public class MarkedTile : BaseTile
    {
        public MarkedTile()
        {
            TileType = TileType.Marked;
        }

        public override TileType GetTileType()
        {
            return TileType;
        }
    }
}