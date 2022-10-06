using System.Collections.Generic;
using System.Linq;
using Match.Core.Tiles.Configuration;

namespace Match.Core.Tiles
{
    public class AvailableTilesRepository : IAvailableTilesRepository
    {
        private readonly ITilesConfiguration _configuration;

        public AvailableTilesRepository(ITilesConfiguration configuration)
            => _configuration = configuration;

        public IEnumerable<TileColor> Get()
            => _configuration.TilePrefabs.Select(c => c.color);
    }
}