using FluentAssertions;
using Game.Commons.Grid;
using Match.Core.Tiles;
using NSubstitute;
using NUnit.Framework;

namespace Match.Core.Grid.Tests
{
    [TestFixture]
    public class GridRefillerTests
    {
        private GridRefiller _refiller;
        private IGrid<Tile> _grid;
        private IRandomTileFactory _randomTileFactory;
        private static Tile _yellow;
        private static Tile _green;

        [SetUp]
        public void SetUp()
        {
            _yellow = new Tile { TileType = TileType.Yellow };
            _green = new Tile { TileType = TileType.Green };
            _grid = CreateFakeGrid();
            _randomTileFactory = Substitute.For<IRandomTileFactory>();
            _refiller = new GridRefiller(_grid, _randomTileFactory);
        }

        [Test]
        public void Refill_WithGreenTiles_UpdatesGridWithGreen()
        {
            _randomTileFactory.Create(Arg.Any<GridPosition>()).Returns(_green);
            
            _refiller.Refill();

            _grid.GetItem(new GridPosition(0, 0)).Should().Be(_yellow);
            _grid.GetItem(new GridPosition(0, 1)).Should().Be(_green);
            _grid.GetItem(new GridPosition(1, 0)).Should().Be(_green);
            _grid.GetItem(new GridPosition(1, 1)).Should().Be(_yellow);
        }
        
        [Test]
        public void Refill_MarksTilesRefilled()
        {
            _randomTileFactory.Create(Arg.Any<GridPosition>()).Returns(_green);
            
            _refiller.Refill();

            _grid.GetItem(new GridPosition(0, 0)).Refilled.Should().Be(false);
            _grid.GetItem(new GridPosition(0, 1)).Refilled.Should().Be(true);
            _grid.GetItem(new GridPosition(1, 0)).Refilled.Should().Be(true);
            _grid.GetItem(new GridPosition(1, 1)).Refilled.Should().Be(false);
        }

        private static GameGrid<Tile> CreateFakeGrid()
        {
            var grid = new GameGrid<Tile>();
            grid.Init(2, 2, 1);
            grid.SetItem(new GridPosition(0, 0), _yellow);
            grid.SetItem(new GridPosition(0, 1), null);
            grid.SetItem(new GridPosition(1, 0), null);
            grid.SetItem(new GridPosition(1, 1), _yellow);
            return grid;
        }
    }
}