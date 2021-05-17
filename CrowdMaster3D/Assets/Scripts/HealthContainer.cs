using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthContainer : MonoBehaviour
{
    [SerializeField] private float _health;

    public event UnityAction<float> Damaged;
    public event UnityAction Died;

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if(_health <= 0)
        {
            _health = 0;
            Died?.Invoke();
        }
            
        Damaged?.Invoke(_health);
    }
}
