using Commons.Runtime.Grid;
using FluentAssertions;
using Match.Application.Gameplay.Board;
using NSubstitute;
using NUnit.Framework;

namespace Match.Application.Tests.Grid
{
    public class GridInitializerTests
    {
        private IGridConfiguration _gridConfiguration;
        private INoMatchAroundTileFactory _noMatchAroundTileFactory;
        private IGrid<Tile> _grid;
        private static Tile _yellow;
        private static Tile _green;
        private GridInitializer _gridInitializer;

        [SetUp]
        public void SetUp()
        {
            _gridConfiguration = Substitute.For<IGridConfiguration>();
            _noMatchAroundTileFactory = Substitute.For<INoMatchAroundTileFactory>();
            _grid = CreateFakeGrid();
            _gridInitializer = new GridInitializer(_gridConfiguration, _noMatchAroundTileFactory, _grid);
        }

        [Test]
        public void Initialize_SetsCorrectTilesToGrid()
        {
            _noMatchAroundTileFactory.Create(new GridPosition(0, 0)).Returns(_green);
            _noMatchAroundTileFactory.Create(new GridPosition(0, 1)).Returns(_green);
            _noMatchAroundTileFactory.Create(new GridPosition(1, 0)).Returns(_yellow);
            _noMatchAroundTileFactory.Create(new GridPosition(1, 1)).Returns(_yellow);
            
            _gridInitializer.Initialize();

            _grid.GetItem(new GridPosition(0, 0)).Should().Be(_green);
            _grid.GetItem(new GridPosition(0, 1)).Should().Be(_green);
            _grid.GetItem(new GridPosition(1, 0)).Should().Be(_yellow);
            _grid.GetItem(new GridPosition(1, 1)).Should().Be(_yellow);
        }
        
        private static GameGrid<Tile> CreateFakeGrid()
        {
            var grid = new GameGrid<Tile>();
            grid.Init(2, 2, 1);
            return grid;
        }
    }
}