namespace Match.Application.Gameplay.Board
{
    public interface IGridConfiguration
    {
        uint Width { get; }
        uint Height { get; }
        float TileSize { get; }
    }
}