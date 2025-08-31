using UnityEngine;
using VContainer;
using VContainer.Unity;

public class SpawnBulletFactoryManager10 : MonoBehaviour
{
    private Vector3 _posToSpawn;
    private GameObject _bulletPrefab;
    private IObjectResolver _resolver;

    private IAnalyticsServiceHolder _analyticsServiceHolder;
    private IScoreServiceHolder _scoreServiceHolder;
    private Camera cameraObj;

    private void Start()
    {
        cameraObj = Camera.main;
    }

    [Inject]
    public void Construct(GameObject bulletPrefab, Vector3 posToSpawn, IObjectResolver resolver, IAnalyticsServiceHolder analyticsServiceHolder, IScoreServiceHolder scoreServiceHolder)
    {
        Debug.Log("DI Construct called!");
        _posToSpawn = posToSpawn;
        _bulletPrefab = bulletPrefab;
        _resolver = resolver;
        _analyticsServiceHolder = analyticsServiceHolder;
        _scoreServiceHolder = scoreServiceHolder;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left click
        {
            SpawnBullet();
        }
    }


    public void SpawnBullet()
    {
        if (cameraObj == null) return;
        GameObject bulletObj = Instantiate(_bulletPrefab, _posToSpawn, Quaternion.identity);
        _resolver.InjectGameObject(bulletObj);
        _analyticsServiceHolder.ShowEvent("Spawn Bullet");
        _scoreServiceHolder.AddScore(10);
    }
}
