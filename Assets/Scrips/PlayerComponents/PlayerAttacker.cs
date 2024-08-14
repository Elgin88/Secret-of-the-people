using UnityEngine;

namespace Scripts.PlayerComponents
{
    [RequireComponent(typeof(PlayerInventoryChooserWeapon))]
    [RequireComponent(typeof(PlayerChooserNearestTarget))]

    public class PlayerAttacker : MonoBehaviour
    {
        [SerializeField] private PlayerInventoryChooserWeapon _playerChooserWeapon;
        [SerializeField] private PlayerChooserNearestTarget _playerChooserNearestTarget;

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