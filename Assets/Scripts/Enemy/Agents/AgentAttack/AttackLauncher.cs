using Enemy.Agents.AgentMoveToPlayer;
using Enemy.Agents.AgentPatrol;
using Enemy.Agents.AgentsCheckers;
using UnityEngine;

namespace Enemy.Agents.AgentAttack
{
    [RequireComponent(typeof(MoveToPlayerLauncher))]
    [RequireComponent(typeof(CanAttacker))]
    [RequireComponent(typeof(PatrolLauncher))]
    [RequireComponent(typeof(Attack))]

    public class AttackLauncher : MonoBehaviour
    {
        private MoveToPlayerLauncher _moveToPlayerLauncher;
        private CanAttacker _attackTargetFinder;
        private PatrolLauncher _patrolLauncher;
        private Attack _attack;

        private void Awake()
        {
            GetComponents();
            SubIsCanAttack();
        }

        private void OnDestroy()
        {
            OnsubIsCanAttack();
        }

        public void On()
        {
        }

        public void Off()
        {
        }

        private void SubIsCanAttack() => _attackTargetFinder.IsCanAttack += On;
        private void OnsubIsCanAttack() => _attackTargetFinder.IsCanAttack -= On;

        private void GetComponents()
        {
            _moveToPlayerLauncher = GetComponent<MoveToPlayerLauncher>();
            _attackTargetFinder = GetComponent<CanAttacker>();
            _patrolLauncher = GetComponent<PatrolLauncher>();
            _attack = GetComponent<Attack>();
        }
    }
}