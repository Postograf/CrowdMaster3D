using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaAccumulator : MonoBehaviour
{
    [SerializeField] private Ability _baseAbility;
    [SerializeField] private Ability _ultimateAbility;
    [SerializeField] private float _accumulationTime;

    private float _staminaValue;

    private void Update()
    {
        _staminaValue += Time.deltaTime;
    }

    public void StartAccumulate()
    {
        _staminaValue = 0;
    }

    public Ability GetAbility()
    {
        if (_staminaValue >= _accumulationTime)
            return _ultimateAbility;

        return _baseAbility;
    }
}
