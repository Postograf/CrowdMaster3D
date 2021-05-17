
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Shuriken Ability", menuName = "Player/Ability/Shuriken", order = 51)]
public class ShurikenAbility : Ability
{
    [SerializeField] private Shuriken _shurikenPrefab;
    [SerializeField] private float _tossForce;
    [SerializeField] private float _shurikenScale;

    public override event UnityAction AbilityEnded;

    public override void UseAbility(AttackState attack, Vector3 direction)
    {
        direction.Normalize();

        var scale = _shurikenPrefab.transform.localScale * _shurikenScale;

        var shuriken = Instantiate(
            _shurikenPrefab,
            attack.Rigidbody.position + direction * scale.x / 2,
            _shurikenPrefab.transform.rotation
        );

        shuriken.transform.localScale = scale;

        shuriken.Rigidbody
            .AddForce(direction * _tossForce, ForceMode.VelocityChange);

        AbilityEnded?.Invoke();
    }
}
