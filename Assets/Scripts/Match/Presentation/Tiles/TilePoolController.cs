using System;
using System.Collections.Generic;
using Commons.Runtime.System.Collections.Generic;
using Match.Application.Gameplay.Board;
using Match.Presentation.Tiles.Configuration;
using UnityEngine;

namespace Match.Presentation.Tiles
{
    public class TilePoolController : ITilePoolController
    {
        private readonly ITileViewFactory _tileViewFactory;
        private readonly ITilesConfiguration _tilesConfiguration;
        private readonly CustomStack<TileType, ITileView> _customStack = new();
        private readonly Dictionary<TileType, Transform> _poolContainers = new();

        public TilePoolController(ITileViewFactory tileViewFactory, ITilesConfiguration tilesConfiguration)
        {
            _tileViewFactory = tileViewFactory;
            _tilesConfiguration = tilesConfiguration;
        }

        public void InitializePool(TileType tileType)
        {
            ValidateStack(tileType);
            var poolTransform = new GameObject($"Pool Container {tileType}").transform;
            _poolContainers.Add(tileType, poolTransform);
            for (var i = 0; i < _tilesConfiguration.PoolSize; i++)
            {
                CreateAndPushView(tileType);
            }
        }

        public ITileView Get(TileType tileType)
        {
            if (_customStack.Count(tileType) < 1)
                _customStack.Push(tileType, _tileViewFactory.Create(tileType, _poolContainers[tileType]));
            return _customStack.Pop(tileType);
        }

        public void Return(ITileView tileView)
        {
            tileView.SetParent(_poolContainers[tileView.Tile.TileType]);
            _customStack.Push(tileView.Tile.TileType, tileView);
        }

        private void CreateAndPushView(TileType tileType)
        {
            var tileView = _tileViewFactory.Create(tileType, _poolContainers[tileType]);
            _customStack.Push(tileType, tileView);
        }

        private void ValidateStack(TileType tileType)
        {
            if (_customStack.Count(tileType) > 0)
                throw new Exception($"Pool already initialized: {tileType}");
        }
    }
}