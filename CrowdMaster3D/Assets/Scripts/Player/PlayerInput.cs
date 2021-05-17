using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    private Vector3 _targetPosition;

    public event UnityAction<Vector2> DirectionChanged;
    public event UnityAction PointerUp;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _targetPosition = Input.mousePosition;

        if (Input.GetMouseButton(0))
            DirectionChanged?.Invoke(Input.mousePosition - _targetPosition);

        if (Input.GetMouseButtonUp(0))
            PointerUp?.Invoke();
    }
}
