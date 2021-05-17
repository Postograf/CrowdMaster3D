using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class Player : StateMachine
{
    private HealthContainer _healthContainer;

    public event UnityAction Died;
    public event UnityAction<float> Damaged;

    private void OnEnable()
    {
        _healthContainer.Damaged += OnDamaged;
        _healthContainer.Died += OnDied;
    }

    private void OnDisable()
    {
        _healthContainer.Damaged -= OnDamaged;
        _healthContainer.Died -= OnDied;
    }

    private void OnDamaged(float health)
    {
        Damaged?.Invoke(health);
    }

    private void OnDied()
    {
        enabled = false;
        _animator.SetTrigger("broken");
        Died?.Invoke();
    }

    protected override void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _healthContainer = GetComponent<HealthContainer>();
    }

    public void ApplyDamage(float damage)
    {
        _healthContainer.TakeDamage(damage);
    }
}
