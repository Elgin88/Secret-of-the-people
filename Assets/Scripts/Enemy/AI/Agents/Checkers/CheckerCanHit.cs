using UnityEngine;

namespace Enemy.AI.Agents.Checkers
{
    public class CheckerCanHit : MonoBehaviour
    {
        [SerializeField] private LayerMask _playerMask;
        [SerializeField] private Transform _hitPoint;

        private readonly Collider[] _results = new Collider[1];
        private readonly float _radiusAttackSphere = 0.2f;

        public bool IsCanHit { get; private set; }

        private void FixedUpdate()
        {
            IsCanHit = EnemyIsCanHit();
        }
        
        private bool EnemyIsCanHit() => Physics.OverlapSphereNonAlloc(_hitPoint.position, _radiusAttackSphere, _results, _playerMask) > 0;
    }
}