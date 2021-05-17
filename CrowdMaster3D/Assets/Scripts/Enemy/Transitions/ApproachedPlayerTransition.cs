using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachedPlayerTransition : EnemyTransition
{
    [SerializeField] private float _attackRange;

    private void Update()
    {
        if (Vector3.Distance(Player.transform.position, transform.position) <= _attackRange)
            NeedTransit = true;
    }
}
