using System;
using System.Collections;
using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AttackZone : MonoBehaviour
    {
        public Action<Collider> PlayerEnter;
        public Action<Collider> PlayerExit;

        private bool _isAttacking = false;

        private void OnTriggerEnter(Collider other)
        {
            if (!_isAttacking)
            {
                PlayerEnter?.Invoke(other);
                SetIsAttackingTrue();
                Debug.Log("1");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (_isAttacking)
            {
                PlayerExit?.Invoke(other);
                SetIsAttackingFalse();
                Debug.Log("2");
            }
        }

        private void SetIsAttackingTrue() => _isAttacking = true;
        private void SetIsAttackingFalse() => _isAttacking = false;
    }
}