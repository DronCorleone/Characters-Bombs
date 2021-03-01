using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class SimpleCharacter : BaseCharacter
{
    public override void Setup(GameSettings settings)
    {
        _hp = settings.SimpleCharHP;
    }

    public override void GetDamage(int damage)
    {
        _hp -= damage;

        if (_hp <= 0)
        {
            Die();
        }
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}