using System;
using System.Collections.Generic;
using Game.Commons.System.Collections.Generic;
using Match.Core.Tiles.Configuration;
using Match.Core.Tiles.UI;
using UnityEngine;

namespace Match.Core.Tiles
{
    public class TilePoolController : ITilePoolController
    {
        private readonly ITileViewFactory _tileViewFactory;
        private readonly ITilesConfiguration _tilesConfiguration;
        private readonly CustomStack<TileColor, ITileView> _customStack = new();
        private readonly Dictionary<TileColor, Transform> _poolContainers = new();

        public TilePoolController(ITileViewFactory tileViewFactory, ITilesConfiguration tilesConfiguration)
        {
            _tileViewFactory = tileViewFactory;
            _tilesConfiguration = tilesConfiguration;
        }

        public void InitializePool(TileColor tileColor)
        {
            ValidateStack(tileColor);
            var poolTransform = new GameObject($"Pool Container {tileColor}").transform;
            _poolContainers.Add(tileColor, poolTransform);
            for (var i = 0; i < _tilesConfiguration.PoolSize; i++)
            {
                CreateAndPushView(tileColor);
            }
        }

        public ITileView Get(TileColor tileColor)
        {
            if (_customStack.Count(tileColor) < 1)
                _customStack.Push(tileColor, _tileViewFactory.Create(tileColor, _poolContainers[tileColor]));
            return _customStack.Pop(tileColor);
        }

        public void Return(ITileView tileView)
        {
            tileView.SetParent(_poolContainers[tileView.Tile.TileColor]);
            _customStack.Push(tileView.Tile.TileColor, tileView);
        }

        private void CreateAndPushView(TileColor tileColor)
        {
            var tileView = _tileViewFactory.Create(tileColor, _poolContainers[tileColor]);
            _customStack.Push(tileColor, tileView);
        }

        private void ValidateStack(TileColor tileColor)
        {
            if (_customStack.Count(tileColor) > 0)
                throw new Exception($"Pool already initialized: {tileColor}");
        }
    }
}