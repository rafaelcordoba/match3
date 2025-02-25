using Commons.Runtime.Grid;
using Match.Application.Gameplay.Board;

namespace Match.Application.Gameplay
{
    public static class GameGridExtensions
    {
        public static GameGrid<Tile> Clone(this IGrid<Tile> original)
        {
            var clone = new GameGrid<Tile>();
            clone.Init(original.Width, original.Height, original.CellSize);

            for (uint x = 0; x < original.Width; x++)
            {
                for (uint y = 0; y < original.Height; y++)
                {
                    var originalTile = original.ItemsArray[x, y];
                    clone.SetItem(new GridPosition(x, y), originalTile.Clone());
                }
            }

            return clone;
        }
    }
}