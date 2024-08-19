using UnityEngine;

namespace Scripts.Player
{
    [RequireComponent(typeof(ChooserDeathHash))]
    [RequireComponent(typeof(AnimationSetter))]
    [RequireComponent(typeof(AnimationStateMaschine))]
    [RequireComponent(typeof(Attacker))]
    [RequireComponent(typeof(CameraFollower))]
    [RequireComponent(typeof(ChooserSectorAttack))]
    [RequireComponent(typeof(ChooserWeapon))]
    [RequireComponent(typeof(DeathSetter))]
    [RequireComponent(typeof(HealthChanger))]
    [RequireComponent(typeof(HitTaker))]
    [RequireComponent(typeof(Inventory))]
    [RequireComponent(typeof(Mover))]
    [RequireComponent(typeof(NextTargetFinder))]
    [RequireComponent(typeof(ObjectsCreator))]
    [RequireComponent(typeof(ShootPointSetter))]
    [RequireComponent(typeof(StartWeaponSetter))]
    [RequireComponent(typeof(DamageTaker))]

    public class RequireComponents : MonoBehaviour
    {
    }
}