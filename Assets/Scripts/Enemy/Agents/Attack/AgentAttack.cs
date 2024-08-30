using Enemy.Animations;
using Player.Animations;
using Player.Interfaces;
using StaticData;
using UnityEngine;

namespace Enemy.Agents.Attack
{
    [RequireComponent(typeof(EnemyAnimationsSetter))]
    [RequireComponent(typeof(AgentAttackLauncher))]
    [RequireComponent(typeof(TargetChecker))]

    public class AgentAttack : MonoBehaviour
    {
        [SerializeField] private EnemyAnimationsSetter _enemyAnimationSetter;
        [SerializeField] private AgentAttackLauncher _agentAttackLauncher;
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private Transform _hitPoint;
        [SerializeField] private LayerMask _target;

        private readonly Collider[] _resultOfHit = new Collider[1];
        private const float _radiusHitPoint = 0.3f;
        private int _damage => _staticData.Damage;

        public void EnableAgent() => PlayAnimation();

        public void DisableAgent() => StopPlayAnimation();

        private void OnAttack()
        {
            if (IsHit(out Collider player))
            {
                GiveHit(player);
            }
        }

        private void OnAttackEnded()
        {
            StopPlayAnimation();
            _agentAttackLauncher.AgentOff();
        }

        private void StopPlayAnimation() => _enemyAnimationSetter.StopPlayAttack();

        private void PlayAnimation() => _enemyAnimationSetter.PlayAttack();

        private bool IsHit(out Collider hitCollider)
        {
            int count = Physics.OverlapSphereNonAlloc(_hitPoint.position, _radiusHitPoint, _resultOfHit, _target);

            hitCollider = _resultOfHit[0];

            return count > 0;
        }

        private void GiveHit(Collider player)
        {
            player.GetComponent<IPlayerHealthChanger>().RemoveHealth(_damage);
            player.GetComponent<IPlayerAnimationsSetter>().PlayHit();
        }
    }
}