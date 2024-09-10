using System;
using UnityEngine;

namespace Enemy.AI.Checkers
{
    public class CheckerCanAttack : MonoBehaviour
    {
        [SerializeField] private LayerMask _playerMask;
        [SerializeField] private Transform _hitPoint;

        private readonly Collider[] _results = new Collider[1];
        private readonly float _radiusAttackSphere = 0.2f;

        public Action OnCanAttack;

        public Action OnNotCanAttack;

        public bool IsCanAttack { get; private set; }

        private void FixedUpdate()
        {
            if (IsCanHit())
            {
                OnCanAttack?.Invoke();
                SetIsCanAttack(true);
            }
            else
            {
                OnNotCanAttack?.Invoke();
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