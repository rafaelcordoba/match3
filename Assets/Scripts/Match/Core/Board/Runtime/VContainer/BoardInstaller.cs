using Game.Commons.VContainer;
using Match.Core.Board.Switcher;
using Match.Core.Board.UI;
using Match.Core.Grid;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Match.Core.Board.VContainer
{
    public class BoardInstaller : Installer
    {
        [SerializeField] private BoardFlowController _boardFlowController;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterComponent(_boardFlowController).AsImplementedInterfaces();
           
            builder.Register<BoardPresenter>(Lifetime.Singleton);
            builder.Register<TileSwitcher>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<GridRefiller>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<EndGameController>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.RegisterEntryPoint<GameBootstrap>();
            builder.RegisterEntryPoint<PlayerInputListener>();
        }
    }
}