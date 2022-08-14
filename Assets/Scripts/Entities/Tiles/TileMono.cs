using UnityEngine;
using GuruCaseOne.Helpers;
using GuruCaseOne.Interfaces;
using GuruCaseOne.Entities.Base;
using System;

namespace GuruCaseOne.Entities.Tiles
{
    public class TileMono : MonoBehaviour, IInteractable
    {
        [SerializeField] private SpriteRenderer _renderer = null;

        public BaseTile BaseTile { get; private set; }
        public TileNeighborController NeighborController { get; private set; }

        public Vector2Int Coordinates { get; private set; }

        public void Init(TileType tileType)
        {
            BaseTile = TileHelper.GetBaseTile(tileType);
            NeighborController = new TileNeighborController(this);
        }

        public void SetCoordinates(int x, int y)
        {
            Coordinates = new Vector2Int(x, y);
        }

        public void FindNeighbors()
        {
            NeighborController.FindNeighbors();
        }

        public void Interact(TileMono tileMono = null, Action<TileMono> callback = null)
        {
            BaseTile.Interact(this, callback);
        }

        public bool IsMatchableWith(TileMono tileMono)
        {
            return tileMono.BaseTile.GetTileType() == BaseTile.GetTileType();
        }

        public void ChangeTileType(TileType type)
        {
            BaseTile = TileHelper.GetBaseTile(type);
            ChangeTileSprite(type);
        }

        private void ChangeTileSprite(TileType type)
        {
            _renderer.sprite = PlayReferences.Instance.GameAsset.TileSprites[(int)type];
        }
    }
}