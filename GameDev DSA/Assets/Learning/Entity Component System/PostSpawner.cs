using Unity.Entities;
using UnityEngine;

public class PostSpawner : MonoBehaviour
{
    void Start()
    {
        EntityManager em = World.DefaultGameObjectInjectionWorld.EntityManager;

        for(int i = 0; i < 6; i++)
        {
            Entity post = em.CreateEntity();
            em.AddComponentData(post, new LikeTag { Value = i * 250 });
            em.AddComponentData(post, new CommentsTag { Value = i * 100 });
        }

        Debug.Log("Spawned 6 Posts!");
    }
}