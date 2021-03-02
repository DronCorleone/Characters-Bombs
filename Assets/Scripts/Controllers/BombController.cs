using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] private GameObject _simpleBomb;
    [SerializeField] private GameSettings _settings;
    [SerializeField] private float _minCoordinate;
    [SerializeField] private float _maxCoordinate;
    [SerializeField] private float _bombHeight;

    private List<BaseBomb> _bombArray = new List<BaseBomb>();
    private float _bombSpawnDelay;
    private int _startBombCount = 10;
    private int _currentIndex = 0;


    private void Awake()
    {
        for (int i = 0; i < _startBombCount; i++)
        {
            InstantiateBomb();
        }

        _bombSpawnDelay = _settings.BombSpawnDelay;
    }

    private void Update()
    {
        if (_bombSpawnDelay > 0)
        {
            _bombSpawnDelay -= Time.deltaTime;
        }
        else
        {
            _bombSpawnDelay = _settings.BombSpawnDelay;
            SpawnBomb();
        }
    }

    private void SpawnBomb()
    {
        var x = Random.Range(_minCoordinate, _maxCoordinate);
        var z = Random.Range(_minCoordinate, _maxCoordinate);

        if (_bombArray[_currentIndex].IsActive == true)
        {
            InstantiateBomb();
            _currentIndex = _bombArray.Count - 1;
        }

        _bombArray[_currentIndex].transform.position = new Vector3(x, _bombHeight, z);
        _bombArray[_currentIndex].Activate(true);
        _currentIndex ++;

        if (_currentIndex >= _bombArray.Count)
        {
            _currentIndex = 0;
        }
    }

    private void InstantiateBomb()
    {
        BaseBomb bomb = Instantiate(_simpleBomb, _settings.BombPoolCoordinates, Quaternion.identity).GetComponent<SimpleBomb>();
        bomb.Setup(_settings);
        _bombArray.Add(bomb);
    }
}