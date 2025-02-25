using System;
using Match.Application.Gameplay.Board;

namespace Match.Presentation.Tiles.Configuration
{
    [Serializable]
    public class TileGraphicPrefab
    {
        public TileType Type;
        public GraphicView Graphic;
    }
}