using Enemy.AI.Agents.Checkers;
using UnityEngine;

namespace Enemy.AI.Agents.Launchers
{
    public class LauncherAgentAttack : MonoBehaviour
    {
        [SerializeField] private CheckerCanAttack _checkerCanAttack;
        [SerializeField] private CheckerAgro _checkeAgro;
        [SerializeField] private AgentAttack _agentAttack;

        private void FixedUpdate()
        {
        }
    }
}