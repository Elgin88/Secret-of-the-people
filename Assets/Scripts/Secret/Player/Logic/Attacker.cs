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
            }
        }

        private bool TargetIsFind() => _nextTargetFinder.CurrentTarget != null;
    }
}