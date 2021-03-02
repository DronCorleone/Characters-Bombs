using System.Collections.Generic;
using UnityEngine;


public class CharacterController : MonoBehaviour
{
    [SerializeField] private GameSettings _settings;

    private List<BaseCharacter> _characters;


    private void Awake()
    {
        _characters = new List<BaseCharacter>(FindObjectsOfType<BaseCharacter>());
    }

    private void Start()
    {
        SetupCharacters();
    }

    private void SetupCharacters()
    {
        if (_characters.Count == 0) return;

        for (int i = 0; i < _characters.Count; i++)
        {
            _characters[i].Setup(_settings);
        }
    }
}