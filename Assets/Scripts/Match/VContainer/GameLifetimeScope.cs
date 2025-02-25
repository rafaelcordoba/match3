using Commons.Runtime.Camera;
using Commons.Runtime.Grid;
using Commons.Runtime.Input.Swipe;
using Commons.Runtime.Input.Touch;
using Commons.Runtime.System.Random;
using Commons.Runtime.UI;
using Commons.Runtime.UI.Configuration;
using Commons.Runtime.Unity;
using Match.Application.Gameplay;
using Match.Application.Gameplay.Autoplay;
using Match.Application.Gameplay.Board;
using Match.Application.Gameplay.Board.Matching;
using Match.Application.Gameplay.Board.Matching.Strategies;
using Match.Application.Leaderboard;
using Match.Application.Pausing;
using Match.Application.PlayAgain;
using Match.Application.Scoring;
using Match.Infrastructure;
using Match.Infrastructure.Leaderboard;
using Match.Infrastructure.UnityConfigurations;
using Match.Popups.Runtime;
using Match.Presentation.ChangeName;
using Match.Presentation.Game;
using Match.Presentation.HUD;
using Match.Presentation.Leaderboard;
using Match.Presentation.Scoring;
using Match.Presentation.Tiles;
using Match.Presentation.Tiles.Configuration;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;
using VContainer.Unity;

namespace Match.VContainer
{
    public class GameLifetimeScope : LifetimeScope
    {
        [FormerlySerializedAs("gameFlowController")]
        [Header("Scene References")]
        [SerializeField] private Camera gameCamera;
        [SerializeField] private UIRoot uiRoot;
        [SerializeField] private HudPresenter hudPresenter;
        [SerializeField] private ScoringView scoringView;
        
        [Header("Configurations")]
        [SerializeField] private PopupsConfiguration popupsConfiguration;
        [FormerlySerializedAs("gridConfiguration")] [SerializeField] private GridScriptableObject gridScriptableObject;
        [FormerlySerializedAs("leaderboardDefaultData")] [SerializeField] private LeaderboardEntriesScriptableObject leaderboardEntriesScriptableObject;
        [FormerlySerializedAs("matchingConfiguration")] [SerializeField] private MatchingScriptableObject matchingScriptableObject;
        [FormerlySerializedAs("scoringConfiguration")] [SerializeField] private ScoringScriptableObject scoringScriptableObject;
        [SerializeField] private TilesConfiguration tilesConfiguration;
        
        protected override void Configure(IContainerBuilder builder)
        {
            // Commons
            builder.RegisterInstance<ICameraAdapter>(new CameraAdapter(gameCamera));
            builder.RegisterInstance<IUIRoot>(uiRoot);
            builder.RegisterInstance<IPopupsConfiguration>(popupsConfiguration);
            
            builder.Register<IRandomAdapter, RandomAdapter>(Lifetime.Transient);
            builder.Register<IUnityObjectAdapter, UnityObjectAdapter>(Lifetime.Transient);
            builder.Register<ITouchInputController, TouchInputController>(Lifetime.Singleton);
            builder.Register<ISwipeDetector, SwipeDetector>(Lifetime.Singleton);
            builder.Register<ISwipeConditionChecker, SwipeConditionChecker>(Lifetime.Singleton);
            builder.Register<ISwipeDirectionFactory, SwipeDirectionFactory>(Lifetime.Singleton);
            builder.Register<IUIViewFactory, UIViewFactory>(Lifetime.Singleton);
            builder.Register<IUIController, UIController>(Lifetime.Singleton);
            builder.Register<IPopupController, PopupController>(Lifetime.Singleton);
            
            // Gameplay
            builder.RegisterInstance<IGridConfiguration>(gridScriptableObject);
            builder.RegisterInstance<IMatchingConfiguration>(matchingScriptableObject);
            builder.RegisterInstance(tilesConfiguration).As<ITilesConfiguration>().As<ITileTypeRepository>();
            
            builder.RegisterEntryPoint<GameplayManager>();
            builder.RegisterEntryPoint<EndGameController>();
            builder.RegisterEntryPoint<GameEntrypoint>();
            builder.RegisterEntryPoint<PlayerInputListener>();
            builder.RegisterEntryPoint<NeighbourSwipeHandler>();
            
            builder.Register<IBoardPresenter, BoardPresenter>(Lifetime.Singleton);
            builder.Register<ISwapper, Swapper>(Lifetime.Singleton);
            builder.Register<INeighbourFinder, NeighbourFinder>(Lifetime.Singleton);
            builder.Register<IGridRefiller, GridRefiller>(Lifetime.Singleton);
            builder.Register<IGridInitializer, GridInitializer>(Lifetime.Singleton);
            builder.Register<INoMatchAroundTileFactory, NoMatchAroundTileFactory>(Lifetime.Singleton);
            builder.Register<IMatchingStrategy, HorizontalStrategy>(Lifetime.Singleton);
            builder.Register<IMatchingStrategy, VerticalStrategy>(Lifetime.Singleton);
            builder.Register<IMatcher, Matcher>(Lifetime.Singleton);
            builder.Register<IMatchingDestroyer, MatchingDestroyer>(Lifetime.Singleton);
            builder.Register<IChainReactionDestroyer, ChainReactionDestroyer>(Lifetime.Singleton);
            builder.Register<ICascader, Cascader>(Lifetime.Singleton);
            builder.Register<IAutoplayLogic, AutoplayLogic>(Lifetime.Singleton);
            builder.Register<ITileGraphicsProvider, TileGraphicsProvider>(Lifetime.Singleton);
            builder.Register<ITilePoolController, TilePoolController>(Lifetime.Singleton);
            builder.Register<ITileViewFactory, TileViewFactory>(Lifetime.Singleton);
            builder.Register<IGrid<Tile>, GameGrid<Tile>>(Lifetime.Singleton);
            builder.Register<IPlayAgainController, PlayAgainController>(Lifetime.Singleton);
            builder.Register<IPauseController, PauseController>(Lifetime.Singleton);
            
            // Leaderboard
            builder.RegisterInstance<ILeaderboardDefaultData>(leaderboardEntriesScriptableObject);
            builder.Register<ILeaderboardRepository, LeaderboardPlayerPrefsRepository>(Lifetime.Singleton);
            builder.Register<ILeaderboardController, LeaderboardController>(Lifetime.Singleton);
            builder.Register<ILeaderboardPopupPresenter, LeaderboardPopupPresenter>(Lifetime.Singleton);
            builder.Register<IChangeNamePopupPresenter, ChangeNamePopupPresenter>(Lifetime.Singleton);
            
            // HUD
            builder.RegisterComponent(hudPresenter);
            
            // Scoring
            builder.RegisterInstance<IScoringConfiguration>(scoringScriptableObject);
            builder.RegisterComponent<IScoringView>(scoringView);
            builder.RegisterEntryPoint<ScoringPresenter>();
            builder.RegisterEntryPoint<ScoringPointsPointsTracker>();
            builder.RegisterEntryPoint<ScoringTimerTracker>();
        }
    }
}