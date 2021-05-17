using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAttackTransition : PlayerTransition
{
    [SerializeField] private AttackState _attackState;

    protected override void OnEnable()
    {
        base.OnEnable();
        _attackState.AbilityEnded += OnAbilityEnded;
    }

    private void OnDisable()
    {
        _attackState.AbilityEnded -= OnAbilityEnded;
    }

    private void OnAbilityEnded()
    {
        NeedTransit = true;
    }

    void Update()
    {
        
    }
}
