using GuruCaseOne.Entities.Base;
using GuruCaseOne.Entities.Tiles;
using GuruCaseOne.Helpers;

namespace GuruCaseOne.Entities.Classes
{
    public class DefaultTile : BaseTile
    {
        public DefaultTile()
        {
            TileType = TileType.Default;
        }

        public override TileType GetTileType()
        {
            return TileType;
        }

        public override void Interact(TileMono tileMono = null)
        {
            tileMono.ChangeTileType(TileType.Marked);
        }
    }
}