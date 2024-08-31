using System;
using Enemy.Animations;
using Player.Animations;
using Player.Interfaces;
using StaticData;
using UnityEngine;

namespace Enemy.Agents.Attack
{
    [RequireComponent(typeof(AgentAttackLauncher))]
    [RequireComponent(typeof(AgentAttackTargetFinder))]
    [RequireComponent(typeof(EnemyAnimationsSetter))]

    public class AgentAttack : MonoBehaviour
    {
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private Transform _hitPoint;
        [SerializeField] private LayerMask _target;

        private EnemyAnimationsSetter _enemyAnimationSetter;
        private AgentAttackLauncher _agentAttackLauncher;
        private readonly Collider[] _resultOfHit = new Collider[1];
        private const float _radiusHitPoint = 0.3f;
        private int _damage => _staticData.Damage;

        private void Awake()
        {
            _enemyAnimationSetter = GetComponent<EnemyAnimationsSetter>();
            _agentAttackLauncher = GetComponent<AgentAttackLauncher>();
        }

        private void Start() => SetEnabled(false);

        public void EnableAgent()
        {
            SetEnabled(true);
            PlayAnimation();
        }

        public void DisableAgent()
        {
            StopPlayAnimation();
            SetEnabled(false);
        }

        private void OnAttack()
        {
            if (IsHit(out Collider target))
            {
                GiveHit(target);
            }
        }

        private void OnAttackEnded()
        {
            StopPlayAnimation();
            AgentAttackOff();
        }

        private void SetEnabled(bool status) => enabled = status;
        private void PlayAnimation() => _enemyAnimationSetter.PlayAttack();
        private void AgentAttackOff() => _agentAttackLauncher.AgentOff();
        private void StopPlayAnimation() => _enemyAnimationSetter.StopPlayAttack();

        private bool IsHit(out Collider target)
        {
            int count = Physics.OverlapSphereNonAlloc(_hitPoint.position, _radiusHitPoint, _resultOfHit, _target);

            target = _resultOfHit[0];

            return count > 0;
        }

        private void GiveHit(Collider player)
        {
            player.GetComponent<IPlayerHealthChanger>().RemoveHealth(_damage);
            player.GetComponent<IPlayerAnimationsSetter>().PlayHit();
        }
    }
}