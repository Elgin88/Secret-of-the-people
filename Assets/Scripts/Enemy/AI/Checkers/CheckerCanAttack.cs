using System;
using Enemy.AI.Checkers.Starters;
using Enemy.AI.Checkers.Stoppers;
using UnityEngine;

namespace Enemy.AI.Checkers
{
    [RequireComponent(typeof(StarterCheckerCanAttack))]
    [RequireComponent(typeof(StopperCheckerCanAttack))]
    
    public class CheckerCanAttack : MonoBehaviour
    {
        [SerializeField] private Transform _hitPoint;
        [SerializeField] private LayerMask _playerMask;

        private readonly Collider[] _results = new Collider[1];
        private readonly float _radius = 0.3f;

        public Action OnCanAttack;

        public Action OnNotCanAttack;
        
        private void FixedUpdate()
        {
            if (TargetCount() > 0)
            {
                OnCanAttack?.Invoke();
            }
            else
            {
                OnNotCanAttack?.Invoke();
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

        private int TargetCount() => Physics.OverlapSphereNonAlloc(_hitPoint.position, _radius, _results, _playerMask);
        private void SetEnabled(bool status) => enabled = status;
    }
}