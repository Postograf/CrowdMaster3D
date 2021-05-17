using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public abstract void Enter(Rigidbody rigidbody, Animator animator, Player player);
    public abstract void Exit();
    public abstract State GetNextState();
}
