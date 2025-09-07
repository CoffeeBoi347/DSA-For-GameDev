using Unity.Burst;
using Unity.Entities;
using UnityEngine;

[BurstCompile]
public partial struct TrendingSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        var ecb = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);
        foreach (var(likes, comments, entity) in SystemAPI.Query<RefRO<LikeTag>, RefRO<CommentsTag>>().WithEntityAccess())
        {
            if(likes.ValueRO.Value > 500)
            {
                ecb.AddComponent<TrendingTag>(entity);
                Debug.Log($"Post {entity.Index} is trending with likes {likes.ValueRO.Value} and comments {comments.ValueRO.Value}");
            }
        }

        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }
}