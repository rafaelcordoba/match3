using System;
using Match.Application.Gameplay.Board.Matching;
using VContainer.Unity;

namespace Match.Application.Scoring
{
    public class ScoringPointsPointsTracker : IScoringPointsTracker, IStartable, IDisposable
    {
        public event Action<int> PointsChanged; 
        public int Points { get; private set; }

        private readonly IMatchingDestroyer _matchingDestroyer;
        private readonly IChainReactionDestroyer _chainReactionDestroyer;
        private readonly IScoringConfiguration _configuration;

        public ScoringPointsPointsTracker(
            IMatchingDestroyer matchingDestroyer,
            IChainReactionDestroyer chainReactionDestroyer,
            IScoringConfiguration configuration)
        {
            _matchingDestroyer = matchingDestroyer;
            _chainReactionDestroyer = chainReactionDestroyer;
            _configuration = configuration;
        }

        public void Start()
        {
            _matchingDestroyer.TilesDestroyed += OnTilesDestroyed;    
            _chainReactionDestroyer.TilesDestroyed += OnTilesDestroyed;    
        }

        public void ResetPoints()
        {
            Points = 0;
            PointsChanged?.Invoke(Points);
        }

        public void Dispose()
        {
            _matchingDestroyer.TilesDestroyed -= OnTilesDestroyed;
            _chainReactionDestroyer.TilesDestroyed -= OnTilesDestroyed;
        }

        private void OnTilesDestroyed(int tilesDestroyed)
        {
            if (tilesDestroyed <= 0)
                return;

            var pointsPow = _configuration.PointsPow;
            var pointsDivider = _configuration.PointsDivider;
            var pointsFromDestruction = (int) Math.Pow(pointsPow, tilesDestroyed) / pointsDivider;
            Points += pointsFromDestruction;
            PointsChanged?.Invoke(Points);
        }
    }
}