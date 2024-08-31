using System;
using Enemy.Animations;
using UnityEngine;

namespace Enemy.Agents.Attack
{
    public class AgentAttackTargetFinder : MonoBehaviour
    {
        [SerializeField] private Transform _hitPoint;
        [SerializeField] private LayerMask _target;

        private readonly Collider[] _results = new Collider[1];
        private readonly float _radius = 0.3f;

        public Action TargetIsFound;

        private void Start() => Disable();

        public void Enable() => enabled = true;

        public void Disable() => enabled = false;

        private void FixedUpdate()
        {
            if (TargetIsFind())
            {
                TargetIsFound.Invoke();
            }
        }

        private bool TargetIsFind() => GetTargetCount() > 0;

        private int GetTargetCount() => Physics.OverlapSphereNonAlloc(_hitPoint.position, _radius, _results, _target);
    }
}