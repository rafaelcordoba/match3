using Game.Commons.VContainer;
using Match.Core.Leaderboard.Repository;
using Match.Core.Leaderboard.UI;
using Match.Core.Leaderboard.UI.ChangeName;
using UnityEngine;
using VContainer;

namespace Match.Core.Leaderboard.VContainer
{
    public class LeaderboardInstaller : Installer
    {
        [SerializeField] private LeaderboardDefaultData leaderboardDefaultData;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(leaderboardDefaultData).AsImplementedInterfaces();
            builder.Register<LeaderboardPlayerPrefsRepository>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<LeaderboardController>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<LeaderboardPopupPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<ChangeNamePopupPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}