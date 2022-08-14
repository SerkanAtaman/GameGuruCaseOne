using GuruCaseOne.Entities.Tiles;
using System;

namespace GuruCaseOne.Interfaces
{
    public interface IInteractable
    {
        public void Interact(TileMono tileMono = null, Action<TileMono> callback = null);
    }
}