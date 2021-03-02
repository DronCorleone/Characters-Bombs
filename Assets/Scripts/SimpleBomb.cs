using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class SimpleBomb : BaseBomb
{
    private Rigidbody _rigidbody;
    private Vector3 _poolCoordinates;


    public override void Setup(GameSettings settings)
    {
        _damage = settings.SimpleBombDamage;
        _radius = settings.SimpleBombRadius;

        _poolCoordinates = settings.BombPoolCoordinates;

        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
    }

    public override void Activate(bool isActive)
    {
        _rigidbody.isKinematic = !isActive;
        _isActive = isActive;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    protected override void Explode()
    {
        //TODO
        transform.position = _poolCoordinates;
        Activate(false);
    }
}