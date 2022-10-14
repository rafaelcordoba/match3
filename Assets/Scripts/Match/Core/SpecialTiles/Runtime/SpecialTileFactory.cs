using System.Linq;
using Game.Commons.Grid;
using Match.Core.SpecialTiles.Runtime.Configuration;
using Match.Core.Tiles;

namespace Match.Core.SpecialTiles.Runtime
{
    public class SpecialTileFactory
    {
        private readonly ISpecialTilesConfiguration _configuration;

        public SpecialTileFactory(ISpecialTilesConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public SpecialTile Create(
            GridPosition gridPosition, 
            TileColor tileColor, 
            int tilesDestroyed)
        {
            var specialTileConfiguration = _configuration.Configurations
                .FirstOrDefault(configuration => configuration.TilesDestroyedRequired <= tilesDestroyed);

            if (specialTileConfiguration == null)
                return null;

            return new SpecialTile
            {
                Configuration = specialTileConfiguration,
                TileColor = tileColor,
                GridPosition = gridPosition
            };
        }
    }
}