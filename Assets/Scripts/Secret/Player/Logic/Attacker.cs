using Secret.Player.Inventory;
using UnityEngine;

namespace Secret.Player.Logic
{
    public class Attacker : MonoBehaviour
    {
        private ChooserWeapon _chooserWeapon;
        private TargetFinder _targetFinder;

        private void Awake()
        {
            SetComponents();
        }

        private void FixedUpdate()
        {
            if (TargetIsFind())
            {
                Attack();
            }
        }

        private void Attack() => _chooserWeapon.CurrentWeapon?.WeaponAttacker.Attack();

        private bool TargetIsFind() => _targetFinder.CurrentTarget != null;

        private void SetComponents()
        {
            _chooserWeapon = GetComponent<ChooserWeapon>();
            _targetFinder = GetComponent<TargetFinder>();
        }
    }
}