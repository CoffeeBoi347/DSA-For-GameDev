using UnityEngine;
using VContainer;
using VContainer.Unity;

public class B_LifetimeScope : LifetimeScope
{
    public GameObject bulletObj;
    protected override void Configure(IContainerBuilder builder)
    {
        base.Configure(builder);
        builder.Register<IBulletService, BulletService>(Lifetime.Singleton);
        builder.Register<BulletFactory>(Lifetime.Singleton).WithParameter(bulletObj);

        builder.RegisterComponentInHierarchy<BulletSpawner>();
    }
}
