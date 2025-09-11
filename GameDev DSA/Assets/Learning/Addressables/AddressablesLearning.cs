using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressablesLearning : MonoBehaviour
{
    public string assetName;
    public SpriteRenderer spriteRenderer;
    public AsyncOperationHandle<Sprite> handler;

    private void Start()
    {
        handler = Addressables.LoadAssetAsync<Sprite>("Assets/Learning/Addressables/Panda.jpg");
        handler.Completed += OnAssetLoaded;
    }

    private void OnAssetLoaded(AsyncOperationHandle<Sprite> obj)
    {
        if (obj.IsValid() && obj.Status == AsyncOperationStatus.Succeeded)
        {
            spriteRenderer.sprite = obj.Result;
            Debug.Log("[Addressables Learning]: Asset loaded successfully.");
        }
        else
        {
            Debug.Log("[Addressables Learning]: Failed to load asset.");
        }
    }

    private void OnDestroy()
    {
        if (handler.IsValid())
        {
            Addressables.Release(handler); // release memory from addressables container
        }
    }
}