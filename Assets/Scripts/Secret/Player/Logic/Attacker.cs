using Secret.Player.Inventory;
using UnityEngine;

namespace Secret.Player.Logic
{
    public class Attacker : MonoBehaviour
    {
        [SerializeField] private ChooserWeapon _chooserWeapon;
        [SerializeField] private TargetFinder _nextTargetFinder;
        [SerializeField] private Transform _shootPoint;

        private void FixedUpdate()
        {
            if (TargetIsFind())
            {
                AttackTarget(GetTargetCollider(), ShootPoint());
            }
        }

        private Transform ShootPoint() => _shootPoint;

        private Collider GetTargetCollider() => _nextTargetFinder.CurrentTarget;

        private bool TargetIsFind() => _nextTargetFinder.CurrentTarget != null;

        private void AttackTarget(Collider target, Transform shootPoint) => _chooserWeapon.CurrentWeapon.Attack(target, shootPoint);
    }
}