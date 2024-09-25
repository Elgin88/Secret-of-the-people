using UnityEngine;

namespace Enemy.AI.Agents.Checkers
{
    public class CheckerIdle : MonoBehaviour
    {
        [SerializeField] private CkeckerAttackCooldown _checkerCooldownAttack;
        [SerializeField] private CheckerAttackRange _checkerAttackRange;
        [SerializeField] private AgentAttack _agentAttack;

        public bool IsIdle { get; private set; }

        private void FixedUpdate()
        {
            if (SetIsNotRange())
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

        private bool SetIsNotRange() => !_checkerAttackRange.IsRange;
    }
}