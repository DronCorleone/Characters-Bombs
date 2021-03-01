using UnityEngine;

public abstract class BaseBomb : MonoBehaviour
{
    protected int _damage;
    protected int _radius;
    protected bool _isActive;


    public abstract void Setup(GameSettings settings);
    public abstract void Activate(bool isActive);
    protected abstract void Explode();
}
