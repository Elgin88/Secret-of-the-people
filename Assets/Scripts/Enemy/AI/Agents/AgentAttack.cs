using Enemy.AI.Agents.Checkers;
using Enemy.Animations;
using UnityEngine;

namespace Enemy.AI.Agents
{
    public class AgentAttack : MonoBehaviour
    {
        [SerializeField] private EnemyAnimationsSetter _enemyAnimationsSetter;
        [SerializeField] private CkeckerAttackCooldown _checkerAttackCooldown;
        [SerializeField] private CheckerIdle _checkerIdle;

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
            _checkerIdle.SetIsIdle();
            _checkerAttackCooldown.ResetCooldown();
        }

        private void PlayAttackAnimation() => _enemyAnimationsSetter.PlayAttack();
    }
}