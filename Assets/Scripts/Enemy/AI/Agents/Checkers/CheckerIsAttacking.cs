using UnityEngine;

namespace Enemy.AI.Agents.Checkers
{
    public class CheckerIsAttacking : MonoBehaviour
    {
        [SerializeField] private AgentAttack _agentAttack;

        public bool IsAttacking { get; private set; }

        private void FixedUpdate()
        {
            if (_agentAttack.enabled)
            {
                IsAttacking = true;
            }
            else
            {
                IsAttacking = false;
            }
        }
    }
}