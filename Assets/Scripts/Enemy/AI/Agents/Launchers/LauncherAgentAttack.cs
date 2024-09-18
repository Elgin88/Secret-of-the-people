using Enemy.AI.Agents.Checkers;
using UnityEngine;

namespace Enemy.AI.Agents.Launchers
{
    public class LauncherAgentAttack : MonoBehaviour
    {
        [SerializeField] private CheckerAttackEnded _checkerAttackEnded;
        [SerializeField] private CheckerCanHit _checkerCanHit;
        [SerializeField] private AgentAttack _agentAttack;
        [SerializeField] private CheckerAgro _checkeAgro;

        private void FixedUpdate()
        {
            if (IsAgred() & IsCanHit() & IsNotAttackEnded())
            {
                _agentAttack.On();
            }
            else
            {
                _agentAttack.Off();
            }
        }

        private bool IsNotAttackEnded() => !_checkerAttackEnded.IsAttackEnded;

        private bool IsCanHit() => _checkerCanHit.IsCanHit;

        private bool IsAgred() => _checkeAgro.IsAgred;
    }
}