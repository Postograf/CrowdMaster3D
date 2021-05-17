using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerTransition : Transition
{
    [SerializeField] private PlayerState _targetState;

    public PlayerState TargetState => _targetState;

    protected virtual void OnEnable()
    {
        NeedTransit = false;
    }
}
