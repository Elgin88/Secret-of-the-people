using System;
using UnityEngine;

namespace Enemy.Agents.AgentsCheckers
{
    public class CanAttacker : MonoBehaviour
    {
        [SerializeField] private Transform _hitPoint;
        [SerializeField] private LayerMask _target;

        private readonly Collider[] _results = new Collider[1];
        private readonly float _radius = 0.3f;

        public Action IsCanAttack;

        private void Start()
        {
            Off();
        }

        public void On()
        {
            enabled = true;
        }

        public void Off()
        {
            enabled = false;
        }

        private void FixedUpdate()
        {
            if (TargetCount() > 0)
            {
                IsCanAttack.Invoke();
            }
        }

        private int TargetCount() => Physics.OverlapSphereNonAlloc(_hitPoint.position, _radius, _results, _target);
    }
}