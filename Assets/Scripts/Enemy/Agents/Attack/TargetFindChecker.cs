using System;
using Enemy.Animations;
using UnityEngine;

namespace Enemy.Agents.Attack
{
    public class TargetFindChecker : MonoBehaviour
    {
        [SerializeField] private AttackAnimation _attackAnimation;
        [SerializeField] private Transform _hitPoint;
        [SerializeField] private LayerMask _target;

        private readonly Collider[] _results = new Collider[1];
        private readonly float _radius = 0.3f;
        private bool _isFind;

        public Action TargetFound;

        private void FixedUpdate()
        {
            if (IsTargetFind() & !IsPlayAttack())
            {
                Debug.Log("TargetFound");

                TargetFound.Invoke();
            }
        }
        private bool IsPlayAttack() => _attackAnimation.IsAttack;

        private bool IsTargetFind() => GetTargetCount() > 0;

        private int GetTargetCount() => Physics.OverlapSphereNonAlloc(_hitPoint.position, _radius, _results, _target);
    }
}