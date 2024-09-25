using Enemy.AI.Agents.Checkers;
using Enemy.Animations;
using Player.Animations.Logic;
using Player.Interfaces;
using StaticData;
using UnityEngine;

namespace Enemy.AI.Agents
{
    public class AgentAttack : MonoBehaviour
    {
        [SerializeField] private CkeckerAttackCooldown _checkerAttackCooldown;
        [SerializeField] private EnemyAnimationsSetter _enemyAnimationsSetter;
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private CheckerIsHit _checkerIsHit;
        [SerializeField] private CheckerIdle _checkerIdle;

        private int _damage => _staticData.Damage;

        private void OnEnable()
        {
            _checkerIdle.SetIsNotIdle();
        }

        private void FixedUpdate()
        {
            PlayAttackAnimation();
        }

        public void On()
        {
            if (!enabled)
            {
                enabled = true;
            }
        }

        public void Off()
        {
            if (enabled)
            {
                enabled = false;
            }
        }

        private void OnHit()
        {
            if (_checkerIsHit.GetIsHit(out Collider target))
            {
                GiveDamage(target, _damage);
                PlayHitAnimation(target);
            }

            AgentEdleOn();
            ResetAttackCooldown();
        }

        private void GiveDamage(Collider target, int damage) => target.GetComponent<IPlayerHealthChanger>().RemoveHealth(damage);

        private void PlayHitAnimation(Collider target) => target.GetComponent<IPlayerAnimationsSetter>().PlayHit();

        private void PlayAttackAnimation() => _enemyAnimationsSetter.PlayAttack();

        private void ResetAttackCooldown() => _checkerAttackCooldown.ResetCooldown();

        private void AgentEdleOn() => _checkerIdle.SetIsIdle();
    }
}