using Enemy.AI.Agents.Checkers;
using Enemy.Animations;
using StaticData;
using UnityEngine;

namespace Enemy.AI.Agents
{
    public class AgentAttack : MonoBehaviour
    {
        [SerializeField] private EnemyAnimationsSetter _enemyAnimationsSetter;
        [SerializeField] private CkeckerAttackCooldown _checkerAttackCooldown;
        [SerializeField] private CheckerIsHit _checkerIsHit;
        [SerializeField] private CheckerIdle _checkerIdle;
        [SerializeField] private MonsterStaticData _staticData;

        private int _damage => _staticData.Damage;

        private void OnEnable()
        {
            _checkerIdle.SetIsNotIdle();
        }

        private void FixedUpdate()
        {
            Debug.Log("AgentAttack");

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
            if (IsCanHit())
            {
                GiveDamage();
            }

            _checkerIdle.SetIsIdle();
            _checkerAttackCooldown.ResetCooldown();
        }

        private void GiveDamage() => _checkerIsHit.GetTargetHealth().RemoveHealth(_damage);

        private bool IsCanHit() => _checkerIsHit.GetIsHit();

        private void PlayAttackAnimation() => _enemyAnimationsSetter.PlayAttack();
    }
}