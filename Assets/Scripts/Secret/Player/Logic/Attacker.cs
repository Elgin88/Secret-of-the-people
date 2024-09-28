using Secret.Player.Inventory;
using UnityEngine;

namespace Secret.Player.Logic
{
    public class Attacker : MonoBehaviour
    {
        [SerializeField] private ChooserWeapon _chooserWeapon;
        [SerializeField] private TargetFinder _nextTargetFinder;

        private void FixedUpdate()
        {
            if (TargetIsFind())
            {
                Attack();
            }
        }

        private void Attack() => _chooserWeapon.CurrentWeapon.Attack(_nextTargetFinder.CurrentTarget);

        private bool TargetIsFind() => _nextTargetFinder.CurrentTargetsCount != 0;
    }
}