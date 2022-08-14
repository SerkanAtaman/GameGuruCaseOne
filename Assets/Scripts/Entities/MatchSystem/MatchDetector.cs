using System.Collections.Generic;
using GuruCaseOne.Entities.Tiles;
using GuruCaseOne.Helpers;

namespace GuruCaseOne.Entities.MatchSystem
{
    public class MatchDetector
    {
        private readonly HashSet<TileMono> _matchTiles;

        public MatchDetector()
        {
            _matchTiles = new HashSet<TileMono>();
        }

        public void CheckPossibleMatch(TileMono tileMono)
        {
            bool isMatched = false;

            CheckHorizontalMatches(tileMono);
            if (_matchTiles.Count >= 2)
            {
                isMatched = true;
                foreach (var item in _matchTiles)
                {
                    item.ChangeTileType(TileType.Default);
                }
            }
            CheckVerticalMatches(tileMono);
            if (_matchTiles.Count >= 2)
            {
                isMatched = true;
                foreach (var item in _matchTiles)
                {
                    item.ChangeTileType(TileType.Default);
                }
            }

            if (isMatched)
                tileMono.ChangeTileType(TileType.Default);
        }

        private void CheckHorizontalMatches(TileMono tileMono)
        {
            _matchTiles.Clear();
            CheckDirection(tileMono, Directions.Right);
            CheckDirection(tileMono, Directions.Left);
        }

        private void CheckVerticalMatches(TileMono tileMono)
        {
            _matchTiles.Clear();
            CheckDirection(tileMono, Directions.Top);
            CheckDirection(tileMono, Directions.Bottom);
        }

        private void CheckDirection(TileMono tile, Directions direction)
        {
            TileMono currentTile = tile;
            while (currentTile.NeighborController.IsMatched(direction))
            {
                currentTile = currentTile.NeighborController.GetNeighbor(direction);
                _matchTiles.Add(currentTile);
            }
        }
    }
}