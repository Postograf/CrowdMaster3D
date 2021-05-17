using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State
{
    [SerializeField] private PlayerTransition[] _transitions;

    public Rigidbody Rigidbody { get; private set; }
    protected Animator Animator { get; private set; }

    public override void Enter(Rigidbody rigidbody, Animator animator, Player playerStateMachine = null)
    {
        if (!enabled)
        {
            Rigidbody = rigidbody;
            Animator = animator;

            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
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
