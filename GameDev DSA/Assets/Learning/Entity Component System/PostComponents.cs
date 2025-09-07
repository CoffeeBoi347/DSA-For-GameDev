using Unity.Entities;

public struct LikeTag : IComponentData
{
    public int Value;
}

public struct CommentsTag : IComponentData
{
    public int Value;
}

public struct TrendingTag : IComponentData { }