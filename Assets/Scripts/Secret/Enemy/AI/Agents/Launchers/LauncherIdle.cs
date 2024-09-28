using Secret.Enemy.AI.Agents.Checkers;
using UnityEngine;

namespace Secret.Enemy.AI.Agents.Launchers
{
    public class LauncherIdle : MonoBehaviour
    {
        [SerializeField] private CheckerAttackRange _checkerIsInAttackRange;
        [SerializeField] private CkeckerAttackCooldown _checkerCooldownAttack;
        [SerializeField] private CheckerIsAttacking _checkerIsAttacking;
        [SerializeField] private CheckerAgro _checkerAgro;
        [SerializeField] private CheckerIdle _checkerIdle;
        [SerializeField] private AgentEdle _agentEdle;

        private void Awake()
        {
            _agentEdle.Off();
        }

        private void FixedUpdate()
        {
            if (_checkerIdle.IsIdle)
            {
                _agentEdle.On();
            }
            else
            {
                _agentEdle.Off();
            }
        }
    }
}