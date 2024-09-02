using Enemy.Agents.Agents;
using Enemy.Agents.AgentsCheckers;
using UnityEngine;

namespace Enemy.Agents.AgentsLaunchers
{
    [RequireComponent(typeof(CanAttacker))]
    [RequireComponent(typeof(LauncherPatrol))]
    [RequireComponent(typeof(AgentMoveToPlayer))]
    
    public class LauncherMoveToPlayer : MonoBehaviour
    {
        private AgentMoveToPlayer _agentMoveToPlayer;
        private LauncherPatrol _launcherPatrol;
        private CanAttacker _canAttacker;
        private Agro _agro;

        private void Awake()
        {
            GetComponents();
            Off();
            SubAgro();
        }

        private void OnDestroy()
        {
            OnsubAgro();
        }

        private void On()
        {
        }

        private void Off()
        {
        }

        private void OnAgro() => On();
        private void SubAgro() => _agro.Agred += OnAgro;
        private void OnsubAgro() => _agro.Agred -= OnAgro;
        private void GetComponents()
        {
            _agentMoveToPlayer = GetComponent<AgentMoveToPlayer>();
            _launcherPatrol = GetComponent<LauncherPatrol>();
            _canAttacker = GetComponent<CanAttacker>();
            _agro = GetComponent<Agro>();
        }
    }
}