namespace Match.Core.Grid.Configuration
{
    public interface IGridConfiguration
    {
        uint Width { get; }
        uint Height { get; }
        float TileSize { get; }
    }
}