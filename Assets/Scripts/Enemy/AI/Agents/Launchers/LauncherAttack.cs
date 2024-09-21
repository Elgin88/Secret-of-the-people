using System;
using Enemy.AI.Agents.Checkers;
using UnityEngine;

namespace Enemy.AI.Agents.Launchers
{
    public class LauncherAttack : MonoBehaviour
    {
        [SerializeField] private CheckerIsInAttackRange _checkerIsInAttackRange;
        [SerializeField] private AgentAttack _agentAttack;
        [SerializeField] private CheckerAgro _checkerAgro;

        private void Awake() => _agentAttack.Off();

        private void FixedUpdate()
        {
            if (IsAgro() & IsInAttackRange())
            {
                _agentAttack.On();
            }
            else
            {
                _agentAttack.Off();
            }
        }

        private bool IsInAttackRange() => _checkerIsInAttackRange.IsInAttackRange;

        private bool IsAgro() => _checkerAgro.IsAgro;
    }
}