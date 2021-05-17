using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Ability : ScriptableObject
{
    protected Rigidbody Rigidbody;

    public abstract event UnityAction AbilityEnded;

    public abstract void UseAbility(AttackState attack, Vector3 direction);
}
