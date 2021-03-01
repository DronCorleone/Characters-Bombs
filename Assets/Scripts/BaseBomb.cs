using UnityEngine;

public abstract class BaseBomb : MonoBehaviour
{
    private int _damage;
    private int _radius;


    protected abstract void SetPower();
    protected abstract void Explode();
}
