using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BrokenState : EnemyState
{
    [SerializeField] private float _fallDistance;

    public event UnityAction Died;

    public void ApplyDamage(Rigidbody attackingRigidbody, float force)
    {
        Animator.SetTrigger("fall");
        Vector3 fallDirection = transform.position - attackingRigidbody.position;
        fallDirection.y = 0;
        Rigidbody.AddForce(fallDirection.normalized * force, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        var ray = new Ray(transform.position + Vector3.up, Vector3.down);
        if(!Physics.Raycast(ray, _fallDistance))
        {
            Rigidbody.constraints = RigidbodyConstraints.None;
            Died?.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!enabled)
            return;

        if (other.TryGetComponent(out IDamageable damageable))
            damageable.ApplyDamage(Rigidbody, Rigidbody.velocity.magnitude);
    }
}
