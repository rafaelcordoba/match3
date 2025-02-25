using System.Collections.Generic;
using Commons.Runtime.Grid;
using Commons.Runtime.System.Random;
using FluentAssertions;
using Match.Application.Gameplay.Board;
using Match.Application.Gameplay.Board.Matching;
using NSubstitute;
using NUnit.Framework;

namespace Match.Application.Tests.Grid
{
    [TestFixture]
    public class NoMatchAroundTileFactoryTests
    {
        private const int RED_INDEX = 0;
        private const int GREEN_INDEX = 1;
        private NoMatchAroundTileFactory _noMatchAroundTileFactory;
        private IRandomAdapter _randomAdapter;
        private ITileTypeRepository _tileTypeRepository;
        private IMatcher _matcher;

        [SetUp]
        public void SetUp()
        {
            _randomAdapter = Substitute.For<IRandomAdapter>();
            
            _tileTypeRepository = Substitute.For<ITileTypeRepository>();
            _tileTypeRepository.Get().Returns(new List<TileType> { TileType.Red, TileType.Green });
            
            _matcher = Substitute.For<IMatcher>();
            _matcher.Get(Arg.Any<Tile>()).Returns(Substitute.For<IReadOnlyList<Tile>>());
                
            _noMatchAroundTileFactory = new NoMatchAroundTileFactory(_randomAdapter, _tileTypeRepository, _matcher);
        }

        [Test]
        public void Create_WithRandomRed_ReturnsRedTile()
        {
            var gridPosition = new GridPosition(1, 1);
            _randomAdapter.Next(Arg.Any<int>()).Returns(RED_INDEX);

            var result = _noMatchAroundTileFactory.Create(gridPosition);

            result.TileType.Should().Be(TileType.Red);
            result.GridPosition.Should().BeEquivalentTo(gridPosition);
        }
        
        [Test]
        public void Create_WithRandomGreen_ReturnsGreenTile()
        {
            var gridPosition = new GridPosition(1, 1);
            _randomAdapter.Next(Arg.Any<int>()).Returns(GREEN_INDEX);

            var result = _noMatchAroundTileFactory.Create(gridPosition);

            result.TileType.Should().Be(TileType.Green);
            result.GridPosition.Should().BeEquivalentTo(gridPosition);
        }
    }
}