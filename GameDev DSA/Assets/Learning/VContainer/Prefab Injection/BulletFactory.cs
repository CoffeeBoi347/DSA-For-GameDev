using UnityEngine;
using VContainer;
using VContainer.Unity;

public class BulletFactory
{
    private GameObject bulletPrefab;
    private IObjectResolver resolver;

    [Inject]
    public void Construct(IObjectResolver _resolver, GameObject _bulletPrefab)
    {
        this.bulletPrefab = _bulletPrefab;
        this.resolver = _resolver;
    }

    public Bullet Spawn(Vector3 pos, Quaternion rot)
    {
        GameObject go_B = Object.Instantiate(bulletPrefab, pos, rot);
        resolver.InjectGameObject(go_B);

        return go_B.GetComponent<Bullet>();
    }
}