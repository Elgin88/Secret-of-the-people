using UnityEngine;

namespace Enemy.AI.Agents.Checkers
{
    public class CheckerIdle : MonoBehaviour
    {
        [SerializeField] private CkeckerAttackCooldown _checkerCooldownAttack;
        [SerializeField] private AgentAttack _agentAttack;
        [SerializeField] private CheckerAttackRange _checkerAttackRange;

        public bool IsIdle;

        private void FixedUpdate()
        {
            if (!_checkerAttackRange.IsRange)
            {
                SetIsNotIdle();
            }
        }

        public void SetIsIdle()
        {
            IsIdle = true;
        }

        public void SetIsNotIdle()
        {
            IsIdle = false;
        }
    }
}