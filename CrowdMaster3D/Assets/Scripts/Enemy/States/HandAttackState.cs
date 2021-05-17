using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAttackState : EnemyState
{
    [SerializeField] private float _attackDamage;
    [SerializeField] private float _attackDelay;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(Attack());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator Attack()
    {
        while (enabled)
        {
            Animator.SetTrigger("attack");
            yield return new WaitForSeconds(_attackDelay);
            Player.ApplyDamage(_attackDamage);
        }
    }
}
