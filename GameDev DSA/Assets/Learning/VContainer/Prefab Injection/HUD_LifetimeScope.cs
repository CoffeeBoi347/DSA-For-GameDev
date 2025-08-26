using VContainer;
using VContainer.Unity;

public class HUD_LifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        base.Configure(builder);
        builder.Register<_IAnalyticsService, _AnalyticsService>(Lifetime.Singleton);
        builder.Register<_IAudioService, _AudioService>(Lifetime.Singleton);
        builder.Register<_IScoreService, _ScoreService>(Lifetime.Singleton);

        builder.RegisterComponentInHierarchy<GameHUD>();
    }
}
