using Enemy.AI.Agents.Checkers;
using UnityEngine;

namespace Enemy.AI.Agents.Launchers
{
    public class LauncherMoveToPlayer : MonoBehaviour
    {
        [SerializeField] private CheckerIsInAttackRange _checkerIsInAttackRange;
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;
        [SerializeField] private CheckerAgro _checkerAgro;

        private void FixedUpdate()
        {
            if (_checkerAgro.IsAgro & !_checkerIsInAttackRange.IsInAttackRange)
            {
                _agentMoveToPlayer.On();
            }
            else
            {
                _agentMoveToPlayer.Off();
            }
        }
    }
}