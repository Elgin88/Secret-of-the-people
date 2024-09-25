using UnityEngine;

namespace Player.Logic
{
    public class Attacker : MonoBehaviour
    {
        [SerializeField] private TargetFinder _nextTargetFinder;

        private void FixedUpdate()
        {
            if (TargetIsFind())
            {
                //Shoot();
            }
        }

        private bool TargetIsFind() => _nextTargetFinder.CurrentTargetsCount != 0;
    }
}