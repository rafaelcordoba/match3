# Match 3 with friends
This is a casual match-game with switcher-mechanic with a scoring system and short rounds of 30 seconds.

The goal of the game is to _Beat Bob's score_ and have fun with your family and friends trying to beat each other too.

You can change the name of the current player at anytime.

The leaderboard will only keep track of the _highest score_ of each player.

## Documentation
### Modularity
- The code is separated in different modules using `.asmdef`
- You can inspect what projects depend on each other in each `.asmdef` at the `references[]`
### Modules dependencies
- `Game.Commons`
  - `Match.Popups`
    - `Match.Core.Pausing`
  - `Match.Bindings`
  - `Match.Core.Tiles`
    - `Match.Core.Matching`
      - `Match.Core.Grid`
      - `Match.Core.Scoring`
        - `Match.Core.PlayAgain`
          - `Match.Core.Leaderboard`
            - `Match.Core.Board`

### Data-driven architecture
- You can configure the behavior of the game with configuration files
- They are located at `Assets/Content/Configs`
- They are ScriptableObjects but all dependencies rely on the interface
- If wanted all configurations could be replaced by JSON coming from a server for example
### Dependency Injection
- All dependencies are injected in the constructor using VContainer framework
- The class `GameLifetimeScope.cs` contains a list of `Installer` implementations for each module
- You can edit them at `Scenes/Game.unity` 
- Since it's only one scope, the order of `Installers` doesn't matter
### Commons Package
- Code that is not game-specific became a package
- It's located at `Packages/Game.Commons`
  - Adapters for Unity static classes
  - Touch Input
  - Swipe detection
  - UI System 
### Game Bootstrap
- `GameBootstrap.cs` is responsible to initialize the game
  - Initialize Pool of tiles
  - Initialize the Grid with data
  - Trigger `BoardPresenter.cs` to show the view tiles
  - Check for player name
### Unit testing
- There are some tests at `Match.Core.Grid.Tests`
  - `GridInitializerTests.cs`
  - `GridRefillerTests.cs`
  - `RandomTileFactoryTests.cs`
- Most classes should be testable
- All dependencies are interfaces and easily mockable
- Single-responsibility was applied as much as possible
- `Fluent Assertions` package was used for easier-to-read assertions
### Things to improve
- `BoardFlowController.cs` should not be a `MonoBehaviour`
  - It's using Unity standard Coroutines
  - The reason for that was to pause the flow with `Time.timeScale = 0`
  - The code could be plain C# using `UnitTask` instead
- `PopupController.cs` needs to be data-driven
  - It's highly hard coded now
  - Interfaces for presenters and views are in this module to avoid cyclical project references
  - A better way would be to have an Attribute class so the Presenter can define which view it uses
- `TileView.cs` should not have state logic
  - A TilePresenter could handle the state changes of a tile
  - It should also tell the view what position it should be
  - And trigger animations, etc