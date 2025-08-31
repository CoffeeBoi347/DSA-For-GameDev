using VContainer;
using UnityEngine;
using VContainer.Unity;

public class ManagerScope : LifetimeScope
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Vector3 _posToSpawn;
    protected override void Configure(IContainerBuilder builder)
    {
        base.Configure(builder);
        builder.Register<IBulletService, BulletService>(Lifetime.Transient);
        builder.Register<IScoreServiceHolder, ScoreServiceHolder>(Lifetime.Singleton);
        builder.Register<IAnalyticsServiceHolder, AnalyticsServiceHolder>(Lifetime.Singleton);

        builder.RegisterInstance(_bulletPrefab).As<GameObject>();
        builder.RegisterInstance(_posToSpawn).As<Vector3>();

        builder.RegisterComponentInHierarchy<SpawnBulletFactoryManager10>().WithParameter(_bulletPrefab);
    }
}