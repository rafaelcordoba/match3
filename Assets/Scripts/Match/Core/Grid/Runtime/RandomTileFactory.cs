using System;
using System.Linq;
using Game.Commons.Grid;
using Game.Commons.System.Random;
using Match.Core.Matching;
using Match.Core.Tiles;

namespace Match.Core.Grid
{
    public class RandomTileFactory : IRandomTileFactory
    {
        private const int MAX_ATTEMPTS = 100;
        
        private readonly IRandomAdapter _randomAdapter;
        private readonly IAvailableTilesRepository _availableTilesRepository;
        private readonly IMatcher _matcher;

        public RandomTileFactory(
            IRandomAdapter randomAdapter,
            IAvailableTilesRepository availableTilesRepository,
            IMatcher matcher)
        {
            _randomAdapter = randomAdapter;
            _availableTilesRepository = availableTilesRepository;
            _matcher = matcher;
        }

        public Tile Create(GridPosition gridPosition)
        {
            var attempts = 0;
            var randomTile = CreateRandomTile(gridPosition);

            while (HasMatchAround(randomTile) && 
                   attempts < MAX_ATTEMPTS)
            {
                randomTile = CreateRandomTile(gridPosition);
                attempts++;
            }

            return randomTile;
        }

        private bool HasMatchAround(Tile origin)
        {
            return _matcher.Get(origin).Count > 0;
        }

        private Tile CreateRandomTile(GridPosition gridPosition)
        {
            return new Tile
            {
                TileType = GetRandomType(),
                GridPosition = gridPosition
            };
        }

        private TileType GetRandomType()
        {
            var tiles = _availableTilesRepository.Get().ToList();
            var randomIndex = _randomAdapter.Next(tiles.Count);
            return tiles[randomIndex];
        }
    }
}