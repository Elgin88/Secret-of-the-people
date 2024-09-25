using Enemy.Logic;
using Player.Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy.AI.Agents.Checkers
{
    public class CheckerIsHit : MonoBehaviour
    {
        [SerializeField] private Transform _hitPoint;
        [SerializeField] private LayerMask _targetMask;

        private Collider[] _results = new Collider[2];
        private const float _radius = 1f;

        public bool GetIsHit() => Physics.OverlapSphereNonAlloc(_hitPoint.position, _radius, _results, _targetMask) > 0;

        public IPlayerHealthChanger GetTargetHealth() => _results[0].GetComponent<IPlayerHealthChanger>();
    }
}