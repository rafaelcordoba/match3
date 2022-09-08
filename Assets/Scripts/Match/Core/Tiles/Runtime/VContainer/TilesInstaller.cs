using Game.Commons.Grid;
using Game.Commons.VContainer;
using Match.Core.Tiles.Configuration;
using Match.Core.Tiles.UI;
using UnityEngine;
using VContainer;

namespace Match.Core.Tiles.VContainer
{
    public class TilesInstaller : Installer
    {
        [SerializeField] private TilesConfiguration _configuration;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration).As<ITilesConfiguration>();

            builder.Register<TileGraphicsProvider>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<TilePoolController>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<TileViewFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<AvailableTilesRepository>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<Grid<Tile>>(Lifetime.Singleton).As<IGrid<Tile>>();
        }
    }
}