using System;
using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AttackZoneEnter : MonoBehaviour
    {
        [SerializeField] private AgentAttack _agentAttack;

        public Action<Collider> IsPlayerEnter;
        
        private void OnTriggerEnter(Collider collider)
        {
            InvokeIsPlayerEnter(collider);
        }
        
        private void InvokeIsPlayerEnter(Collider other) => IsPlayerEnter?.Invoke(other);
    }
}