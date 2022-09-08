using Game.Commons.VContainer;
using Match.Core.Grid.Configuration;
using UnityEngine;
using VContainer;

namespace Match.Core.Grid.VContainer
{
    public class GridInstaller : Installer
    {
        [SerializeField] private GridConfiguration _configuration;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration).AsImplementedInterfaces();
            builder.Register<GridInitializer>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<RandomTileFactory>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}