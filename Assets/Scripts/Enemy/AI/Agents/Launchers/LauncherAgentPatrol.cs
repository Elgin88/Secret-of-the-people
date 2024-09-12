using Enemy.AI.Agents.Checkers;
using UnityEngine;

namespace Enemy.AI.Agents.Launchers
{
    public class LauncherAgentPatrol : MonoBehaviour
    {
        [SerializeField] private CheckerCanAttack _checkerCanAttack;
        [SerializeField] private AgentPatrol _agentPatrol;
        [SerializeField] private CheckerAgro _checkerAgro;

        private void FixedUpdate()
        {
            if (!_checkerAgro.IsAgred & !_checkerCanAttack.IsCanAttack)
            {
                _agentPatrol.Off();
            }
            else
            {
                _agentPatrol.On();
            }
        }
    }
}