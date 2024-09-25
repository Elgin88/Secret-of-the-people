using Player.Interfaces;
using UnityEngine;

namespace Enemy.AI.Agents.Checkers
{
    public class CheckerIsHit : MonoBehaviour
    {
        [SerializeField] private Transform _hitPoint;
        [SerializeField] private LayerMask _targetMask;

        private Collider[] _results = new Collider[2];
        private const float _radius = 1f;

        public bool IsHit { get; private set; }

        public bool GetIsHit(out Collider target)
        {
            target = null;

            IsHit = Physics.OverlapSphereNonAlloc(_hitPoint.position, _radius, _results, _targetMask) > 0;

            target = _results[0];

            return IsHit;
        }
    }
}