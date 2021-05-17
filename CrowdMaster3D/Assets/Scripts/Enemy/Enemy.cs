using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody), typeof(Animator), typeof(HealthContainer))]
public class Enemy : StateMachine, IDamageable
{
    [SerializeField] private BrokenState _brokenState;

    private HealthContainer _healthContainer;
    private float _minDamage;

    public event UnityAction<Enemy> Died;
    public event UnityAction<float> Damaged;

    protected virtual void OnEnable()
    {
        _healthContainer.Damaged += OnDamaged;
        _healthContainer.Died += OnDied;
    }

    protected virtual void OnDisable()
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
        _rigidbody.constraints = RigidbodyConstraints.None;
        Died?.Invoke(this);
    }

    protected override void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _healthContainer = GetComponent<HealthContainer>();
        _player = FindObjectOfType<Player>();
    }

    public bool ApplyDamage(Rigidbody rigidbody, float damage)
    {
        if (damage > _minDamage && _currentState != _brokenState)
        {
            _healthContainer.TakeDamage(damage);
            Transit(_brokenState);
            _brokenState.ApplyDamage(rigidbody, damage);
            return true;
        }

        return false;
    }
}
