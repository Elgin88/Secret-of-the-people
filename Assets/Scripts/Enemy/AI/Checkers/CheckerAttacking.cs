using System;
using Enemy.AI.Agents;
using Enemy.AI.Checkers.Starters;
using Enemy.AI.Checkers.Stoppers;
using UnityEngine;

namespace Enemy.AI.Checkers
{
    [RequireComponent(typeof(StarterCheckerAttacking))]
    [RequireComponent(typeof(StopperCheckerAttacking))]
    
    public class CheckerAttacking : MonoBehaviour
    {
        [SerializeField] private AgentAttack _agentAttack;

        public Action OnAttacking;

        public Action OnNotAttacking;

        private void FixedUpdate()
        {
            if (_agentAttack.enabled)
            {
                OnAttacking?.Invoke();
            }
            else
            {
                OnNotAttacking?.Invoke();
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

        private void SetEnabled(bool status) => enabled = status;
    }
}