using GuruCaseOne.Entities.Tiles;
using GuruCaseOne.Interfaces;
using GuruCaseOne.Helpers;
using System;

namespace GuruCaseOne.Entities
{
    public class InteractAbility : IInteractable
    {
        private readonly TileType _tileType;

        public InteractAbility(TileType tileType)
        {
            _tileType = tileType;
        }

        public void Interact(TileMono tileMono = null, Action<TileMono> callback = null)
        {
            switch (_tileType)
            {
                case TileType.Default:
                    callback.Invoke(tileMono);
                    break;
                case TileType.Marked:
                    break;
            }
        }
    }
}