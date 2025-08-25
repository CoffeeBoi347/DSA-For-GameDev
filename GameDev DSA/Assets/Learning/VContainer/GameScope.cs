using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;
public class GameScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        base.Configure(builder);
        builder.Register<IScoreService, ScoreService>(Lifetime.Singleton);
        builder.Register<BootExit>(Lifetime.Singleton);
        builder.RegisterEntryPoint<BootEntry>();
    }
}
