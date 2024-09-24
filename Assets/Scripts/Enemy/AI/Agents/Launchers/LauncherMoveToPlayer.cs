using Enemy.AI.Agents.Checkers;
using UnityEngine;

namespace Enemy.AI.Agents.Launchers
{
    public class LauncherMoveToPlayer : MonoBehaviour
    {
        [SerializeField] private CheckerAttackRange _checkerIsInAttackRange;
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;
        [SerializeField] private CheckerAgro _checkerAgro;

        private void Awake()
        {
            _agentMoveToPlayer.Off();
        }

        private void FixedUpdate()
        {
            if (IsAgro() & !IsInAttackRange())
            {
                _agentMoveToPlayer.On();
            }
            else
            {
                _agentMoveToPlayer.Off();
            }
        }

        private bool IsInAttackRange() => _checkerIsInAttackRange.IsRange;

        private bool IsAgro() => _checkerAgro.IsAgro;
    }
}