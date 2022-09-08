using FluentAssertions;
using Game.Commons.Grid;
using Match.Core.Grid.Configuration;
using Match.Core.Tiles;
using NSubstitute;
using NUnit.Framework;

namespace Match.Core.Grid.Tests
{
    public class GridInitializerTests
    {
        private IGridConfiguration _gridConfiguration;
        private IRandomTileFactory _randomTileFactory;
        private IGrid<Tile> _grid;
        private static Tile _yellow;
        private static Tile _green;
        private GridInitializer _gridInitializer;

        [SetUp]
        public void SetUp()
        {
            _gridConfiguration = Substitute.For<IGridConfiguration>();
            _randomTileFactory = Substitute.For<IRandomTileFactory>();
            _grid = CreateFakeGrid();
            _gridInitializer = new GridInitializer(_gridConfiguration, _randomTileFactory, _grid);
        }

        [Test]
        public void Initialize_SetsCorrectTilesToGrid()
        {
            _randomTileFactory.Create(new GridPosition(0, 0)).Returns(_green);
            _randomTileFactory.Create(new GridPosition(0, 1)).Returns(_green);
            _randomTileFactory.Create(new GridPosition(1, 0)).Returns(_yellow);
            _randomTileFactory.Create(new GridPosition(1, 1)).Returns(_yellow);
            
            _gridInitializer.Initialize();

            _grid.GetItem(new GridPosition(0, 0)).Should().Be(_green);
            _grid.GetItem(new GridPosition(0, 1)).Should().Be(_green);
            _grid.GetItem(new GridPosition(1, 0)).Should().Be(_yellow);
            _grid.GetItem(new GridPosition(1, 1)).Should().Be(_yellow);
        }
        
        private static Grid<Tile> CreateFakeGrid()
        {
            var grid = new Grid<Tile>();
            grid.Init(2, 2, 1);
            return grid;
        }
    }
}