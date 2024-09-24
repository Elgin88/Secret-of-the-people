using UnityEngine;

namespace Enemy.AI.Agents.Checkers
{
    public class CheckerIdle : MonoBehaviour
    {
        [SerializeField] private CkeckerAttackCooldown _checkerCooldownAttack;
        [SerializeField] private AgentAttack _agentAttack;
        [SerializeField] private CheckerAttackRange _checkerAttackRange;

        private bool _isIdle = false;

        public bool IsIdle => _isIdle;

        private void FixedUpdate()
        {
            if (!_checkerAttackRange.IsRange)
            {
                SetIsNotIdle();
            }
        }

        public void SetIsIdle()
        {
            _isIdle = true;
        }

        public void SetIsNotIdle()
        {
            _isIdle = false;
        }
    }
}