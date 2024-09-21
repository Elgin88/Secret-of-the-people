using Enemy.AI.Agents.Checkers;
using UnityEngine;

namespace Enemy.AI.Agents.Launchers
{
    public class LauncherAttack : MonoBehaviour
    {
        [SerializeField] private CheckerIsInAttackRange _checkerIsInAttackRange;
        [SerializeField] private CheckerAgro _checkerAgro;
        [SerializeField] private AgentAttack _agentAttack;
        private void FixedUpdate()
        {
            if (_checkerAgro.IsAgro & _checkerIsInAttackRange.IsInAttackRange)
            {
                _agentAttack.On();
            }
            else
            {
                _agentAttack.Off();
            }
        }
    }
}