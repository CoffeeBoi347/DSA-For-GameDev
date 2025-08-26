using UnityEngine;
using VContainer;

public class BulletSpawner : MonoBehaviour
{
    private BulletFactory bulletFactory;

    [Inject]
    public void Construct(BulletFactory _bulletFactory)
    {
        bulletFactory = _bulletFactory;
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            bulletFactory.Spawn(new Vector3(0f, 0f, 0f), Quaternion.identity);
        }
    }
}
