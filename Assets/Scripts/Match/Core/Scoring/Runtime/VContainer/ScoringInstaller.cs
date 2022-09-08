using Game.Commons.VContainer;
using Match.Core.Scoring.Configuration;
using Match.Core.Scoring.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Match.Core.Scoring.VContainer
{
    public class ScoringInstaller : Installer
    {
        [SerializeField] private ScoringView _scoringView;
        [SerializeField] private ScoringConfiguration _scoringConfiguration;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(_scoringConfiguration).AsImplementedInterfaces();
            
            builder.RegisterComponent(_scoringView).AsImplementedInterfaces();
            
            builder.RegisterEntryPoint<ScoringPresenter>();
            builder.RegisterEntryPoint<ScoringPointsPointsTracker>();
            builder.RegisterEntryPoint<ScoringTimerTracker>();
        }
    }
}