using Enemy.AI.Agents.Checkers;
using UnityEngine;

namespace Enemy.AI.Agents.Launchers
{
    public class LauncherAttack : MonoBehaviour
    {
        [SerializeField] private CkeckerAttackCooldown _checkerAttackCooldown;
        [SerializeField] private CheckerAttackRange _checkerAttackRange;
        [SerializeField] private AgentAttack _agentAttack;
        [SerializeField] private CheckerAgro _checkerAgro;
        [SerializeField] private CheckerIdle _checkerIdle;

        private void Awake()
        {
            _agentAttack.Off();
        }

        private void FixedUpdate()
        {
            if (IsAttackRange() & IsCooldownEnd())
            {
                _agentAttack.On();
            }

            if (IsNotCooldownEnd())
            {
                _agentAttack.Off();
            }
        }

        private bool IsNotCooldownEnd() => !_checkerAttackCooldown.IsEnd;
        private bool IsCooldownEnd() => _checkerAttackCooldown.IsEnd;
        private bool IsAttackRange() => _checkerAttackRange.IsRange;
    }
}