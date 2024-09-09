using Enemy.AI.Agents.Starters;
using Enemy.AI.Agents.Stoppers;
using Enemy.AI.Checkers;
using Enemy.Animations;
using Player.Animations;
using Player.Interfaces;
using StaticData;
using UnityEngine;

namespace Enemy.AI.Agents
{
    [RequireComponent(typeof(StarterAgentAttack))]
    [RequireComponent(typeof(StopperAgentAttack))]
    public class AgentAttack : MonoBehaviour
    {
        [SerializeField] private EnemyAnimationsSetter _enemyAnimationSetter;
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private CheckerEndAttack _checkerEndAttack;
        [SerializeField] private Transform _hitPoint;
        [SerializeField] private LayerMask _target;

        private readonly Collider[] _resultOfHit = new Collider[1];
        private const float _radiusOfHitSphere = 0.3f;
        private int _damage => _staticData.Damage;

        private void OnEnable() => PlayAnimation();

        private void OnDisable() => StopPlayAnimation();

        private void FixedUpdate() => PlayAnimation();

        public void On()
        {
            if (!enabled)
            {
                SetEnabled(true);
            }
        }

        public void Off()
        {
            if (enabled)
            {
                SetEnabled(false);
            }
        }

        private void OnStartAttack()
        {
        }

        private void OnAttack()
        {
            if (IsHit(out Collider player))
            {
                GiveHit(player);
            }
        }

        private void OnAttackEnded()
        {
            _checkerEndAttack.InvokeOnAttackEnded();
        }

        private void SetEnabled(bool status) => enabled = status;
        private void PlayAnimation() => _enemyAnimationSetter.PlayAttack();
        private void StopPlayAnimation() => _enemyAnimationSetter.StopPlayAttack();

        private bool IsHit(out Collider target)
        {
            int count = Physics.OverlapSphereNonAlloc(_hitPoint.position, _radiusOfHitSphere, _resultOfHit, _target);

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