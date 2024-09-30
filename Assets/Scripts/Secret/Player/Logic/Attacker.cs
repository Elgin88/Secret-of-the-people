using Secret.Player.Inventory;
using Secret.Weapons.Interfaces;
using UnityEngine;

namespace Secret.Player.Logic
{
    public class Attacker : MonoBehaviour
    {
        [SerializeField] private ChooserWeapon _chooserWeapon;
        [SerializeField] private TargetFinder _nextTargetFinder;
        [SerializeField] private Transform _shootPoint;

        private IBullet _bullet;

        private void FixedUpdate()
        {
            if (TargetIsFind())
            {
                Attack();
            }
        }

        private void Attack()
        {
            _chooserWeapon.CurrentWeapon.Attack(_nextTargetFinder.CurrentTarget, _shootPoint, _bullet);
        }

        private bool TargetIsFind() => _nextTargetFinder.CurrentTargetsCount != 0;
    }
}