using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] private GameObject _simpleBomb;
    [SerializeField] private GameSettings _settings;
    [SerializeField] private float _minCoordinate;
    [SerializeField] private float _maxCoordinate;

    private List<BaseBomb> _bombArray;
    private int _startBombCount = 10;


    private void Awake()
    {
        for (int i = 0; i <= _startBombCount; i++)
        {
            BaseBomb bomb = Instantiate(_simpleBomb, _settings.BombPoolCoordinates, Quaternion.identity).GetComponent<SimpleBomb>();
            
        }
    }
}
