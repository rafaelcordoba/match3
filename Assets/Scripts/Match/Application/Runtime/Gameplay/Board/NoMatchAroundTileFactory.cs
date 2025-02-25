using System.Collections.Generic;
using System.Linq;
using Commons.Runtime.Grid;
using Commons.Runtime.System.Random;
using Match.Application.Gameplay.Board.Matching;

namespace Match.Application.Gameplay.Board
{
    public class NoMatchAroundTileFactory : INoMatchAroundTileFactory
    {
        private readonly IRandomAdapter _randomAdapter;
        private readonly ITileTypeRepository _tileTypeRepository;
        private readonly IMatcher _matcher;

        public NoMatchAroundTileFactory(
            IRandomAdapter randomAdapter,
            ITileTypeRepository tileTypeRepository,
            IMatcher matcher)
        {
            _randomAdapter = randomAdapter;
            _tileTypeRepository = tileTypeRepository;
            _matcher = matcher;
        }

        public Tile Create(GridPosition gridPosition)
        {
            List<TileType> excludedTypes = new();
            var randomTile = CreateRandomTile(gridPosition, excludedTypes);

            while (randomTile != null && HasMatchAround(randomTile))
            {
                excludedTypes.Add(randomTile.TileType);
                randomTile = CreateRandomTile(gridPosition, excludedTypes);
            }

            // if we can't find a tile with no match around, return any random tile
            return randomTile ?? CreateRandomTile(gridPosition, new List<TileType>());
        }

        private bool HasMatchAround(Tile origin)
            => _matcher.Get(origin).Count > 0;

        private Tile CreateRandomTile(GridPosition gridPosition, List<TileType> excludedTypes)
        {
            var randomType = GetRandomType(excludedTypes);
            if (randomType == null)
                return null;
            
            return new Tile
            {
                TileType = (TileType)randomType,
                GridPosition = gridPosition
            };
        }

        private TileType? GetRandomType(List<TileType> excludedTypes)
        {
            var tiles = _tileTypeRepository.Get().ToList();
            tiles.RemoveAll(excludedTypes.Contains);
            
            if (tiles.Count == 0)
                return null;
            
            var randomIndex = _randomAdapter.Next(tiles.Count);
            return tiles[randomIndex];
        }
    }
}