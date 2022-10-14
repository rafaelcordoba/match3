using System;
using Match.Core.Tiles.UI;
using UnityEngine.Serialization;

namespace Match.Core.Tiles.Configuration
{
    [Serializable]
    public class TileGraphicPrefab
    {
        public TileColor color;
        public GraphicView Graphic;
    }
}