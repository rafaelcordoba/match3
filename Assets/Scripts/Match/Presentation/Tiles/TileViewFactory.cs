using Match.Application.Gameplay.Board;
using UnityEngine;

namespace Match.Presentation.Tiles
{
    public class TileViewFactory : ITileViewFactory
    {
        private readonly ITileGraphicsProvider _graphicsProvider;
        private readonly TileView _prefab;

        public TileViewFactory(ITileGraphicsProvider graphicsProvider)
        {
            _graphicsProvider = graphicsProvider;
            _prefab = _graphicsProvider.GetTileViewPrefab();
        }
        
        public ITileView Create(TileType tileType, Transform parent)
        {
            var tileView = Object.Instantiate(_prefab, parent);
            tileView.SetActive(false);
            var graphicPrefab = _graphicsProvider.GetGraphicPrefab(tileType);
            tileView.GraphicView = Object.Instantiate(graphicPrefab, tileView.transform); 
            return tileView;
        }
    }
}