using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int _startAmountOfRoads;
    [SerializeField] private float _roadLenght = 30;
    [SerializeField] private float _generatorHeight;
    [SerializeField] private float _firstRoadOffset;

    private GameObject[] _roadPrefabs;
    private Vector3 _spawnPosition = new Vector3(0, 0, 0);

    private void Start()
    {
        Initialize();

        for (int i = 0; i < _startAmountOfRoads; i++)
        {
            SpawnRoad(Random.Range(0, _roadPrefabs.Length));
        }

        _spawnPosition.y = _generatorHeight;
    }

    private void Update()
    {
        if (_player.transform.position.z > _spawnPosition.z - (_startAmountOfRoads*_roadLenght))
            SpawnRoad(Random.Range(0, _roadPrefabs.Length));
    }

    private void Initialize()
    {
        _roadPrefabs = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            _roadPrefabs[i] = transform.GetChild(i).gameObject;
    }

    private void SpawnRoad(int roadIndex)
    {
        Instantiate(_roadPrefabs[roadIndex], new Vector3(_spawnPosition.x, _spawnPosition.y, _spawnPosition.z - _firstRoadOffset), transform.rotation);
        _spawnPosition.z += _roadLenght;
    }
}
