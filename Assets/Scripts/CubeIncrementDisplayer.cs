using UnityEngine;

public class CubeIncrementDisplayer : ObjectPool
{
    [SerializeField] private GameObject _incrementPrefab;
    [SerializeField] private Transform _stickman;

    private void Start()
    {
        Initialize(_incrementPrefab);
    }

    public void DisplayIncrement()
    {
        if (TryGetObject(out GameObject gameObject))
            SetPrefab(gameObject, _stickman.position);
    }

    private void SetPrefab(GameObject prefab, Vector3 spawnPoint)
    {
        prefab.SetActive(true);
        prefab.transform.position = spawnPoint;
    }
}
