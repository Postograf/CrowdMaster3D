using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBarrel : MonoBehaviour, IDamageable
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public bool ApplyDamage(Rigidbody rigidbody, float damage)
    {
        Explode();

        return true;
    }

    private void Explode()
    {
        var objectsInExplosion = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach(var unit in objectsInExplosion)
        {
            if(unit.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }

        Destroy(gameObject);
    }
}
