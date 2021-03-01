using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class SimpleBomb : BaseBomb
{
    private Rigidbody _rigidbody;


    public override void Activate(bool isActive)
    {
        //TODO
    }

    public override void Setup(GameSettings settings)
    {
        _damage = settings.SimpleBombDamage;
        _radius = settings.SimpleBombRadius;

        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    protected override void Explode()
    {
        //TODO
    }
}