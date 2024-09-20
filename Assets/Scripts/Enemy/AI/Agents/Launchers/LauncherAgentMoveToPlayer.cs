using System;
using UnityEngine;

namespace Enemy.AI.Agents.Launchers
{
    public class LauncherAgentMoveToPlayer : MonoBehaviour
    {
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;

        private void Awake()
        {
            _agentMoveToPlayer.Off();
        }
    }
}