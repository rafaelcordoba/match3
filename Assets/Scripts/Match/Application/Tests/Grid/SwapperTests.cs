using System.Threading.Tasks;
using Commons.Runtime.Grid;
using FluentAssertions;
using Match.Application.Gameplay;
using Match.Application.Gameplay.Board;
using NSubstitute;
using NUnit.Framework;

namespace Match.Application.Tests.Grid
{
    [TestFixture]
    public class SwapperTests
    {
        private IBoardPresenter _boardPresenter;

        [SetUp]
        public void SetUp()
        {
            _boardPresenter = Substitute.For<IBoardPresenter>();
        }

        [Test]
        public async Task Swapping_Vertically()
        {
            var grid = new GameGrid<Tile>();
            grid.Init(1, 2, 1);
            var origin = CreateTile(grid, 0, 0, TileType.Red);
            var target = CreateTile(grid, 0, 1, TileType.Green);
            var swapper = new Swapper(grid, _boardPresenter);
            
            await swapper.SwapAsync(origin, target);

            grid.GetItem(new GridPosition(0, 0)).TileType.Should().Be(TileType.Green);
            grid.GetItem(new GridPosition(0, 1)).TileType.Should().Be(TileType.Red);
        }
        
        [Test]
        public async Task Swapping_Horizontally()
        {
            var grid = new GameGrid<Tile>();
            grid.Init(2, 1, 1);
            var origin = CreateTile(grid, 0, 0, TileType.Red);
            var target = CreateTile(grid, 1, 0, TileType.Green);
            var swapper = new Swapper(grid, _boardPresenter);
            
            await swapper.SwapAsync(origin, target);

            grid.GetItem(new GridPosition(0, 0)).TileType.Should().Be(TileType.Green);
            grid.GetItem(new GridPosition(1, 0)).TileType.Should().Be(TileType.Red);
        }

        [Test] 
        public async Task Swapping_Diagonally()
        {
            var grid = new GameGrid<Tile>();
            grid.Init(2, 2, 1);
            var origin = CreateTile(grid, 0, 0, TileType.Red);
            var target = CreateTile(grid, 1, 1, TileType.Green);
            CreateTile(grid, 0, 1, TileType.Blue);
            CreateTile(grid, 1, 0, TileType.Yellow);
            var swapper = new Swapper(grid, _boardPresenter);
            
            await swapper.SwapAsync(origin, target);

            //swapped tiles
            grid.GetItem(new GridPosition(0, 0)).TileType.Should().Be(TileType.Green);
            grid.GetItem(new GridPosition(1, 1)).TileType.Should().Be(TileType.Red);
            
            // untouched tiles
            grid.GetItem(new GridPosition(0, 1)).TileType.Should().Be(TileType.Blue);
            grid.GetItem(new GridPosition(1, 0)).TileType.Should().Be(TileType.Yellow);
        }
        
        [Test] 
        public async Task Swapping_With_More_Than_One_Tile_Far()
        {
            var grid = new GameGrid<Tile>();
            grid.Init(3, 1, 1);
            var origin = CreateTile(grid, 0, 0, TileType.Red);
            CreateTile(grid, 1, 0, TileType.Blue);
            var target = CreateTile(grid, 2, 0, TileType.Green);
            var swapper = new Swapper(grid, _boardPresenter);
            
            await swapper.SwapAsync(origin, target);

            //swapped tiles
            grid.GetItem(new GridPosition(0, 0)).TileType.Should().Be(TileType.Green);
            grid.GetItem(new GridPosition(2, 0)).TileType.Should().Be(TileType.Red);
            
            // untouched tiles
            grid.GetItem(new GridPosition(1, 0)).TileType.Should().Be(TileType.Blue);
        }
        
        private static Tile CreateTile(GameGrid<Tile> grid, uint x, uint y, TileType tileType)
        {
            var tile = new Tile { TileType = tileType, GridPosition = new GridPosition(x, y) };
            grid.SetItem(new GridPosition(x, y), tile);
            return tile;
        }
    }
}