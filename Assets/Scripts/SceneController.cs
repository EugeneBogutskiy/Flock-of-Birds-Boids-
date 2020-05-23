using UnityEngine;
using UnityEngine.AddressableAssets;

public class SceneController : MonoBehaviour
{
    public int birdCount;
    public Transform parent;

    void Start()
    {
        Addressables.LoadAssetAsync<GameObject>("Assets/Prefabs/BirdPrefab.prefab");

        for (int i = 0; i < birdCount; i++)
        {
            Addressables.InstantiateAsync("Assets/Prefabs/BirdPrefab.prefab", Random.insideUnitSphere*25, Quaternion.identity, parent);
        }
    }
}
