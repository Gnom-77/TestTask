using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _itemPrefabs;
    [SerializeField] private float _spawnInterval = 3f;
    [SerializeField] private float _planeSize = 25f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnItem), 1f, _spawnInterval);
    }

    private void SpawnItem()
    {
        if (_itemPrefabs.Length == 0) return;

        Vector3 pos = new(Random.Range(-_planeSize / 2f, _planeSize / 2f), 0.5f, Random.Range(-_planeSize / 2f, _planeSize / 2f));

        int index = Random.Range(0, _itemPrefabs.Length);
        Instantiate(_itemPrefabs[index], pos, Quaternion.identity);
    }
}
