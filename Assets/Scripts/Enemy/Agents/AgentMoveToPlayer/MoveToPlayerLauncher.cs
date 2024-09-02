using System;
using Enemy.Agents.AgentPatrol;
using Enemy.Agents.AgentsCheckers;
using UnityEngine;

namespace Enemy.Agents.AgentMoveToPlayer
{
    [RequireComponent(typeof(MoveToPlayer))]
    [RequireComponent(typeof(Patrol))]

    public class MoveToPlayerLauncher : MonoBehaviour
    {
        private MoveToPlayer _moveToPlayer;
        private CanAttacker _canAttacker;
        private Patrol _patrol;
        private Agro _agro;

        private void Awake()
        {
            GetComponents();
            Off();
            _agro.Agred += OnAgro;
        }

        private void OnDestroy()
        {
            _agro.Agred -= OnAgro;
        }

        public void On()
        {
            _moveToPlayer.On();
            _canAttacker.On();
            _patrol.Off();
        }

        public void Off()
        {
            _moveToPlayer.Off();
            _canAttacker.Off();
            _patrol.On();
        }

        private void OnAgro() => On();
        private void GetComponents()
        {
            _moveToPlayer = GetComponent<MoveToPlayer>();
            _canAttacker = GetComponent<CanAttacker>();
            _patrol = GetComponent<Patrol>();
            _agro = GetComponent<Agro>();
        }
    }
}