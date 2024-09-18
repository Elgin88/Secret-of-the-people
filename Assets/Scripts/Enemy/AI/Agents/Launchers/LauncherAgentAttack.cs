using Enemy.AI.Agents.Checkers;
using UnityEngine;

namespace Enemy.AI.Agents.Launchers
{
    public class LauncherAgentAttack : MonoBehaviour
    {
        [SerializeField] private CheckerCanHit _checkerCanHit;
        [SerializeField] private AgentAttack _agentAttack;
        [SerializeField] private CheckerAgro _checkeAgro;

        private void Awake()
        {
            _agentAttack.Off();
        }

        private void FixedUpdate()
        {
            if (_checkeAgro.IsAgred & _checkerCanHit.IsCanHit)
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