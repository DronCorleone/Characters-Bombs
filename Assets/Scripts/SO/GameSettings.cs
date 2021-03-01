using UnityEngine;


[CreateAssetMenu(fileName = "GameSettingsConfig", menuName = "Configs/Game settings config", order = 1)]
public class GameSettings : ScriptableObject
{
    [Header("Simple Character settings")]
    public int SimpleCharHP;

    [Header("Simple Bomb settings")]
    public int SimpleBombDamage;
    public int SimpleBombRadius;
}