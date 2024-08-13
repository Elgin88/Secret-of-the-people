using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerAgentAttack : MonoBehaviour
    {
        [SerializeField] private PlayerChooserNearestTarget _playerChooserNearestTarget;
        [SerializeField] private PlayerInventoryChooserWeapon _playerChooserWeapon;
        [SerializeField] private Transform _shootPoint;

        public Transform ShootPoint => _shootPoint;

        private void FixedUpdate()
        {
            if (TargetIsFind())
            {

            }
        }

        private bool TargetIsFind() => _playerChooserNearestTarget.CurrentTargetsCount != 0;
    }
}