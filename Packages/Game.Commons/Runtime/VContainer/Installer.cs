using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Commons.VContainer
{
    public abstract class Installer : MonoBehaviour, IInstaller
    {
        public abstract void Install(IContainerBuilder builder);
    }
}