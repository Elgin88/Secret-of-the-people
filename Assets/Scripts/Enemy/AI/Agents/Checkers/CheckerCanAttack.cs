using UnityEngine;

namespace Enemy.AI.Agents.Checkers
{
    public class CheckerCanAttack : MonoBehaviour
    {
        [SerializeField] private LayerMask _playerMask;
        [SerializeField] private Transform _hitPoint;

        private readonly Collider[] _results = new Collider[1];
        private readonly float _radiusAttackSphere = 0.2f;

        public bool IsCanAttack { get; private set; }

        private void FixedUpdate()
        {
            if (IsCanHit())
            {
                SetIsCanAttack(true);
            }
            else
            {
                SetIsCanAttack(false);
            }
        }


        public void On()
        {
            if (!enabled)
            {
                SetEnabled(true);
            }
        }

        public void Off()
        {
            if (enabled)
            {
                SetEnabled(false);
            }
        }

        private void SetIsCanAttack(bool status) => IsCanAttack = status;
        private bool IsCanHit() => Physics.OverlapSphereNonAlloc(_hitPoint.position, _radiusAttackSphere, _results, _playerMask) > 0;
        private void SetEnabled(bool status) => enabled = status;
    }
}