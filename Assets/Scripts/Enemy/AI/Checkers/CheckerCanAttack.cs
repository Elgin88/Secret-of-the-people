using System;
using UnityEngine;

namespace Enemy.AI.Checkers
{
    public class CheckerCanAttack : MonoBehaviour
    {
        [SerializeField] private LayerMask _playerMask;
        [SerializeField] private Transform _hitPoint;

        private readonly Collider[] _results = new Collider[1];
        private readonly float _radius = 0.2f;
        private float _currentDelay;
        private float _delay = 0.3f;

        public Action OnCanAttack;

        public Action OnNotCanAttack;

        private void Awake() => Off();

        private void FixedUpdate()
        {
            UpdateCooldown();

            if (!CooldownIsEnd())
            {
                return;
            }

            if (TargetCount() > 0)
            {
                OnCanAttack?.Invoke();
                ResetCooldown();
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

        private bool CooldownIsEnd() => _currentDelay <= 0;

        private void ResetCooldown() => _currentDelay = _delay;

        private void UpdateCooldown() => _currentDelay -= Time.deltaTime;
    }
}