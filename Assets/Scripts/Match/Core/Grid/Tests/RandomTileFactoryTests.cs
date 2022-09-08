using System.Collections.Generic;
using FluentAssertions;
using Game.Commons.Grid;
using Game.Commons.System.Random;
using Match.Core.Matching;
using Match.Core.Tiles;
using NSubstitute;
using NUnit.Framework;

namespace Match.Core.Grid.Tests
{
    [TestFixture]
    public class RandomTileFactoryTests
    {
        private const int RED_INDEX = 0;
        private const int GREEN_INDEX = 1;
        private RandomTileFactory _randomTileFactory;
        private IRandomAdapter _randomAdapter;
        private IAvailableTilesRepository _availableTilesRepository;
        private IMatcher _matcher;

        [SetUp]
        public void SetUp()
        {
            _randomAdapter = Substitute.For<IRandomAdapter>();
            
            _availableTilesRepository = Substitute.For<IAvailableTilesRepository>();
            _availableTilesRepository.Get().Returns(new List<TileType> { TileType.Red, TileType.Green });
            
            _matcher = Substitute.For<IMatcher>();
            _matcher.Get(Arg.Any<Tile>()).Returns(Substitute.For<IReadOnlyList<Tile>>());
                
            _randomTileFactory = new RandomTileFactory(_randomAdapter, _availableTilesRepository, _matcher);
        }

        [Test]
        public void Create_WithRandomRed_ReturnsRedTile()
        {
            var gridPosition = new GridPosition(1, 1);
            _randomAdapter.Next(Arg.Any<int>()).Returns(RED_INDEX);

            var result = _randomTileFactory.Create(gridPosition);

            result.TileType.Should().Be(TileType.Red);
            result.GridPosition.Should().BeEquivalentTo(gridPosition);
        }
        
        [Test]
        public void Create_WithRandomGreen_ReturnsGreenTile()
        {
            var gridPosition = new GridPosition(1, 1);
            _randomAdapter.Next(Arg.Any<int>()).Returns(GREEN_INDEX);

            var result = _randomTileFactory.Create(gridPosition);

            result.TileType.Should().Be(TileType.Green);
            result.GridPosition.Should().BeEquivalentTo(gridPosition);
        }
    }
}