using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerAttacker : MonoBehaviour
    {
        [SerializeField] private PlayerChooserNearestTarget _playerChooserNearestTarget;
        [SerializeField] private PlayerInventoryChooserWeapon _playerChooserWeapon;

        private void FixedUpdate()
        {
            if (TargetIsFind())
            {
                _playerChooserWeapon.CurrentWeapon.Shoot();
            }
        }

        private bool TargetIsFind() => _playerChooserNearestTarget.CurrentTargetsCount != 0;
    }
}