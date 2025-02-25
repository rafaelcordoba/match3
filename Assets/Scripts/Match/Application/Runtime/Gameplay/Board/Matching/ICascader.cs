using Cysharp.Threading.Tasks;

namespace Match.Application.Gameplay.Board.Matching
{
    public interface ICascader
    {
        UniTask Cascade();
    }
}