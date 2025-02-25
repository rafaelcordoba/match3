using Commons.Runtime.Grid;
using Commons.Runtime.Input.Swipe;
using Cysharp.Threading.Tasks;
using Match.Application.Gameplay.Board;
using Match.Application.Gameplay.Board.Matching;
using Match.Application.Gameplay.Board.Matching.Strategies;

namespace Match.Application.Gameplay.Autoplay
{
    public class AutoplayLogic : IAutoplayLogic
    {
        private readonly IGrid<Tile> _originalGrid;
        private readonly IMatchingConfiguration _configuration;
        private readonly IGameplayManager _gameplayManager;
        
        private bool _autoPlayIsRunning;
        private NeighbourFinder _neighbourFinder;
        private Swapper _swapper;
        private MatchingDestroyer _matchingDestroyer;

        public AutoplayLogic(IGrid<Tile> originalGrid, IGameplayManager gameplayManager, IMatchingConfiguration configuration)
        {
            _originalGrid = originalGrid;
            _gameplayManager = gameplayManager;
            _configuration = configuration;
        }

        public async UniTask PlayOneMove()
        {
            if (_autoPlayIsRunning || _gameplayManager.IsRunning)
                return;
            
            _autoPlayIsRunning = true;
            
            // Create a copy so we can test out moves without affecting the original grid
            var gridCopy = _originalGrid.Clone();
            var presenter = new DummyBoardPresenter();
            
            // Prepare the helper classes for neighbor-finding, swapping, and matching
            _neighbourFinder = new NeighbourFinder(gridCopy);
            _swapper = new Swapper(gridCopy, presenter);
            var matchingStrategies = new IMatchingStrategy[]
            {
                new HorizontalStrategy(gridCopy),
                new VerticalStrategy(gridCopy)
            };
            var matcher = new Matcher(matchingStrategies, _configuration);
            _matchingDestroyer = new MatchingDestroyer(matcher, gridCopy, presenter);

            // Directions we want to check for a potential match
            var directionsToCheck = new[]
            {
                SwipeDirection.Right,
                SwipeDirection.Up,
                SwipeDirection.Down,
                SwipeDirection.Left
            };


            for (uint x = 0; x < gridCopy.Width; x++)
            for (uint y = 0; y < gridCopy.Height; y++)
            {
                var position = new GridPosition(x, y);
                var origin = gridCopy.GetItem(position);
                
                // Try each direction for the current tile
                foreach (var direction in directionsToCheck)
                {
                    var matchHappened = await CheckDirection(origin, direction);
                    if (matchHappened)
                    {
                        // If a match is found, return early after playing that move
                        return;
                    }
                }
            }
            
            _autoPlayIsRunning = false;
        }

        private async UniTask<bool> CheckDirection(Tile origin, SwipeDirection swipeDirection)
        {
            var target = _neighbourFinder.Find(swipeDirection, origin.GridPosition);
            if (target == null)
            {
                return false;
            }
                
            await _swapper.SwapAsync(origin, target);
                
            var success = await _matchingDestroyer.TryDestroy(new []{ origin, target });
            if (success)
            {
                var realOrigin = _originalGrid.GetItem(origin.GridPosition);
                var realNeighbour = _originalGrid.GetItem(target.GridPosition);
                
                // Perform the actual move on the original grid
                await _gameplayManager.MoveTilesAsync(realOrigin, realNeighbour);
                
                _autoPlayIsRunning = false;
                return true;
            }
                
            await _swapper.SwapAsync(origin, target);
            return false;
        }
    }
}