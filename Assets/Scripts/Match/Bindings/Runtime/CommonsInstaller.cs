using Game.Commons.Camera;
using Game.Commons.Input.Swipe;
using Game.Commons.Input.Touch;
using Game.Commons.System.Random;
using Game.Commons.UI;
using Game.Commons.UI.Configuration;
using Game.Commons.Unity;
using Game.Commons.VContainer;
using UnityEngine;
using VContainer;

namespace Match.Bindings
{
    public class CommonsInstaller : Installer
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private UIRoot _uiRoot;
        [SerializeField] private PopupsConfiguration _popupsConfiguration;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(new CameraAdapter(_camera)).AsImplementedInterfaces();
            builder.RegisterInstance(_uiRoot).AsImplementedInterfaces();
            builder.RegisterInstance(_popupsConfiguration).AsImplementedInterfaces();
            
            builder.Register<RandomAdapterAdapter>(Lifetime.Transient).AsImplementedInterfaces();
            builder.Register<UnityObjectAdapter>(Lifetime.Transient).AsImplementedInterfaces();
            builder.Register<TouchInputController>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<SwipeDetector>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<SwipeConditionChecker>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<SwipeDirectionFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<UIViewFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<UIController>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}