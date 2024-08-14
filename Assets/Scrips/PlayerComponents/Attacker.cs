using Scripts.PlayerComponents.InventoryComponents;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    [RequireComponent(typeof(ChooserWeapon))]
    [RequireComponent(typeof(ChooserNearestTarget))]

    public class Attacker : MonoBehaviour
    {
        [SerializeField] private ChooserWeapon _chooserWeapon;
        [SerializeField] private ChooserNearestTarget _chooserNearestTarget;

        private void FixedUpdate()
        {
            if (TargetIsFind())
            {
                _chooserWeapon.CurrentWeapon.Shoot();
            }
        }

        private bool TargetIsFind() => _chooserNearestTarget.CurrentTargetsCount != 0;
    }
}