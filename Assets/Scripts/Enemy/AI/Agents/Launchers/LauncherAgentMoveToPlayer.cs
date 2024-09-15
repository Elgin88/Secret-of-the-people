using Enemy.AI.Agents.Checkers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy.AI.Agents.Launchers
{
    public class LauncherAgentMoveToPlayer : MonoBehaviour
    {
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;
        [SerializeField] private CheckerCanHit _checkerCanHit;
        [SerializeField] private CheckerAgro _checkerAgro;

        private void FixedUpdate()
        {
            if (_checkerAgro.IsAgred & !_checkerCanHit.IsCanHit)
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