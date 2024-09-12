using Enemy.AI.Agents.Checkers;
using UnityEngine;

namespace Enemy.AI.Agents.Launchers
{
    public class LauncherAgentMoveToPlayer : MonoBehaviour
    {
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;
        [SerializeField] private CheckerCanAttack _checkerCanAttack;
        [SerializeField] private CheckerAgro _checkerAgro;

        private void FixedUpdate()
        {
            if (_checkerAgro.IsAgred & !_checkerCanAttack.IsCanAttack)
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