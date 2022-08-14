using GuruCaseOne.Entities.Tiles;

namespace GuruCaseOne.Helpers
{
    public static class NeighborHelper
    {
        public static TileMono GetNeighbor(Directions direction, TileMono tileMono)
        {
            switch (direction)
            {
                case Directions.Default:
                    return tileMono;
                case Directions.Right:
                    return tileMono.Coordinates.x == PlayReferences.Instance.BoardData.Size - 1 ?
                       null : PlayReferences.Instance.BoardData.GetTile(tileMono.Coordinates.x + 1, tileMono.Coordinates.y);
                case Directions.Top:
                    return tileMono.Coordinates.y == PlayReferences.Instance.BoardData.Size - 1 ?
                 null : PlayReferences.Instance.BoardData.GetTile(tileMono.Coordinates.x, tileMono.Coordinates.y + 1);
                case Directions.Left:
                    return tileMono.Coordinates.x == 0 ?
                             null : PlayReferences.Instance.BoardData.GetTile(tileMono.Coordinates.x - 1, tileMono.Coordinates.y);
                case Directions.Bottom:
                    return tileMono.Coordinates.y == 0 ?
                              null : PlayReferences.Instance.BoardData.GetTile(tileMono.Coordinates.x, tileMono.Coordinates.y - 1);
            }
            return null;
        }
    }
}