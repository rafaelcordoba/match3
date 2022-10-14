using System.Collections;
using Game.Commons.Input.Swipe;
using Game.Commons.Input.Touch;
using Match.Core.Board.Switcher;
using Match.Core.Board.UI;
using Match.Core.Grid;
using Match.Core.Matching;
using Match.Core.PlayAgain;
using Match.Core.Tiles;
using UnityEngine;
using VContainer;

namespace Match.Core.Board
{
    public class BoardFlowController : MonoBehaviour, IBoardFlowController
    {
        private const float DELAY = 0.2f;
        [Inject] private readonly ITouchInputController _touchInputController;
        [Inject] private readonly ISwipeDetector _swipeDetector;
        [Inject] private readonly ITileSwitcher _tileSwitcher;
        [Inject] private readonly IMatchingDestroyer _matchingDestroyer;
        [Inject] private readonly ICascadeController _cascadeController;
        [Inject] private readonly IGridRefiller _gridRefiller;
        [Inject] private readonly IChainReactionDestroyer _chainReactionDestroyer;
        [Inject] private readonly IPlayAgainController _playAgainController;
        [Inject] private readonly BoardPresenter _boardPresenter;
        private Coroutine _flowCoroutine;
        public bool FlowInProgress { get; private set; }

        private void Start()
            => _playAgainController.PlayAgainRequested += OnPlayAgainRequested;

        private void OnDestroy()
            => _playAgainController.PlayAgainRequested -= OnPlayAgainRequested;

        public void HandleSwipe(SwipeInfo swipeInfo)
            => _flowCoroutine = StartCoroutine(FlowCoroutine(swipeInfo));

        private void OnPlayAgainRequested()
        {
            if (_flowCoroutine != null) 
                StopCoroutine(_flowCoroutine);

            StartCoroutine(PlayAgainCoroutine());
        }

        private IEnumerator PlayAgainCoroutine()
        {
            _boardPresenter.ClearBoard();
            yield return new WaitForSeconds(DELAY);
            _boardPresenter.CreateTiles();
        }

        private IEnumerator FlowCoroutine(SwipeInfo swipeInfo)
        {
            var switcherResult = _tileSwitcher.TrySwitch(swipeInfo.StartWorldPosition, swipeInfo.SwipeDirection);
            if (switcherResult == null)
                yield break;

            FlowInProgress = true;

            yield return new WaitForSeconds(DELAY);
            var tilesDestroyed = DestroyMatchingTiles(switcherResult.OriginTile, switcherResult.NeighbourTile);
            
            if (tilesDestroyed <= 0)
            {
                yield return SwitchBack(switcherResult);
                yield break;
            }
            
            // TODO: create a special tile before cascading
            // add bomb to the grid...

            _touchInputController.Disable();
            yield return Cascading();
            
            // Fix shuffle board if needed 
            
            _touchInputController.Enable();
         
            FlowInProgress = false;
        }

        private IEnumerator Cascading()
        {
            var cascadingInProgress = true;
            while (cascadingInProgress)
            {
                _cascadeController.Cascade();
                _gridRefiller.Refill();
                
                yield return new WaitForSeconds(DELAY);
                _boardPresenter?.Refill();

                yield return new WaitForSeconds(DELAY);
                cascadingInProgress = _chainReactionDestroyer.ChainDestroy();
            }
        }

        private int DestroyMatchingTiles(Tile origin, Tile neighbour)
        {
            var atOrigin = _matchingDestroyer.Destroy(origin);
            var atNeighbour = _matchingDestroyer.Destroy(neighbour);
            return atOrigin + atNeighbour;
        }

        private IEnumerator SwitchBack(SwitcherResult switcherResult)
        {
            _tileSwitcher.SwitchBack(switcherResult);
            yield return new WaitForSeconds(DELAY);
            _touchInputController.Enable();
        }
    }
}