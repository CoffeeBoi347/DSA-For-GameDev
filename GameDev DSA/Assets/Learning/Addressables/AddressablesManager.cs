using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class AddressablesManager : MonoBehaviour
{
    public string assetKey = "ram-charan-061125-2.jpg";
    public Image targetImage;

    private void Start()
    {
        Debug.Log("FINAL RUNTIME KEY: " + assetKey);
        Addressables.LoadAssetAsync<Sprite>(assetKey).Completed += LoadSpriteAsyncOperation;
    }

    void LoadSpriteAsyncOperation(AsyncOperationHandle<Sprite> handle)
    {
        if(handle.Status == AsyncOperationStatus.Succeeded)
        {
            targetImage.sprite = handle.Result;
            Debug.Log("Loaded successfully!");
        }
        else
        {
            Debug.Log("Failure in loading.");
        }
    }
}