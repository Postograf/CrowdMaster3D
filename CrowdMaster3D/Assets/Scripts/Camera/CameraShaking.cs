using System.Collections;

using UnityEngine;

public class CameraShaking : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _range;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _player.Damaged += OnPlayerDamaged;
    }

    private void OnDisable()
    {
        _player.Damaged -= OnPlayerDamaged;
    }

    private void OnPlayerDamaged(float damage)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        var startedRotation = transform.rotation;
        var shakingRange = _range;
        Quaternion targetRotation;

        while (shakingRange != 0)
        {
            targetRotation = Quaternion.Euler(
                transform.rotation.eulerAngles.x,
                transform.rotation.eulerAngles.y,
                shakingRange
            );

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                _speed * Time.deltaTime
            );

            if (transform.rotation == targetRotation)
                shakingRange = (Mathf.Abs(shakingRange) - 1) * -1;

            yield return new WaitForEndOfFrame();
        }

        transform.rotation = startedRotation;
        _coroutine = null;
    }
}
