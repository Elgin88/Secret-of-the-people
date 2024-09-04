using System;
using UnityEngine;

namespace Enemy.Agents.AgentsCheckers
{
    public class CanAttackChecker : MonoBehaviour
    {
        [SerializeField] private Transform _hitPoint;
        [SerializeField] private LayerMask _playerMask;

        private readonly Collider[] _results = new Collider[1];
        private readonly float _radius = 0.3f;

        public Action IsCanAttack;

        public Action IsNotCanAttack;

        private void Start()
        {
            Off();
        }

        private void FixedUpdate()
        {
            if (TargetCount() > 0)
            {
                IsCanAttack?.Invoke();
            }
            else
            {
                IsNotCanAttack?.Invoke();
            }
        }

        public void On()
        {
            SetEnabled(true);
        }

        public void Off()
        {
            SetEnabled(false);
        }

        private int TargetCount() => Physics.OverlapSphereNonAlloc(_hitPoint.position, _radius, _results, _playerMask);
        private void SetEnabled(bool status) => enabled = status;
    }
}