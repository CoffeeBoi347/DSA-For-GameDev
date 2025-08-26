using UnityEngine;
using VContainer;

public class Bullet : MonoBehaviour
{
    private IBulletService _bulletService;
    [Inject]
    public void Construct(IBulletService bulletService)
    {
        _bulletService = bulletService;
    }

    private void Update()
    {
        if (_bulletService != null)
        {
            _bulletService.Fire();
            transform.Translate(1f, 0f, 0f);
            Destroy(this.gameObject, 1f);
        }
    }
}