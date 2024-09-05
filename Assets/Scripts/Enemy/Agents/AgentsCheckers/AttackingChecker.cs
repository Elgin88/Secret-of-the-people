using System;
using Enemy.Agents.Agents;
using UnityEngine;

namespace Enemy.Agents.AgentsCheckers
{
    public class AttackingChecker : MonoBehaviour
    {
        [SerializeField] private AgentAttack _agentAttack;

        public Action IsAttacking;

        public Action IsNotAttacking;

        private void FixedUpdate()
        {
            if (_agentAttack.enabled)
            {
                IsAttacking?.Invoke();
            }
            else
            {
                IsNotAttacking?.Invoke();
            }
        }
    }
}