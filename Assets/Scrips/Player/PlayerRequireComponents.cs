using Scripts.Player;
using UnityEngine;

namespace Scripts.Player
{
    [RequireComponent(typeof(AnimationsSetter))]
    [RequireComponent(typeof(Attacker))]
    [RequireComponent(typeof(CameraFollower))]
    [RequireComponent(typeof(ChooserSectorAttack))]
    [RequireComponent(typeof(ChooserWeapon))]
    [RequireComponent(typeof(DeathSetter))]
    [RequireComponent(typeof(HealthSetter))]
    [RequireComponent(typeof(HitTaker))]
    [RequireComponent(typeof(Inventory))]
    [RequireComponent(typeof(Mover))]
    [RequireComponent(typeof(NextTargetFinder))]
    [RequireComponent(typeof(ObjectsCreator))]
    [RequireComponent(typeof(ShootPointSetter))]
    [RequireComponent(typeof(StartWeaponSetter))]

    public class PlayerRequireComponents : MonoBehaviour
    {
    }
}