using UnityEngine;
using UnityEngine.AddressableAssets;

public interface IAsset : IService {
    GameObject Instantiate(string path);
    GameObject Instantiate(string path, Transform parent);
    void InstantiateLoadedResources(AssetReferenceGameObject reference);
    void UnloadResources();
}

