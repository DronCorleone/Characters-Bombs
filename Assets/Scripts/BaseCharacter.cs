using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour
{
    private int _hp;


    protected abstract void SetStats();
    protected abstract void GetDamage(int damage);
}