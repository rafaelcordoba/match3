using Cysharp.Threading.Tasks;

namespace Match.Application.PlayAgain
{
    public interface IPlayAgainController
    {
        UniTask PlayAgainAsync();
    }
}