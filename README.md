# Match 3 with friends
- This is a casual match-game with switcher-mechanic with a scoring system and short rounds of 30 seconds.
- The goal of the game is to _Beat Bob's score_ and have fun with your family and friends trying to beat each other's score.
- You can change the name of the current player at anytime.
- The leaderboard will only keep track of the _highest score_ of each player.
---
1. [Architecture](#architecture)
2. [Modules](#modules)
3. [Data-driven](#data-driven)
4. [Autoplay Support](#autoplay-support)
5. [Dependency Injection](#dependency-injection)
6. [Game Bootstrap](#game-bootstrap)
7. [Unit testing](#unit-testing)
8. [Things to improve](#things-to-improve)
---
### Architecture
- Hexagonal (or Onion) architecture was used
  - Application is where the business logic is
    - This could be adapted to run on a server if needed
  - Presentation is decoupled from the application
  - Infrastructure holds the implementation of the interfaces defined in the application
    - They use ScriptableObjects at the moment, but could be replaced by a real server and JSON configurations
- The code is separated in different modules using `.asmdef`
- You can inspect what projects depend on each other in each `.asmdef` at the `references[]`
---
### Modules 
- `Match.Application`
- `Match.Presentation`
- `Match.Infrastructure`
- `Match.Popups`
- `Game.Commons`
---
### Data-driven 
- You can configure the behavior of the game with configuration files
- They are located at `Assets/Content/Configs`
- They are ScriptableObjects but all dependencies rely on the interface
- If wanted all configurations could be replaced by JSON coming from a server for example
---
### Autoplay Support
- The game can be played automatically by clicking the _AutoPlay_ button next to the _Pause_ button
- It will look the board and find one move to make
- It does not look for the best move, but that could be added later
---
### Dependency Injection
- All dependencies are injected in the constructor using `VContainer` framework
- The class `GameLifetimeScope.cs` is responsible to inject all dependencies
---
### Game Bootstrap
- `GameEntrypoint.cs` is responsible to initialize the game
  - Initialize Pool of tiles
  - Initialize the Grid with data
  - Trigger `BoardPresenter.cs` to show the view tiles
  - Check for player name
---
### Unit testing
- There are some tests at `Match.Core.Grid.Tests`
  - `GridInitializerTests.cs`
  - `GridRefillerTests.cs`
  - `NoMatchAroundTileFactoryTests.cs`
  - `SwapperTests.cs`
- Most classes are testable in this project
- All dependencies are interfaces and easy to mock
- Single-responsibility was applied as much as possible
- `Fluent Assertions` package was used for easier-to-read assertions
---
### Things to improve
- `PopupController.cs` needs to be data-driven
  - It's highly hard coded now
  - Interfaces for presenters and views are in this module to avoid cyclical project references
  - A better way would be to have an Attribute class so the Presenter can define which view it uses
- `TileView.cs` should not have state logic
  - A TilePresenter could handle the state changes of a tile
  - It should also tell the view what position it should be
  - And trigger animations, etc
