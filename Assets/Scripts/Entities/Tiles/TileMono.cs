using UnityEngine;
using GuruCaseOne.Helpers;

namespace GuruCaseOne.Entities.Tiles
{
    public class TileMono : MonoBehaviour
    {
        public Vector2Int Coordinates { get; private set; }

        public void Init(TileType tileType)
        {
            
        }

        public void SetCoordinates(int x, int y)
        {
            Coordinates = new Vector2Int(x, y);
        }
    }
}