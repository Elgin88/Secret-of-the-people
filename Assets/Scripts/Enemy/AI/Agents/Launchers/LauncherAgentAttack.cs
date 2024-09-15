using System;
using Enemy.AI.Agents.Checkers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy.AI.Agents.Launchers
{
    public class LauncherAgentAttack : MonoBehaviour
    {
        [SerializeField] private CheckerCanHit _checkerCanHit;
        [SerializeField] private CheckerAgro _checkeAgro;
        [SerializeField] private AgentAttack _agentAttack;

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