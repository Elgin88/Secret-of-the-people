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
            }
        }

        private Transform ShootPoint() => _shootPoint;

        private Collider GetTargetCollider() => _nextTargetFinder.CurrentTarget;

        private bool TargetIsFind() => _nextTargetFinder.CurrentTarget != null;
    }
}