using Enemy.Agents.AgentsCheckers;
using Enemy.Agents.AgentsLaunchers;
using Enemy.Animations;
using Player.Animations;
using Player.Interfaces;
using StaticData;
using UnityEngine;

namespace Enemy.Agents.Agents
{
    [RequireComponent(typeof(LauncherAttack))]
    [RequireComponent(typeof(CanAttacker))]
    [RequireComponent(typeof(EnemyAnimationsSetter))]

    public class AgentAttack : MonoBehaviour
    {
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private Transform _hitPoint;
        [SerializeField] private LayerMask _target;

        private EnemyAnimationsSetter _enemyAnimationSetter;
        private readonly Collider[] _resultOfHit = new Collider[1];
        private LauncherAttack _launcherAttack;
        private const float _radiusHitPoint = 0.3f;
        private int _damage => _staticData.Damage;

        private void Awake() => GetComponents();

        public void On()
        {
            PlayAnimation();
        }

        public void Off()
        {
            StopPlayAnimation();
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

        private void AgentAttackOff() => _launcherAttack.Off();
        private void PlayAnimation() => _enemyAnimationSetter.PlayAttack();
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

        private void GetComponents()
        {
            _enemyAnimationSetter = GetComponent<EnemyAnimationsSetter>();
            _launcherAttack = GetComponent<LauncherAttack>();
        }
    }
}