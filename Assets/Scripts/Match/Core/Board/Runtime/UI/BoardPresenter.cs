using System.Collections.Generic;
using System.Linq;
using Game.Commons.Grid;
using Match.Core.Grid.Configuration;
using Match.Core.Tiles;
using Match.Core.Tiles.UI;
using UnityEngine;

namespace Match.Core.Board.UI
{
    public class BoardPresenter
    {
        private readonly IGrid<Tile> _grid;
        private readonly IGridConfiguration _gridConfiguration;
        private readonly ITilePoolController _pool;
        private readonly List<ITileView> _tileViews = new();
        private readonly GameObject _tilesContainer;

        public BoardPresenter(
            IGrid<Tile> grid, 
            IGridConfiguration gridConfiguration, 
            ITilePoolController pool)
        {
            _grid = grid;
            _gridConfiguration = gridConfiguration;
            _pool = pool;
            _tilesContainer = new GameObject("Tiles Container");
        }

        public void CreateTiles()
        {
            for (uint x = 0; x < _grid.Width; x++)
            for (uint y = 0; y < _grid.Height; y++)
            {
                var gridPosition = new GridPosition(x, y);
                var tileView = CreateTileView(gridPosition);
                tileView.SetLocalPosition(gridPosition);
            }
        }

        private ITileView CreateTileView(GridPosition gridPosition)
        {
            var tile = _grid.GetItem(gridPosition);
            var tileView = _pool.Get(tile.TileColor);
            tileView.Tile = tile;
            tileView.PoolController = _pool;
            tileView.SetTileSize(_gridConfiguration.TileSize);
            tileView.SetParent(_tilesContainer.transform);
            tileView.SetActive(true);
            tileView.SetState(TileViewState.Alive);
            _tileViews.Add(tileView);
            return tileView;
        }

        public void Refill()
        {
            for (uint x = 0; x < _grid.Width; x++)
            for (uint y = 0; y < _grid.Height; y++)
            {
                var gridPosition = new GridPosition(x, y);
                var tile = _grid.GetItem(gridPosition);
                
                if (!tile.Refilled) 
                    continue;
                
                var tileView = CreateTileView(tile.GridPosition);
                var gridPositionTop = new GridPosition(gridPosition.X, _grid.Height);
                tileView.SetLocalPosition(gridPositionTop);
                tile.Refilled = false;
            }
        }

        public void ClearBoard()
        {
            foreach (var tileView in _tileViews.Where(v => v.Tile != null))
                tileView.Tile.Destroyed = true;

            _tileViews.Clear();
        }
    }
}