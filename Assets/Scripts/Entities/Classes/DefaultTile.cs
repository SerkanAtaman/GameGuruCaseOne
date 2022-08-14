using GuruCaseOne.Entities.Base;
using GuruCaseOne.Entities.Tiles;
using GuruCaseOne.Helpers;
using System;

namespace GuruCaseOne.Entities.Classes
{
    public class DefaultTile : BaseTile
    {
        public DefaultTile()
        {
            TileType = TileType.Default;
            interactAbility = new InteractAbility(TileType);
        }

        public override TileType GetTileType()
        {
            return TileType;
        }

        public override void Interact(TileMono tileMono = null, Action<TileMono> callback = null)
        {
            tileMono.ChangeTileType(TileType.Marked);
            interactAbility.Interact(tileMono, callback);
        }
    }
}