using GuruCaseOne.Helpers;
using GuruCaseOne.Entities.Tiles;

namespace GuruCaseOne.Entities.Base
{
    public abstract class BaseTile
    {
        public TileType TileType { get; protected set; }

        public abstract TileType GetTileType();

        public virtual void Interact(TileMono tileMono = null)
        {

        }
    }
}