using Cysharp.Threading.Tasks;

namespace Match.Application.Gameplay
{
    public interface IAutoplayLogic
    {
        UniTask PlayOneMove();
    }
}