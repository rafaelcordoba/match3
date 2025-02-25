using System.Collections.Generic;

namespace Match.Application.Gameplay.Board
{
    public interface ITileTypeRepository
    {
        IEnumerable<TileType> Get();
    }
}