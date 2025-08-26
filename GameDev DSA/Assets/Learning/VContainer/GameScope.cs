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
        builder.Register<IBasicAI, DogAI>(Lifetime.Singleton);
        builder.RegisterComponentInHierarchy<BasicAI>();
    }
}
