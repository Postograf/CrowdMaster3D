using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTransition : Transition
{
    [SerializeField] private EnemyState _targetState;

    public EnemyState TargetState => _targetState;
    protected Player Player { get; private set; }

    public void Init(Player player)
    {
        Player = player;
    }

    protected virtual void OnEnable()
    {
        NeedTransit = false;
    }
}
