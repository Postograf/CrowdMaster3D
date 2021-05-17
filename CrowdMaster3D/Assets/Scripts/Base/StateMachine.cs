using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class StateMachine : MonoBehaviour
{
    [SerializeField] protected State _firstState;
    
    protected State _currentState;
    protected Rigidbody _rigidbody;
    protected Animator _animator;
    protected Player _player;

    protected abstract void Awake();

    protected void Start()
    {
        _currentState = _firstState;
        _currentState.Enter(_rigidbody, _animator, _player);
    }

    protected void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    protected void Transit(State nextState)
    {
        _currentState?.Exit();

        _currentState = nextState;

        _currentState?.Enter(_rigidbody, _animator, _player);
    }
}
