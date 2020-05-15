using UnityEngine;

public class SceneController : MonoBehaviour
{
    public GameObject birdPrefab;
    public int birdCount;
    public Transform parent;

    void Start()
    {
        for (int i = 0; i < birdCount; i++)
        {
            var bird = Instantiate(birdPrefab, Random.insideUnitSphere * 25, Quaternion.identity, parent);
        }
    }
}
