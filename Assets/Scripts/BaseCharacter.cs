using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour
{
    protected int _hp;


    public abstract void Setup(GameSettings settings);
    public abstract void GetDamage(int damage);
    protected abstract void Die();
}