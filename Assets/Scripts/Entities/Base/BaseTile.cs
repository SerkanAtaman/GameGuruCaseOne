using GuruCaseOne.Helpers;
using GuruCaseOne.Entities.Tiles;
using GuruCaseOne.Interfaces;
using System;

namespace GuruCaseOne.Entities.Base
{
    public abstract class BaseTile : IInteractable
    {
        public TileType TileType { get; protected set; }

        public abstract TileType GetTileType();

        protected IInteractable interactAbility;

        public virtual void Interact(TileMono tileMono = null, Action<TileMono> callback = null)
        {

        }
    }
}