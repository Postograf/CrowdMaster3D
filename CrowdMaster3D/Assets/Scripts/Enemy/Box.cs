using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IDamageable
{
    public bool ApplyDamage(Rigidbody rigidbody, float damage)
    {
        Debug.Log("Я коробка");

        return false;
    }
}
