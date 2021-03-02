using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class SimpleBomb : BaseBomb
{
    [SerializeField] LayerMask _onlyCharactersMask;
    [SerializeField] LayerMask _onlyWallsMask;

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
        RaycastHit[] characters = Physics.SphereCastAll(transform.position, _radius, transform.position, _onlyCharactersMask);

        if (characters != null)
        {
            for (int i = 0; i < characters.Length; i++)
            {
                if (characters[i].collider.gameObject.GetComponent<BaseCharacter>())
                {
                    if (Physics.Raycast(transform.position, characters[i].transform.position, _onlyWallsMask) == false)
                    {
                        characters[i].collider.gameObject.GetComponent<BaseCharacter>().GetDamage(_damage);
                    }
                }
            }
        }

        transform.position = _poolCoordinates;
        Activate(false);
    }
}