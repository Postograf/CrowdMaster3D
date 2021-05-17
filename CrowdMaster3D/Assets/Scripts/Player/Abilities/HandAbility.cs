using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Hand Ability", menuName = "Player/Ability/Hand", order = 51)]
public class HandAbility : Ability
{
    [SerializeField] private float _attackForce;
    [SerializeField] private float _usefulTime;

    private AttackState _state;
    private Coroutine _coroutine;

    public override event UnityAction AbilityEnded;

    public override void UseAbility(AttackState attack, Vector3 direction)
    {
        if (_coroutine != null)
            Reset();

        _state = attack;

        _coroutine = _state.StartCoroutine(Attack(_state, direction.normalized));
        _state.CollisionDetected += OnPlayerAttack;
    }

    private void OnPlayerAttack(IDamageable damageable)
    {
        if (damageable.ApplyDamage(_state.Rigidbody, _attackForce))
            return;

        _state.Rigidbody.velocity /= 2;
    }

    private IEnumerator Attack(AttackState state, Vector3 direction)
    {
        float time = _usefulTime;

        while(time > 0)
        {
            state.Rigidbody.velocity = direction * _attackForce;
            time -= Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        AbilityEnded?.Invoke();
        Reset();
    }

    private void Reset()
    {
        _state.Rigidbody.velocity = Vector3.zero;
        _state.StopCoroutine(_coroutine);
        _coroutine = null;
        _state.CollisionDetected -= OnPlayerAttack;
    }
}
