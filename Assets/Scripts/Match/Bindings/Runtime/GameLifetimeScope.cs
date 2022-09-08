using System.Collections.Generic;
using Game.Commons.VContainer;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Match.Bindings
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private List<Installer> _installers;

        protected override void Configure(IContainerBuilder builder)
        {
            foreach (var installer in _installers)
                installer.Install(builder);
        }
    }
}