using System.Collections.Generic;

namespace Match.Core.Tiles
{
    public interface IAvailableTilesRepository
    {
        IEnumerable<TileColor> Get();
    }
}