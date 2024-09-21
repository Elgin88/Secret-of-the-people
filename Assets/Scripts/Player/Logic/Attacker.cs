using UnityEngine;

namespace Player.Logic
{
    public class Attacker : MonoBehaviour
    {
        [SerializeField] private TargetFinder _nextTargetFinder;
        [SerializeField] private ChooserWeapon _chooserWeapon;

        private void FixedUpdate()
        {
            if (TargetIsFind())
            {
                //Shoot();
            }
        }
        private void Shoot() => _chooserWeapon.CurrentWeapon.Shoot();

        private bool TargetIsFind() => _nextTargetFinder.CurrentTargetsCount != 0;
    }
}