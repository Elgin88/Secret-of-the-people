using Scripts.PlayerComponents.InventoryComponents;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    [RequireComponent(typeof(ChooserWeapon))]
    [RequireComponent(typeof(NextTargetFinder))]
    [RequireComponent(typeof(ChooserSectorAttack))]

    public class Attacker : MonoBehaviour
    {
        [SerializeField] private NextTargetFinder _chooserNearestTarget;
        [SerializeField] private ChooserWeapon _chooserWeapon;

        private void FixedUpdate()
        {
            if (TargetIsFind())
            {
                Shoot();
            }
        }
        private void Shoot() => _chooserWeapon.CurrentWeapon.Shoot();

        private bool TargetIsFind() => _chooserNearestTarget.CurrentTargetsCount != 0;
    }
}