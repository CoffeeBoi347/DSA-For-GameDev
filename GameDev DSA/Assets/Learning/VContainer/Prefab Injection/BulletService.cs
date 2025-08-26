using UnityEngine;

public class BulletService : IBulletService
{
    public void Fire() => Debug.Log("Shoot!");
}

public interface IBulletService
{
    public void Fire();
}