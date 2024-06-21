using System;
using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AttackZone : MonoBehaviour
    {
        private bool _isAttacking = false;
        
        public Action<Collider> PlayerEnter;
        
        public Action<Collider> PlayerExit;

        private void OnTriggerEnter(Collider other)
        {
            if (!_isAttacking)
            {
                InvokePlayerEnter(other);
                SetIsAttackingTrue();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (_isAttacking)
            {
                InvokePlayerExit(other);
                SetIsAttackingFalse();
            }
        }

        private void InvokePlayerEnter(Collider other) => PlayerEnter?.Invoke(other);
        private void InvokePlayerExit(Collider other) => PlayerExit?.Invoke(other);
        private void SetIsAttackingTrue() => _isAttacking = true;
        private void SetIsAttackingFalse() => _isAttacking = false;
    }
}