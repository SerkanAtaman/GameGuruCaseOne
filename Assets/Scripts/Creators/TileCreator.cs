using GuruCaseOne.Datas;
using GuruCaseOne.Entities.Tiles;
using UnityEngine;

namespace GuruCaseOne.Creators
{
    public class TileCreator
    {
        public void CreateTile(TileDataContainer tileDataContainer)
        {
            int x = tileDataContainer.Row;
            int y = tileDataContainer.Column;

            GameObject tileObject = Object.Instantiate(PlayReferences.Instance.GameAsset.TileMonoPref, new Vector3(x, y, 0), Quaternion.identity, PlayReferences.Instance.BoardHolder);
            tileObject.name = $"[{x},{y}]";

            TileMono tileMono = tileObject.GetComponent<TileMono>();
            tileMono.Init(tileDataContainer.TileType);
            tileMono.SetCoordinates(x, y);
            PlayReferences.Instance.BoardData.UpdateTile(x, y, tileMono);
        }
    }
}