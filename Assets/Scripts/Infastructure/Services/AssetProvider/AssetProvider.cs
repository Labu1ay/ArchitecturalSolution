using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AssetProvider : IAsset {
    private AsyncOperationHandle<GameObject> _asyncOperationHandle;
    
    public GameObject Instantiate(string path) {
        var prefab = Resources.Load<GameObject>(path);
        return Object.Instantiate(prefab);
    }
    
    public GameObject Instantiate(string path, Transform parent) {
        var prefab = Resources.Load<GameObject>(path);
        return Object.Instantiate(prefab, parent);
    }
    
    public void InstantiateLoadedResources(AssetReferenceGameObject reference) {
        _asyncOperationHandle = reference.LoadAssetAsync<GameObject>();
        _asyncOperationHandle.Completed += CompleteLoad;
    }
    
    private void CompleteLoad(AsyncOperationHandle<GameObject> obj) {
        if (obj.Status != AsyncOperationStatus.Succeeded) {
            Debug.LogWarning("Не удалось загрузить ресурс");
            return;
        }
        Object.Instantiate(obj.Result);
    }

    public void UnloadResources() => Addressables.Release(_asyncOperationHandle);
}
