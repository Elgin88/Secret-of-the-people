using System;
using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AttackZoneExit : MonoBehaviour
    {
        [SerializeField] private AgentAttack _agentAttack;

        public Action<Collider> IsPlayerExit;

        private void OnTriggerExit(Collider collider)
        {
            InvokeIsPlayerEnter(collider);
        }

        private void InvokeIsPlayerEnter(Collider collider) => IsPlayerExit?.Invoke(collider);
    } 
}