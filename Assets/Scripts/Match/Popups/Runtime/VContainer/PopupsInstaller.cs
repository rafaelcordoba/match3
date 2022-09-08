using Game.Commons.VContainer;
using VContainer;

namespace Match.Popups.VContainer
{
    public class PopupsInstaller : Installer
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<PopupController>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}