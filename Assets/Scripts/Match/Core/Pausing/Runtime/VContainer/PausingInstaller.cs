using Game.Commons.VContainer;
using Match.Core.Pausing.UI.Button;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Match.Core.Pausing.VContainer
{
    public class PausingInstaller : Installer
    {
        [SerializeField] private PauseButtonView _pauseButtonView;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(_pauseButtonView).AsImplementedInterfaces();
            builder.Register<PauseController>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.RegisterEntryPoint<PauseButtonPresenter>();
        }
    }
}