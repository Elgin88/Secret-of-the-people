using System;
using Enemy.Agents.MoveToPlayer;
using Enemy.Animations;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy.Agents.Attack
{
    [RequireComponent(typeof(AgentAttack))]
    [RequireComponent(typeof(TargetFindChecker))]
    
    public class AgentAttackLauncher : MonoBehaviour
    {
        [SerializeField] private TargetFindChecker _targetFindChecker;
        [SerializeField] private AgentAttack _agentAttack;
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;

        private void Awake() => _targetFindChecker.TargetFound += OnTargetFound;

        private void OnDestroy() => _targetFindChecker.TargetFound -= OnTargetFound;

        private void OnTargetFound()
        {
            Debug.Log("AgentAttackLauncher");
            
            _agentMoveToPlayer.DisableAgent();
            _agentAttack.EnableAgent();
        }
    }
}