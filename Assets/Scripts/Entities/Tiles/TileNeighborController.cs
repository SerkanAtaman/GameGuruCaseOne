using System.Collections.Generic;
using GuruCaseOne.Helpers;

namespace GuruCaseOne.Entities.Tiles
{
    public class TileNeighborController
    {
        private readonly TileMono _dependedTileMono;

        private readonly Dictionary<Directions, TileMono> _neighbors;

        public TileNeighborController(TileMono dependedTile)
        {
            _dependedTileMono = dependedTile;

            _neighbors = new Dictionary<Directions, TileMono>
            {
                {Directions.Default, null},
                {Directions.Right, null},
                {Directions.Left, null},
                {Directions.Top, null},
                {Directions.Bottom, null},
            };
        }

        public void FindNeighbors()
        {
            for (int i = 0; i < _neighbors.Count; i++)
            {
                _neighbors[(Directions)i] = NeighborHelper.GetNeighbor((Directions)i, _dependedTileMono);
            }
        }

        public TileMono GetNeighbor(Directions direction)
        {
            return _neighbors[direction];
        }

        public bool IsMatched(Directions direction)
        {
            TileMono neighbor = GetNeighbor(direction);
            if (neighbor == null) return false;

            return _dependedTileMono.IsMatchableWith(neighbor);
        }
    }
}