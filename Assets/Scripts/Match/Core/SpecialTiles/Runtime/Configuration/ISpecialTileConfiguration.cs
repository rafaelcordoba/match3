using System.Collections.Generic;
using Match.Core.Tiles;

namespace Match.Core.SpecialTiles.Runtime.Configuration
{
    public interface ISpecialTileConfiguration
    {
        int HorizontalExplosion { get; set; }
        int VerticaExplosion { get; set; }
        int DiagonalExplosion { get; set; }
        List<TileColor> ColorExplosion { get; set; }
        int TilesDestroyedRequired { get; set; }
    }
}