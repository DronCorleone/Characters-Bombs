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
        Collider[] charactersInDanger = Physics.OverlapSphere(transform.position, _radius, _onlyCharactersMask);

        if (charactersInDanger != null)
        {
            for (int i = 0; i < charactersInDanger.Length; i++)
            {
                if (Physics.Raycast(transform.position, charactersInDanger[i].gameObject.transform.position, 
                    Vector3.Distance(transform.position, charactersInDanger[i].transform.position), _onlyWallsMask) == false)
                {
                    charactersInDanger[i].gameObject.GetComponent<BaseCharacter>().GetDamage(_damage);
                }
            }
        }

        transform.position = _poolCoordinates;
        Activate(false);
    }
}