using Game.Commons.VContainer;
using Match.Core.Matching.Configuration;
using Match.Core.Matching.Strategies;
using UnityEngine;
using VContainer;

namespace Match.Core.Matching.VContainer
{
    public class MatchingInstaller : Installer
    {
        [SerializeField] private MatchingConfiguration _configuration;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration).AsImplementedInterfaces();
            builder.Register<IMatchingStrategy, HorizontalStrategy>(Lifetime.Singleton);
            builder.Register<IMatchingStrategy, VerticalStrategy>(Lifetime.Singleton);
            builder.Register<Matcher>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<MatchingDestroyer>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<ChainReactionDestroyer>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<CascadeController>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}