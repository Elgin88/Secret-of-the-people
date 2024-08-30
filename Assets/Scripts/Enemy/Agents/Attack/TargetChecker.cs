using System;
using Enemy.Animations;
using UnityEngine;

namespace Enemy.Agents.Attack
{
    public class TargetChecker : MonoBehaviour
    {
        [SerializeField] private AttackAnimation _attackAnimation;
        [SerializeField] private Transform _hitPoint;
        [SerializeField] private LayerMask _target;

        private readonly Collider[] _results = new Collider[1];
        private readonly float _radius = 0.3f;

        public Action IsTargetFound;

        private void FixedUpdate()
        {
            if (TargetIsFind() & !IsPlayAttack())
            {
                IsTargetFound.Invoke();
            }
        }
        private bool IsPlayAttack() => _attackAnimation.IsAttack;

        private bool TargetIsFind() => GetTargetCount() > 0;

        private int GetTargetCount() => Physics.OverlapSphereNonAlloc(_hitPoint.position, _radius, _results, _target);
    }
}