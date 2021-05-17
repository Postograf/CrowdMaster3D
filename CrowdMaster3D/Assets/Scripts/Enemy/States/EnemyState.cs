using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyState : State
{
    [SerializeField] private EnemyTransition[] _transitions;

    public Rigidbody Rigidbody { get; private set; }
    protected Player Player { get; private set; }
    protected Animator Animator { get; private set; }

    public override void Enter(Rigidbody rigidbody, Animator animator, Player player)
    {
        if (!enabled)
        {
            Rigidbody = rigidbody;
            Animator = animator;
            Player = player;

            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Player);
            }
        }
    }

    public override void Exit()
    {
        if (enabled)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }

    public override State GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return transition.TargetState;
            }
        }

        return null;
    }
}
