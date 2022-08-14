using GuruCaseOne.Entities.Base;
using GuruCaseOne.Entities.Classes;

namespace GuruCaseOne.Helpers
{
    public static class TileHelper
    {
        public static BaseTile GetBaseTile(TileType tileType)
        {
            switch (tileType)
            {
                case TileType.Default:
                    return new DefaultTile();
                case TileType.Marked:
                    return new MarkedTile();
            }
            return null;
        }
    }
}