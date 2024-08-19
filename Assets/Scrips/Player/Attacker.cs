using UnityEngine;

namespace Scripts.Player
{
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