using Game.Commons.VContainer;
using VContainer;

namespace Match.Core.PlayAgain.VContainer
{
    public class PlayAgainInstaller : Installer
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<PlayAgainController>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}